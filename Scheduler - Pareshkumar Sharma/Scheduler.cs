using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Scheduler___Pareshkumar_Sharma
{
    public partial class Scheduler : Form
    {
        Thread main, mainVal, mainProd;
        bool StopFlag = false, stopFlagVal = false, stopFlagProd = false;
        DateTime nextSchedule = DateTime.Now;
        DateTime nextScheduleVal = DateTime.Now;
        DateTime nextScheduleProd = DateTime.Now;
        string LogFilePath = ".\\LogFile.log";
        const string FORM_TITLE = "LIMS | Scheduler - Pareshkumar Sharma";
        int IdealRunProd = 0, IdealRunSat = 0, IdealRunVal = 0;


        public Scheduler()
        {
            InitializeComponent();
        }

        private void Scheduler_Load(object sender, EventArgs e)
        {
            bool configured = false, configuredVal = false, configuredProd = false;
            string program = "", programVal = "", programProd = "";
            string interval = "", intervalVal = "", intervalProd = "";
            btn_Stop.Enabled = false;
            btn_stop_val.Enabled = false;
            btn_stop_prod.Enabled = false;
            try
            {
                configured = ConfigurationManager.AppSettings.Get("Configured") == "1";
                program = ConfigurationManager.AppSettings.Get("Program");
                interval = ConfigurationManager.AppSettings.Get("Interval");
                int tmp = 5;
                if (!int.TryParse(interval, out tmp) || tmp<= 0) interval = "5";
                txt_Program.Text = program;
                txt_Interval.Text = interval;

                programVal = ConfigurationManager.AppSettings.Get("ProgramVal");
                intervalVal = ConfigurationManager.AppSettings.Get("IntervalVal");
                if (!int.TryParse(intervalVal, out tmp) || tmp <= 0) intervalVal = "5";
                txt_program_val.Text = programVal;
                txt_interval_val.Text = intervalVal;

                programProd = ConfigurationManager.AppSettings.Get("ProgramProd");
                intervalProd = ConfigurationManager.AppSettings.Get("IntervalProd");
                if (!int.TryParse(intervalProd, out tmp) || tmp <= 0) intervalProd = "5";
                txt_program_prod.Text = programProd;
                txt_interval_prod.Text = intervalProd;

                chk_SAT.Checked = ConfigurationManager.AppSettings.Get("Configured") == "1";
                configuredVal = ConfigurationManager.AppSettings.Get("ConfiguredVal") == "1";
                chk_Val.Checked = ConfigurationManager.AppSettings.Get("ConfiguredVal") == "1";
                configuredProd = ConfigurationManager.AppSettings.Get("ConfiguredProd") == "1";
                chk_Prod.Checked = ConfigurationManager.AppSettings.Get("ConfiguredProd") == "1";

                Txt_Max_ideal_run.Text = ConfigurationManager.AppSettings.Get("Max_Ideal_Run_Time");
                if (Txt_Max_ideal_run.Text.Trim().Length == 0) Txt_Max_ideal_run.Text = "50";

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings.AllKeys.Contains("LogFile") && config.AppSettings.Settings["LogFile"].Value.Trim().Length > 0)
                {
                    LogFilePath = config.AppSettings.Settings["LogFile"].Value;
                }

                if (!Directory.Exists(Path.GetDirectoryName(LogFilePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));

                // because of loading issue removed
                //string previousLogText = "";
                //if (File.Exists(LogFilePath))
                //{
                //    previousLogText = File.ReadAllText(LogFilePath);
                //}
                //txt_Log.Text = previousLogText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warning");
            }
            if (configured || configuredVal || configuredProd)
            {
                btn_Modify.Enabled = true;
                btn_Configure.Enabled = false;
                chk_SAT.Enabled = chk_Val.Enabled = chk_Prod.Enabled = false;
                Txt_Max_ideal_run.Enabled = false;
            }
            else
            {
                btn_Modify.Enabled = false;
                btn_Configure.Enabled = true;
            }

            if (configured)
            { // SAT
                txt_Interval.Enabled = false;
                txt_Program.Enabled = false;
                btn_Browse.Enabled = false;

                txt_Interval.Text = interval;
                txt_Program.Text = program;

                writelog(Environment.NewLine + "Automatic start scheduler SAT initiated..." + DateTime.Now.ToString("F") + Environment.NewLine);
                btn_Start.PerformClick();
            }

            if (configuredVal)
            { // VAL
                txt_interval_val.Enabled = false;
                txt_program_val.Enabled = false;
                btn_Browse_val.Enabled = false;

                txt_interval_val.Text = intervalVal;
                txt_program_val.Text = programVal;

                writelog(Environment.NewLine + "Automatic start scheduler VAL initiated..." + DateTime.Now.ToString("F") + Environment.NewLine);
                Btn_Start_VAL.PerformClick();
            }

            if (configuredProd)
            { // VAL
                txt_interval_prod.Enabled = false;
                txt_program_prod.Enabled = false;
                btn_Browse_PROD.Enabled = false;

                txt_interval_prod.Text = intervalProd;
                txt_program_prod.Text = programProd;

                writelog(Environment.NewLine + "Automatic start scheduler PROD initiated..." + DateTime.Now.ToString("F") + Environment.NewLine);
                Btn_Start_Prod.PerformClick();
            }

            txt_Log.SelectionStart = txt_Log.Text.Length - 1;
            txt_Log.ScrollToCaret();
        }

        private void assignThread()
        {
            StopFlag = false;
            main = new Thread(() =>
            {
                while (!StopFlag)
                {
                    deleteTmpFiles(txt_Program.Text);

                    string log = "";
                    log = Environment.NewLine + "Sat Schedule started " + DateTime.Now.ToString("F") + Environment.NewLine;

                    int interval = Convert.ToInt32(txt_Interval.Text);
                    int AllowedIdealRun = Convert.ToInt32(Txt_Max_ideal_run.Text);
                    Process[] workers = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(txt_Program.Text.Trim()));

                    if (workers != null && workers.Length > 0 && IdealRunSat < AllowedIdealRun)
                    {
                        IdealRunSat += interval;
                        log += Environment.NewLine + "SAT Schedule Program already running " + nextSchedule.ToString("F") + Environment.NewLine;
                        log += Environment.NewLine + "SAT Schedule Ideal Run: " + IdealRunSat + " " + nextScheduleProd.ToString("F") + Environment.NewLine;
                    }
                    else
                    {
                        log += Environment.NewLine + "SAT Schedule Ideal Run: " + IdealRunVal + " Starting closing program..." + Environment.NewLine;
                        IdealRunSat = 0;
                        if (workers != null && workers.Length > 0)
                        {
                            foreach (Process w in workers)
                            {
                                log += Environment.NewLine + "Sat Schedule Closing programs : " + Environment.NewLine;
                                w.Kill();
                                w.WaitForExit();
                                w.Dispose();
                            }
                        }
                        Process.Start(txt_Program.Text.Trim());
                        log += Environment.NewLine + "Sat Schedule started new programs : " + Environment.NewLine;
                    }

                    nextSchedule = DateTime.Now.AddMinutes(interval);

                    log += Environment.NewLine + "Sat Schedule waiting till " + nextSchedule.ToString("F") + Environment.NewLine;
                    writelog(log);

                    Thread.Sleep((interval) * (60000));
                }
            });
        }

        private void assignThread_Val()
        {
            stopFlagVal = false;
            mainVal = new Thread(() =>
            {
                while (!stopFlagVal)
                {
                    deleteTmpFiles(txt_program_val.Text);

                    string log = "";
                    log += Environment.NewLine + "VAL Schedule started " + DateTime.Now.ToString("F") + Environment.NewLine;


                    int interval = Convert.ToInt32(txt_interval_val.Text);
                    int AllowedIdealRun = Convert.ToInt32(Txt_Max_ideal_run.Text);
                    Process[] workers = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(txt_program_val.Text.Trim()));

                    if (workers != null && workers.Length > 0 && IdealRunVal < AllowedIdealRun)
                    {
                        IdealRunVal += interval;
                        log += Environment.NewLine + "VAL Schedule Program already running " + nextScheduleVal.ToString("F") + Environment.NewLine;
                        log += Environment.NewLine + "VAL Schedule Ideal Run: " + IdealRunVal + " " + nextScheduleProd.ToString("F") + Environment.NewLine;
                    }
                    else
                    {
                        log += Environment.NewLine + "VAL Schedule Ideal Run: " + IdealRunVal + " Starting closing program..." + Environment.NewLine;
                        IdealRunVal = 0;
                        if (workers != null && workers.Length > 0)
                        {
                            log += Environment.NewLine + "VAL Schedule Closing programs : " + Environment.NewLine;
                            foreach (Process w in workers)
                            {
                                w.Kill();
                                w.WaitForExit();
                                w.Dispose();
                            }
                        }
                        Process.Start(txt_program_val.Text.Trim());
                        log += Environment.NewLine + "VAL Schedule started new programs : " + Environment.NewLine;
                    }

                    nextScheduleVal = DateTime.Now.AddMinutes(interval);

                    log += Environment.NewLine + "VAL Schedule waiting till " + nextScheduleVal.ToString("F") + Environment.NewLine;
                    writelog(log);

                    Thread.Sleep((interval) * (60000));
                }
            });
        }

        private void assignThread_Prod()
        {
            stopFlagProd = false;
            mainProd = new Thread(() =>
            {
                while (!stopFlagProd)
                {
                    deleteTmpFiles(txt_program_prod.Text);

                    string log = "";
                    log = Environment.NewLine + "Prod Schedule started " + DateTime.Now.ToString("F") + Environment.NewLine;

                    int interval = Convert.ToInt32(txt_interval_prod.Text);
                    int AllowedIdealRun = Convert.ToInt32(Txt_Max_ideal_run.Text);
                    Process[] workers = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(txt_program_prod.Text.Trim()));
                    if (workers != null && workers.Length > 0 && IdealRunProd < AllowedIdealRun)
                    {
                        IdealRunProd += interval;
                        log += Environment.NewLine + "Prod Schedule Program already running " + nextScheduleProd.ToString("F") + Environment.NewLine;
                        log += Environment.NewLine + "Prod Schedule Ideal Run: " + IdealRunProd + " "  + nextScheduleProd.ToString("F") + Environment.NewLine;
                    }
                    else
                    {
                        log += Environment.NewLine + "Prod Schedule Ideal Run: " + IdealRunProd + " Starting closing program..." + Environment.NewLine;
                        IdealRunProd = 0;
                        if(workers != null && workers.Length > 0)
                        {
                            log += Environment.NewLine + "Prod Schedule Closing programs : " + Environment.NewLine;
                            foreach (Process w in workers)
                            {
                                w.Kill();
                                w.WaitForExit();
                                w.Dispose();
                            }
                        }
                        Process.Start(txt_program_prod.Text.Trim());
                        log += Environment.NewLine + "Prod Schedule started new programs : " + Environment.NewLine;
                    }

                    nextScheduleProd = DateTime.Now.AddMinutes(interval);

                    log += Environment.NewLine + "Prod Schedule waiting till " + nextScheduleProd.ToString("F") + Environment.NewLine;
                    writelog(log);

                    Thread.Sleep((interval) * (60000));
                }
            });
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "exe";
            openFileDialog.Title = "Select Scheduler file";
            openFileDialog.Filter = "Application Files (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                txt_Program.Text = filename;
            }
            else
            {

            }

        }

        private void btn_Browse_val_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "exe";
            openFileDialog.Title = "Select Scheduler file";
            openFileDialog.Filter = "Application Files (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                txt_program_val.Text = filename;
            }
            else
            {

            }

        }

        private void btn_Browse_prod_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "exe";
            openFileDialog.Title = "Select Scheduler file";
            openFileDialog.Filter = "Application Files (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                txt_program_prod.Text = filename;
            }
            else
            {

            }

        }

        private void btn_Configure_Click(object sender, EventArgs e)
        {
            if (chk_SAT.Checked && txt_Program.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select SAT program.", "Scheduler - Error");
                return;
            }

            if (chk_Val.Checked && txt_program_val.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select VAL program.", "Scheduler - Error");
                return;
            }

            if (chk_Prod.Checked && txt_program_prod.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select Prod program.", "Scheduler - Error");
                return;
            }

            if (chk_SAT.Checked)
            {
                txt_Interval.Enabled = false;
                txt_Program.Enabled = false;
                btn_Browse.Enabled = false;
            }

            if (chk_Val.Checked)
            {
                txt_interval_val.Enabled = false;
                txt_program_val.Enabled = false;
                btn_Browse_val.Enabled = false;
            }

            if (chk_Prod.Checked)
            {
                txt_interval_prod.Enabled = false;
                txt_program_prod.Enabled = false;
                btn_Browse_PROD.Enabled = false;
            }

            Txt_Max_ideal_run.Enabled = false;

            if (chk_SAT.Checked || chk_Val.Checked || chk_Prod.Checked)
            {
                btn_Configure.Enabled = false;
                btn_Modify.Enabled = true;
                chk_SAT.Enabled = chk_Val.Enabled = chk_Prod.Enabled = false;


                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Program"].Value = txt_Program.Text.Trim();
                config.AppSettings.Settings["Interval"].Value = txt_Interval.Text.Trim();
                config.AppSettings.Settings["ProgramVal"].Value = txt_program_val.Text.Trim();
                config.AppSettings.Settings["IntervalVal"].Value = txt_interval_val.Text.Trim();
                config.AppSettings.Settings["ProgramProd"].Value = txt_program_prod.Text.Trim();
                config.AppSettings.Settings["IntervalProd"].Value = txt_interval_prod.Text.Trim();
                if (chk_SAT.Checked)
                    config.AppSettings.Settings["Configured"].Value = "1";
                else
                    config.AppSettings.Settings["Configured"].Value = "0";
                if (chk_Val.Checked)
                    config.AppSettings.Settings["ConfiguredVal"].Value = "1";
                else
                    config.AppSettings.Settings["ConfiguredVal"].Value = "0";
                if (chk_Prod.Checked)
                    config.AppSettings.Settings["ConfiguredProd"].Value = "1";
                else
                    config.AppSettings.Settings["ConfiguredProd"].Value = "0";

                config.AppSettings.Settings["Max_Ideal_Run_Time"].Value = Txt_Max_ideal_run.Text.Trim();

                config.Save(ConfigurationSaveMode.Modified);

                string log = Environment.NewLine + " Tring to add Scheduler into autostart..." + Environment.NewLine;
                writelog(log);
                AddApplicationToStartup();
                log = Environment.NewLine + " Scheduler Added to autostart..." + Environment.NewLine;
                writelog(log);
            }
            else
            {
                MessageBox.Show("Invalid Configuration", "Scheduler - Error");
            }
        }
        public static void AddApplicationToStartup()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue(FORM_TITLE, "\"" + Application.ExecutablePath + "\"");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }

        public static void RemoveApplicationFromStartup()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue(FORM_TITLE, false);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Warning"); }
        }

        private void txt_Interval_TextChanged(object sender, EventArgs e)
        {
            string values = txt_Interval.Text;
            //Regex regex = new Regex("\\s");
            Regex regex_digit = new Regex("\\D");
            //if (regex.IsMatch(values))
            //{
            //    txt_Interval.Text = regex.Replace(values, "");
            //}
            if (regex_digit.IsMatch(values))
            {
                txt_Interval.Text = regex_digit.Replace(values, "");
            }
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Configured"].Value = "0";
            config.Save(ConfigurationSaveMode.Modified);

            btn_Configure.Enabled = true;
            btn_Modify.Enabled = false;
            Txt_Max_ideal_run.Enabled = true;
            if (chk_SAT.Checked)
            {
                txt_Interval.Enabled = true;
                txt_Program.Enabled = true;
                btn_Browse.Enabled = true;
            }

            if (chk_Val.Checked)
            {
                txt_interval_val.Enabled = true;
                txt_program_val.Enabled = true;
                btn_Browse_val.Enabled = true;
            }

            if (chk_Prod.Checked)
            {
                txt_interval_prod.Enabled = true;
                txt_program_prod.Enabled = true;
                btn_Browse_PROD.Enabled = true;
            }

            chk_SAT.Enabled = chk_Val.Enabled = chk_Prod.Enabled = true;

            string log = Environment.NewLine + " Scheduler Removing from autostart..." + Environment.NewLine;
            writelog(log);
            RemoveApplicationFromStartup();
            log = Environment.NewLine + " Scheduler Removed from autostart..." + Environment.NewLine;
            writelog(log);
        }

        private void on_focus_leave(object sender, EventArgs e)
        {
            if (txt_Interval.Text.Trim().Length == 0)
            {
                txt_Interval.Text = "5";
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (txt_Program.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select program.", "Scheduler - Error");
                return;
            }

            btn_Start.Enabled = false;
            btn_Stop.Enabled = true;
            txt_Log.SelectionStart = txt_Log.Text.Length;
            txt_Log.ScrollToCaret();
            if (main != null && main.IsAlive)
            {
                main.Abort();
            }
            assignThread();
            main.Start();
        }

        private void btn_Start_val_Click(object sender, EventArgs e)
        {
            if (txt_program_val.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select VAL program.", "Scheduler - Error");
                return;
            }

            Btn_Start_VAL.Enabled = false;
            btn_stop_val.Enabled = true;
            txt_Log.SelectionStart = txt_Log.Text.Length;
            txt_Log.ScrollToCaret();
            if (mainVal != null && mainVal.IsAlive)
            {
                mainVal.Abort();
            }
            assignThread_Val();
            mainVal.Start();
        }

        private void btn_Start_prod_Click(object sender, EventArgs e)
        {
            if (txt_program_prod.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select PROD program.", "Scheduler - Error");
                return;
            }

            Btn_Start_Prod.Enabled = false;
            btn_stop_prod.Enabled = true;
            txt_Log.SelectionStart = txt_Log.Text.Length;
            txt_Log.ScrollToCaret();
            if (mainProd != null && mainProd.IsAlive)
            {
                mainProd.Abort();
            }
            assignThread_Prod();
            mainProd.Start();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            StopFlag = true;
            btn_Stop.Enabled = false;
            btn_Start.Enabled = true;

            string log = Environment.NewLine + "Sat Schedule end triggered..." + Environment.NewLine + " next schedule cancelled at : " + nextSchedule.ToString("F") + Environment.NewLine;
            writelog(log);

            Focus();

            main.Abort();
        }

        private void btn_Stop_Val_Click(object sender, EventArgs e)
        {
            stopFlagVal = true;
            btn_stop_val.Enabled = false;
            Btn_Start_VAL.Enabled = true;

            string log = Environment.NewLine + "Val Schedule end triggered..." + Environment.NewLine + " next schedule cancelled at : " + nextScheduleVal.ToString("F") + Environment.NewLine;
            writelog(log);

            Focus();

            mainVal.Abort();
        }

        private void btn_Stop_Prod_Click(object sender, EventArgs e)
        {
            stopFlagProd = true;
            btn_stop_prod.Enabled = false;
            Btn_Start_Prod.Enabled = true;

            string log = Environment.NewLine + "Prod Schedule end triggered..." + Environment.NewLine + " next schedule cancelled at : " + nextScheduleProd.ToString("F") + Environment.NewLine;
            writelog(log);

            Focus();

            mainProd.Abort();
        }

        private void btn_OpenLocation_Click(object sender, EventArgs e)
        {
            if (txt_Program.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select program.", "Scheduler - Error");
                return;
            }
            Process.Start(Path.GetDirectoryName(txt_Program.Text.Trim()));
        }

        private void btn_OpenLocation_VAL_Click(object sender, EventArgs e)
        {
            if (txt_program_val.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select VAL program.", "Scheduler - Error");
                return;
            }
            Process.Start(Path.GetDirectoryName(txt_program_val.Text.Trim()));
        }

        private void btn_OpenLocation_PROD_Click(object sender, EventArgs e)
        {
            if (txt_program_prod.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select PROD program.", "Scheduler - Error");
                return;
            }
            Process.Start(Path.GetDirectoryName(txt_program_prod.Text.Trim()));
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            string log = "";
            if (main != null && main.IsAlive)
            {
                main.Abort();
                log = Environment.NewLine + " Sat Schedule end triggered..." + Environment.NewLine + " next schedule cancelled at : " + nextScheduleProd.ToString("F") + Environment.NewLine;
            }
            if (mainVal != null && mainVal.IsAlive)
            {
                mainVal.Abort();
                log = Environment.NewLine + " Val Schedule end triggered..." + Environment.NewLine + " next schedule cancelled at : " + nextScheduleProd.ToString("F") + Environment.NewLine;
            }
            if (mainProd != null && mainProd.IsAlive)
            {
                mainProd.Abort();
                log = Environment.NewLine + " Prod Schedule end triggered..." + Environment.NewLine + " next schedule cancelled at : " + nextScheduleProd.ToString("F") + Environment.NewLine;
            }
            writelog(log);

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Program"].Value = txt_Program.Text.Trim();
            config.AppSettings.Settings["Interval"].Value = txt_Interval.Text.Trim();
            config.AppSettings.Settings["ProgramVal"].Value = txt_program_val.Text.Trim();
            config.AppSettings.Settings["IntervalVal"].Value = txt_interval_val.Text.Trim();
            config.AppSettings.Settings["ProgramProd"].Value = txt_program_prod.Text.Trim();
            config.AppSettings.Settings["IntervalProd"].Value = txt_interval_prod.Text.Trim();
            if (chk_SAT.Checked)
                config.AppSettings.Settings["Configured"].Value = "1";
            else
                config.AppSettings.Settings["Configured"].Value = "0";
            if (chk_Val.Checked)
                config.AppSettings.Settings["ConfiguredVal"].Value = "1";
            else
                config.AppSettings.Settings["ConfiguredVal"].Value = "0";
            if (chk_Prod.Checked)
                config.AppSettings.Settings["ConfiguredProd"].Value = "1";
            else
                config.AppSettings.Settings["ConfiguredProd"].Value = "0";
            config.AppSettings.Settings["Max_Ideal_Run_Time"].Value = Txt_Max_ideal_run.Text.Trim();

            config.Save(ConfigurationSaveMode.Modified);
        }

        private void writelog(string log)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings.AllKeys.Contains("LogFile") && config.AppSettings.Settings["LogFile"].Value.Trim().Length > 0)
                {
                    LogFilePath = config.AppSettings.Settings["LogFile"].Value;
                }
                if (!Directory.Exists(Path.GetDirectoryName(LogFilePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));

                FileInfo fin = new FileInfo(LogFilePath);
                if (fin.Length > (1000 * 1024))
                    fin.Delete();

                File.AppendAllText(LogFilePath, log);
                AppendTextBoxLog(log);
            }
            catch { }
        }

        public void AppendTextBoxLog(string value)
        {
            if (txt_Log.InvokeRequired)
            {
                txt_Log.Invoke(new Action<string>(AppendTextBoxLog), new object[] { value });
                return;
            }
            txt_Log.Text += value;
            if (txt_Log.InvokeRequired)
            {
                txt_Log.Invoke(new Action<string>(AppendTextBoxLog), new object[] { value });
                return;
            }
            txt_Log.SelectionStart = txt_Log.Text.Length;
            if (txt_Log.InvokeRequired)
            {
                txt_Log.Invoke(new Action<string>(AppendTextBoxLog), new object[] { value });
                return;
            }
            txt_Log.ScrollToCaret();
        }

        public void EnableStartThreadButton()
        {
            if (btn_Start.InvokeRequired)
            {
                btn_Start.Invoke(new Action(EnableStartThreadButton));
                return;
            }
            btn_Start.Enabled = true;
        }

        public void FocusOnMainForm()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(FocusOnMainForm));
                return;
            }
            this.Focus();
        }

        public void deleteTmpFiles(string programPath)
        {
            string dir_str = Path.GetDirectoryName(programPath);
            string[] files = Directory.GetFiles(dir_str);
            writelog(Environment.NewLine + "Checking for tmp files from total : " + files.Length + Environment.NewLine);
            int del_files = 0;
            foreach (string file_name in files)
            {
                if (Path.GetFileName(file_name).StartsWith("dev_nco_rfc") || Path.GetFileName(file_name).StartsWith("nco_rfc_"))
                {
                    try
                    {
                        if (File.Exists(file_name))
                        {
                            DateTime flmd = File.GetLastWriteTime(file_name);
                            if (flmd.CompareTo(DateTime.Now.AddHours(-1)) <= 0)
                            {
                                del_files++;
                                File.Delete(file_name);
                                writelog(Environment.NewLine + " deleted " + file_name + Environment.NewLine);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string log = Environment.NewLine + $" {ex.Message} " + Environment.NewLine + ex.StackTrace + Environment.NewLine + Environment.NewLine + DateTime.Now.ToString("F") + Environment.NewLine;
                        writelog(log);
                    }
                }
            }
            if (del_files > 0)
            {
                writelog(Environment.NewLine + " total deleted files " + del_files + Environment.NewLine);
            }
            else
                writelog(Environment.NewLine + " No tmp files deleted " + Environment.NewLine);
        }
    }
}
