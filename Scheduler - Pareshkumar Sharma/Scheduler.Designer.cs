
namespace Scheduler___Pareshkumar_Sharma
{
    partial class Scheduler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scheduler));
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.txt_Program = new System.Windows.Forms.TextBox();
            this.lbl_Program = new System.Windows.Forms.Label();
            this.lbl_Internval = new System.Windows.Forms.Label();
            this.txt_Interval = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_Configure = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_OpenLocation = new System.Windows.Forms.Button();
            this.Btn_Start_VAL = new System.Windows.Forms.Button();
            this.btn_stop_val = new System.Windows.Forms.Button();
            this.txt_program_val = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Browse_val = new System.Windows.Forms.Button();
            this.Btn_Start_Prod = new System.Windows.Forms.Button();
            this.btn_stop_prod = new System.Windows.Forms.Button();
            this.txt_program_prod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Browse_PROD = new System.Windows.Forms.Button();
            this.btn_open_val_location = new System.Windows.Forms.Button();
            this.btn_open_location = new System.Windows.Forms.Button();
            this.lbl_interval_val = new System.Windows.Forms.Label();
            this.txt_interval_val = new System.Windows.Forms.TextBox();
            this.lbl_interval_prod = new System.Windows.Forms.Label();
            this.txt_interval_prod = new System.Windows.Forms.TextBox();
            this.chk_SAT = new System.Windows.Forms.CheckBox();
            this.chk_Val = new System.Windows.Forms.CheckBox();
            this.chk_Prod = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Lbl_Max_Time_Idel_Run = new System.Windows.Forms.Label();
            this.Txt_Max_ideal_run = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Log
            // 
            this.txt_Log.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_Log.Location = new System.Drawing.Point(0, 150);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Log.Size = new System.Drawing.Size(959, 126);
            this.txt_Log.TabIndex = 30;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(688, 10);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 5;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(769, 10);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 6;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // txt_Program
            // 
            this.txt_Program.Location = new System.Drawing.Point(68, 12);
            this.txt_Program.Name = "txt_Program";
            this.txt_Program.Size = new System.Drawing.Size(386, 20);
            this.txt_Program.TabIndex = 1;
            // 
            // lbl_Program
            // 
            this.lbl_Program.AutoSize = true;
            this.lbl_Program.Location = new System.Drawing.Point(12, 15);
            this.lbl_Program.Name = "lbl_Program";
            this.lbl_Program.Size = new System.Drawing.Size(34, 13);
            this.lbl_Program.TabIndex = 0;
            this.lbl_Program.Text = "SAT :";
            // 
            // lbl_Internval
            // 
            this.lbl_Internval.AutoSize = true;
            this.lbl_Internval.Location = new System.Drawing.Point(460, 15);
            this.lbl_Internval.Name = "lbl_Internval";
            this.lbl_Internval.Size = new System.Drawing.Size(91, 13);
            this.lbl_Internval.TabIndex = 2;
            this.lbl_Internval.Text = "Interval (Minutes):";
            // 
            // txt_Interval
            // 
            this.txt_Interval.Location = new System.Drawing.Point(557, 12);
            this.txt_Interval.MaxLength = 2;
            this.txt_Interval.Name = "txt_Interval";
            this.txt_Interval.Size = new System.Drawing.Size(44, 20);
            this.txt_Interval.TabIndex = 3;
            this.txt_Interval.Text = "5";
            this.txt_Interval.TextChanged += new System.EventHandler(this.txt_Interval_TextChanged);
            this.txt_Interval.Leave += new System.EventHandler(this.on_focus_leave);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(607, 10);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 4;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // btn_Configure
            // 
            this.btn_Configure.Location = new System.Drawing.Point(615, 96);
            this.btn_Configure.Name = "btn_Configure";
            this.btn_Configure.Size = new System.Drawing.Size(154, 23);
            this.btn_Configure.TabIndex = 28;
            this.btn_Configure.Text = "Configure for Autostart up";
            this.btn_Configure.UseVisualStyleBackColor = true;
            this.btn_Configure.Click += new System.EventHandler(this.btn_Configure_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.Location = new System.Drawing.Point(775, 96);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(168, 23);
            this.btn_Modify.TabIndex = 29;
            this.btn_Modify.Text = "Modify Autostart up";
            this.btn_Modify.UseVisualStyleBackColor = true;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_OpenLocation
            // 
            this.btn_OpenLocation.Location = new System.Drawing.Point(850, 10);
            this.btn_OpenLocation.Name = "btn_OpenLocation";
            this.btn_OpenLocation.Size = new System.Drawing.Size(93, 23);
            this.btn_OpenLocation.TabIndex = 7;
            this.btn_OpenLocation.Text = "Explore";
            this.btn_OpenLocation.UseVisualStyleBackColor = true;
            this.btn_OpenLocation.Click += new System.EventHandler(this.btn_OpenLocation_Click);
            // 
            // Btn_Start_VAL
            // 
            this.Btn_Start_VAL.Location = new System.Drawing.Point(688, 39);
            this.Btn_Start_VAL.Name = "Btn_Start_VAL";
            this.Btn_Start_VAL.Size = new System.Drawing.Size(75, 23);
            this.Btn_Start_VAL.TabIndex = 13;
            this.Btn_Start_VAL.Text = "Start";
            this.Btn_Start_VAL.UseVisualStyleBackColor = true;
            this.Btn_Start_VAL.Click += new System.EventHandler(this.btn_Start_val_Click);
            // 
            // btn_stop_val
            // 
            this.btn_stop_val.Location = new System.Drawing.Point(769, 39);
            this.btn_stop_val.Name = "btn_stop_val";
            this.btn_stop_val.Size = new System.Drawing.Size(75, 23);
            this.btn_stop_val.TabIndex = 14;
            this.btn_stop_val.Text = "Stop";
            this.btn_stop_val.UseVisualStyleBackColor = true;
            this.btn_stop_val.Click += new System.EventHandler(this.btn_Stop_Val_Click);
            // 
            // txt_program_val
            // 
            this.txt_program_val.Location = new System.Drawing.Point(68, 41);
            this.txt_program_val.Name = "txt_program_val";
            this.txt_program_val.Size = new System.Drawing.Size(386, 20);
            this.txt_program_val.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "VAL :";
            // 
            // btn_Browse_val
            // 
            this.btn_Browse_val.Location = new System.Drawing.Point(607, 39);
            this.btn_Browse_val.Name = "btn_Browse_val";
            this.btn_Browse_val.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse_val.TabIndex = 12;
            this.btn_Browse_val.Text = "Browse";
            this.btn_Browse_val.UseVisualStyleBackColor = true;
            this.btn_Browse_val.Click += new System.EventHandler(this.btn_Browse_val_Click);
            // 
            // Btn_Start_Prod
            // 
            this.Btn_Start_Prod.Location = new System.Drawing.Point(688, 68);
            this.Btn_Start_Prod.Name = "Btn_Start_Prod";
            this.Btn_Start_Prod.Size = new System.Drawing.Size(75, 23);
            this.Btn_Start_Prod.TabIndex = 21;
            this.Btn_Start_Prod.Text = "Start";
            this.Btn_Start_Prod.UseVisualStyleBackColor = true;
            this.Btn_Start_Prod.Click += new System.EventHandler(this.btn_Start_prod_Click);
            // 
            // btn_stop_prod
            // 
            this.btn_stop_prod.Location = new System.Drawing.Point(769, 68);
            this.btn_stop_prod.Name = "btn_stop_prod";
            this.btn_stop_prod.Size = new System.Drawing.Size(75, 23);
            this.btn_stop_prod.TabIndex = 22;
            this.btn_stop_prod.Text = "Stop";
            this.btn_stop_prod.UseVisualStyleBackColor = true;
            this.btn_stop_prod.Click += new System.EventHandler(this.btn_Stop_Prod_Click);
            // 
            // txt_program_prod
            // 
            this.txt_program_prod.Location = new System.Drawing.Point(68, 70);
            this.txt_program_prod.Name = "txt_program_prod";
            this.txt_program_prod.Size = new System.Drawing.Size(386, 20);
            this.txt_program_prod.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "PROD :";
            // 
            // btn_Browse_PROD
            // 
            this.btn_Browse_PROD.Location = new System.Drawing.Point(607, 68);
            this.btn_Browse_PROD.Name = "btn_Browse_PROD";
            this.btn_Browse_PROD.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse_PROD.TabIndex = 20;
            this.btn_Browse_PROD.Text = "Browse";
            this.btn_Browse_PROD.UseVisualStyleBackColor = true;
            this.btn_Browse_PROD.Click += new System.EventHandler(this.btn_Browse_prod_Click);
            // 
            // btn_open_val_location
            // 
            this.btn_open_val_location.Location = new System.Drawing.Point(850, 39);
            this.btn_open_val_location.Name = "btn_open_val_location";
            this.btn_open_val_location.Size = new System.Drawing.Size(93, 23);
            this.btn_open_val_location.TabIndex = 15;
            this.btn_open_val_location.Text = "Explore";
            this.btn_open_val_location.UseVisualStyleBackColor = true;
            this.btn_open_val_location.Click += new System.EventHandler(this.btn_OpenLocation_VAL_Click);
            // 
            // btn_open_location
            // 
            this.btn_open_location.Location = new System.Drawing.Point(850, 68);
            this.btn_open_location.Name = "btn_open_location";
            this.btn_open_location.Size = new System.Drawing.Size(93, 23);
            this.btn_open_location.TabIndex = 23;
            this.btn_open_location.Text = "Explore";
            this.btn_open_location.UseVisualStyleBackColor = true;
            this.btn_open_location.Click += new System.EventHandler(this.btn_OpenLocation_PROD_Click);
            // 
            // lbl_interval_val
            // 
            this.lbl_interval_val.AutoSize = true;
            this.lbl_interval_val.Location = new System.Drawing.Point(460, 44);
            this.lbl_interval_val.Name = "lbl_interval_val";
            this.lbl_interval_val.Size = new System.Drawing.Size(91, 13);
            this.lbl_interval_val.TabIndex = 10;
            this.lbl_interval_val.Text = "Interval (Minutes):";
            // 
            // txt_interval_val
            // 
            this.txt_interval_val.Location = new System.Drawing.Point(557, 41);
            this.txt_interval_val.MaxLength = 2;
            this.txt_interval_val.Name = "txt_interval_val";
            this.txt_interval_val.Size = new System.Drawing.Size(44, 20);
            this.txt_interval_val.TabIndex = 11;
            this.txt_interval_val.Text = "5";
            this.txt_interval_val.TextChanged += new System.EventHandler(this.txt_Interval_TextChanged);
            this.txt_interval_val.Leave += new System.EventHandler(this.on_focus_leave);
            // 
            // lbl_interval_prod
            // 
            this.lbl_interval_prod.AutoSize = true;
            this.lbl_interval_prod.Location = new System.Drawing.Point(460, 73);
            this.lbl_interval_prod.Name = "lbl_interval_prod";
            this.lbl_interval_prod.Size = new System.Drawing.Size(91, 13);
            this.lbl_interval_prod.TabIndex = 18;
            this.lbl_interval_prod.Text = "Interval (Minutes):";
            // 
            // txt_interval_prod
            // 
            this.txt_interval_prod.Location = new System.Drawing.Point(557, 70);
            this.txt_interval_prod.MaxLength = 2;
            this.txt_interval_prod.Name = "txt_interval_prod";
            this.txt_interval_prod.Size = new System.Drawing.Size(44, 20);
            this.txt_interval_prod.TabIndex = 19;
            this.txt_interval_prod.Text = "5";
            this.txt_interval_prod.TextChanged += new System.EventHandler(this.txt_Interval_TextChanged);
            this.txt_interval_prod.Leave += new System.EventHandler(this.on_focus_leave);
            // 
            // chk_SAT
            // 
            this.chk_SAT.AutoSize = true;
            this.chk_SAT.Location = new System.Drawing.Point(263, 100);
            this.chk_SAT.Name = "chk_SAT";
            this.chk_SAT.Size = new System.Drawing.Size(47, 17);
            this.chk_SAT.TabIndex = 25;
            this.chk_SAT.Text = "SAT";
            this.chk_SAT.UseVisualStyleBackColor = true;
            // 
            // chk_Val
            // 
            this.chk_Val.AutoSize = true;
            this.chk_Val.Location = new System.Drawing.Point(316, 100);
            this.chk_Val.Name = "chk_Val";
            this.chk_Val.Size = new System.Drawing.Size(46, 17);
            this.chk_Val.TabIndex = 26;
            this.chk_Val.Text = "VAL";
            this.chk_Val.UseVisualStyleBackColor = true;
            // 
            // chk_Prod
            // 
            this.chk_Prod.AutoSize = true;
            this.chk_Prod.Location = new System.Drawing.Point(368, 100);
            this.chk_Prod.Name = "chk_Prod";
            this.chk_Prod.Size = new System.Drawing.Size(57, 17);
            this.chk_Prod.TabIndex = 27;
            this.chk_Prod.Text = "PROD";
            this.chk_Prod.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Select for Run Automatically on windows startup : -";
            // 
            // Lbl_Max_Time_Idel_Run
            // 
            this.Lbl_Max_Time_Idel_Run.AutoSize = true;
            this.Lbl_Max_Time_Idel_Run.Location = new System.Drawing.Point(554, 128);
            this.Lbl_Max_Time_Idel_Run.Name = "Lbl_Max_Time_Idel_Run";
            this.Lbl_Max_Time_Idel_Run.Size = new System.Drawing.Size(149, 13);
            this.Lbl_Max_Time_Idel_Run.TabIndex = 18;
            this.Lbl_Max_Time_Idel_Run.Text = "Maximum Ideal Run (Minutes):";
            // 
            // Txt_Max_ideal_run
            // 
            this.Txt_Max_ideal_run.Location = new System.Drawing.Point(709, 125);
            this.Txt_Max_ideal_run.MaxLength = 2;
            this.Txt_Max_ideal_run.Name = "Txt_Max_ideal_run";
            this.Txt_Max_ideal_run.Size = new System.Drawing.Size(44, 20);
            this.Txt_Max_ideal_run.TabIndex = 19;
            this.Txt_Max_ideal_run.Text = "5";
            // 
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 276);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chk_Prod);
            this.Controls.Add(this.chk_Val);
            this.Controls.Add(this.chk_SAT);
            this.Controls.Add(this.btn_open_location);
            this.Controls.Add(this.btn_open_val_location);
            this.Controls.Add(this.btn_OpenLocation);
            this.Controls.Add(this.btn_Modify);
            this.Controls.Add(this.btn_Configure);
            this.Controls.Add(this.btn_Browse_PROD);
            this.Controls.Add(this.btn_Browse_val);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.Txt_Max_ideal_run);
            this.Controls.Add(this.txt_interval_prod);
            this.Controls.Add(this.Lbl_Max_Time_Idel_Run);
            this.Controls.Add(this.lbl_interval_prod);
            this.Controls.Add(this.txt_interval_val);
            this.Controls.Add(this.lbl_interval_val);
            this.Controls.Add(this.txt_Interval);
            this.Controls.Add(this.lbl_Internval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Program);
            this.Controls.Add(this.txt_program_prod);
            this.Controls.Add(this.txt_program_val);
            this.Controls.Add(this.txt_Program);
            this.Controls.Add(this.btn_stop_prod);
            this.Controls.Add(this.Btn_Start_Prod);
            this.Controls.Add(this.btn_stop_val);
            this.Controls.Add(this.Btn_Start_VAL);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.txt_Log);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scheduler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIMS | Scheduler - Pareshkumar Sharma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.Scheduler_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.TextBox txt_Program;
        private System.Windows.Forms.Label lbl_Program;
        private System.Windows.Forms.Label lbl_Internval;
        private System.Windows.Forms.TextBox txt_Interval;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_Configure;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_OpenLocation;
        private System.Windows.Forms.Button Btn_Start_VAL;
        private System.Windows.Forms.Button btn_stop_val;
        private System.Windows.Forms.TextBox txt_program_val;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Browse_val;
        private System.Windows.Forms.Button Btn_Start_Prod;
        private System.Windows.Forms.Button btn_stop_prod;
        private System.Windows.Forms.TextBox txt_program_prod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Browse_PROD;
        private System.Windows.Forms.Button btn_open_val_location;
        private System.Windows.Forms.Button btn_open_location;
        private System.Windows.Forms.Label lbl_interval_val;
        private System.Windows.Forms.TextBox txt_interval_val;
        private System.Windows.Forms.Label lbl_interval_prod;
        private System.Windows.Forms.TextBox txt_interval_prod;
        private System.Windows.Forms.CheckBox chk_SAT;
        private System.Windows.Forms.CheckBox chk_Val;
        private System.Windows.Forms.CheckBox chk_Prod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lbl_Max_Time_Idel_Run;
        private System.Windows.Forms.TextBox Txt_Max_ideal_run;
    }
}

