namespace ALGODS_Projekt
{
    partial class Form1
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
            this.btn_play = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Go = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_CurrentFloorNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_ElevatorState = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_ElapsedTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.lb_PeopleOnFloors = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_numOfFloors = new System.Windows.Forms.ComboBox();
            this.lb_PeopleInElevator = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(12, 475);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(235, 65);
            this.btn_play.TabIndex = 0;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 475);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(235, 65);
            this.button2.TabIndex = 1;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_Go
            // 
            this.btn_Go.Location = new System.Drawing.Point(624, 475);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(235, 65);
            this.btn_Go.TabIndex = 2;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current floor:";
            // 
            // lbl_CurrentFloorNumber
            // 
            this.lbl_CurrentFloorNumber.AutoSize = true;
            this.lbl_CurrentFloorNumber.Location = new System.Drawing.Point(413, 50);
            this.lbl_CurrentFloorNumber.Name = "lbl_CurrentFloorNumber";
            this.lbl_CurrentFloorNumber.Size = new System.Drawing.Size(74, 13);
            this.lbl_CurrentFloorNumber.TabIndex = 4;
            this.lbl_CurrentFloorNumber.Text = "(Floor number)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Elevator state:";
            // 
            // lbl_ElevatorState
            // 
            this.lbl_ElevatorState.AutoSize = true;
            this.lbl_ElevatorState.Location = new System.Drawing.Point(413, 70);
            this.lbl_ElevatorState.Name = "lbl_ElevatorState";
            this.lbl_ElevatorState.Size = new System.Drawing.Size(196, 13);
            this.lbl_ElevatorState.TabIndex = 6;
            this.lbl_ElevatorState.Text = "(GOINGUP, GOINGDOWN, NEUTRAL)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Elapsed time:";
            // 
            // lbl_ElapsedTime
            // 
            this.lbl_ElapsedTime.AutoSize = true;
            this.lbl_ElapsedTime.Location = new System.Drawing.Point(413, 90);
            this.lbl_ElapsedTime.Name = "lbl_ElapsedTime";
            this.lbl_ElapsedTime.Size = new System.Drawing.Size(73, 13);
            this.lbl_ElapsedTime.TabIndex = 8;
            this.lbl_ElapsedTime.Text = "(Elapsed time)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Total number of passengers:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(179, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "(Number of passengers)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(32, 122);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Total time:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(375, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(102, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "UNDER KÖRNING:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(71, 63);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(98, 13);
            this.label20.TabIndex = 22;
            this.label20.Text = "EFTER KÖRNING:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(179, 122);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 13);
            this.label21.TabIndex = 23;
            this.label21.Text = "(Total time)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(32, 148);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(111, 13);
            this.label22.TabIndex = 24;
            this.label22.Text = "Average waiting time: ";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(179, 148);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(111, 13);
            this.label23.TabIndex = 25;
            this.label23.Text = "(Average waiting time)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(32, 177);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(129, 13);
            this.label24.TabIndex = 26;
            this.label24.Text = "Average completion time: ";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(179, 177);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(129, 13);
            this.label25.TabIndex = 27;
            this.label25.Text = "(Average completion time)";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(32, 207);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(114, 13);
            this.label26.TabIndex = 28;
            this.label26.Text = "Least total time taken: ";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(321, 207);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(66, 13);
            this.label27.TabIndex = 29;
            this.label27.Text = "(Time taken)";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(182, 204);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 31;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(32, 237);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(124, 13);
            this.label28.TabIndex = 32;
            this.label28.Text = "Highest total time taken: ";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(182, 234);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 33;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(321, 242);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(66, 13);
            this.label29.TabIndex = 34;
            this.label29.Text = "(Time taken)";
            // 
            // lb_PeopleOnFloors
            // 
            this.lb_PeopleOnFloors.FormattingEnabled = true;
            this.lb_PeopleOnFloors.Location = new System.Drawing.Point(624, 63);
            this.lb_PeopleOnFloors.Name = "lb_PeopleOnFloors";
            this.lb_PeopleOnFloors.Size = new System.Drawing.Size(235, 355);
            this.lb_PeopleOnFloors.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Choose number of floors: ";
            // 
            // cb_numOfFloors
            // 
            this.cb_numOfFloors.FormattingEnabled = true;
            this.cb_numOfFloors.Location = new System.Drawing.Point(182, 330);
            this.cb_numOfFloors.Name = "cb_numOfFloors";
            this.cb_numOfFloors.Size = new System.Drawing.Size(121, 21);
            this.cb_numOfFloors.TabIndex = 39;
            // 
            // lb_PeopleInElevator
            // 
            this.lb_PeopleInElevator.FormattingEnabled = true;
            this.lb_PeopleInElevator.Location = new System.Drawing.Point(425, 158);
            this.lb_PeopleInElevator.Name = "lb_PeopleInElevator";
            this.lb_PeopleInElevator.Size = new System.Drawing.Size(193, 160);
            this.lb_PeopleInElevator.TabIndex = 40;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 552);
            this.Controls.Add(this.lb_PeopleInElevator);
            this.Controls.Add(this.cb_numOfFloors);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_PeopleOnFloors);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_ElapsedTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_ElevatorState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_CurrentFloorNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Go);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_play);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_CurrentFloorNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_ElevatorState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_ElapsedTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ListBox lb_PeopleOnFloors;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_numOfFloors;
        private System.Windows.Forms.ListBox lb_PeopleInElevator;
    }
}

