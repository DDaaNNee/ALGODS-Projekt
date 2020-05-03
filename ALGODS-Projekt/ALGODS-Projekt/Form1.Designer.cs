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
            this.lbl_CurrentFloorNumber = new System.Windows.Forms.Label();
            this.lbl_CurrentFloorNumber_UPDATE = new System.Windows.Forms.Label();
            this.lbl_ElevatorState = new System.Windows.Forms.Label();
            this.lbl_ElevatorState_UPDATE = new System.Windows.Forms.Label();
            this.lbl_ElapsedTime = new System.Windows.Forms.Label();
            this.lbl_ElapsedTime_UPDATE = new System.Windows.Forms.Label();
            this.lbl_TotalNumOfPassengers = new System.Windows.Forms.Label();
            this.lbl_TotalNumOfPassengers_UPDATE = new System.Windows.Forms.Label();
            this.lbl_TotalTime = new System.Windows.Forms.Label();
            this.lbl_TotalTime_UPDATE = new System.Windows.Forms.Label();
            this.lbl_AverageWaitTime = new System.Windows.Forms.Label();
            this.lbl_AverageWaitTime_UPDATE = new System.Windows.Forms.Label();
            this.lbl_AverageCompTime = new System.Windows.Forms.Label();
            this.lbl_AverageCompTime_UPDATE = new System.Windows.Forms.Label();
            this.lbl_LeastTimeTaken = new System.Windows.Forms.Label();
            this.lbl_LeastTimeTaken_UPDATE = new System.Windows.Forms.Label();
            this.lbl_HighestTimeTaken = new System.Windows.Forms.Label();
            this.lbl_HighestTimeTaken_UPDATE = new System.Windows.Forms.Label();
            this.lb_PeopleOnFloors = new System.Windows.Forms.ListBox();
            this.lbl_ChooseNumOfFloors = new System.Windows.Forms.Label();
            this.cb_numOfFloors = new System.Windows.Forms.ComboBox();
            this.lb_PeopleInElevator = new System.Windows.Forms.ListBox();
            this.lbl_PeopleInElevator = new System.Windows.Forms.Label();
            this.lbl_PeopleOnFloors = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(12, 475);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(235, 65);
            this.btn_play.TabIndex = 0;
            this.btn_play.Text = "Select a file";
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
            this.btn_Go.Text = "Start";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbl_CurrentFloorNumber
            // 
            this.lbl_CurrentFloorNumber.AutoSize = true;
            this.lbl_CurrentFloorNumber.Location = new System.Drawing.Point(12, 191);
            this.lbl_CurrentFloorNumber.Name = "lbl_CurrentFloorNumber";
            this.lbl_CurrentFloorNumber.Size = new System.Drawing.Size(67, 13);
            this.lbl_CurrentFloorNumber.TabIndex = 3;
            this.lbl_CurrentFloorNumber.Text = "Current floor:";
            // 
            // lbl_CurrentFloorNumber_UPDATE
            // 
            this.lbl_CurrentFloorNumber_UPDATE.AutoSize = true;
            this.lbl_CurrentFloorNumber_UPDATE.Location = new System.Drawing.Point(89, 191);
            this.lbl_CurrentFloorNumber_UPDATE.Name = "lbl_CurrentFloorNumber_UPDATE";
            this.lbl_CurrentFloorNumber_UPDATE.Size = new System.Drawing.Size(74, 13);
            this.lbl_CurrentFloorNumber_UPDATE.TabIndex = 4;
            this.lbl_CurrentFloorNumber_UPDATE.Text = "(Floor number)";
            // 
            // lbl_ElevatorState
            // 
            this.lbl_ElevatorState.AutoSize = true;
            this.lbl_ElevatorState.Location = new System.Drawing.Point(12, 211);
            this.lbl_ElevatorState.Name = "lbl_ElevatorState";
            this.lbl_ElevatorState.Size = new System.Drawing.Size(75, 13);
            this.lbl_ElevatorState.TabIndex = 5;
            this.lbl_ElevatorState.Text = "Elevator state:";
            // 
            // lbl_ElevatorState_UPDATE
            // 
            this.lbl_ElevatorState_UPDATE.AutoSize = true;
            this.lbl_ElevatorState_UPDATE.Location = new System.Drawing.Point(89, 211);
            this.lbl_ElevatorState_UPDATE.Name = "lbl_ElevatorState_UPDATE";
            this.lbl_ElevatorState_UPDATE.Size = new System.Drawing.Size(196, 13);
            this.lbl_ElevatorState_UPDATE.TabIndex = 6;
            this.lbl_ElevatorState_UPDATE.Text = "(GOINGUP, GOINGDOWN, NEUTRAL)";
            // 
            // lbl_ElapsedTime
            // 
            this.lbl_ElapsedTime.AutoSize = true;
            this.lbl_ElapsedTime.Location = new System.Drawing.Point(12, 231);
            this.lbl_ElapsedTime.Name = "lbl_ElapsedTime";
            this.lbl_ElapsedTime.Size = new System.Drawing.Size(70, 13);
            this.lbl_ElapsedTime.TabIndex = 7;
            this.lbl_ElapsedTime.Text = "Elapsed time:";
            // 
            // lbl_ElapsedTime_UPDATE
            // 
            this.lbl_ElapsedTime_UPDATE.AutoSize = true;
            this.lbl_ElapsedTime_UPDATE.Location = new System.Drawing.Point(89, 231);
            this.lbl_ElapsedTime_UPDATE.Name = "lbl_ElapsedTime_UPDATE";
            this.lbl_ElapsedTime_UPDATE.Size = new System.Drawing.Size(73, 13);
            this.lbl_ElapsedTime_UPDATE.TabIndex = 8;
            this.lbl_ElapsedTime_UPDATE.Text = "(Elapsed time)";
            // 
            // lbl_TotalNumOfPassengers
            // 
            this.lbl_TotalNumOfPassengers.AutoSize = true;
            this.lbl_TotalNumOfPassengers.Location = new System.Drawing.Point(315, 130);
            this.lbl_TotalNumOfPassengers.Name = "lbl_TotalNumOfPassengers";
            this.lbl_TotalNumOfPassengers.Size = new System.Drawing.Size(141, 13);
            this.lbl_TotalNumOfPassengers.TabIndex = 9;
            this.lbl_TotalNumOfPassengers.Text = "Total number of passengers:";
            // 
            // lbl_TotalNumOfPassengers_UPDATE
            // 
            this.lbl_TotalNumOfPassengers_UPDATE.AutoSize = true;
            this.lbl_TotalNumOfPassengers_UPDATE.Location = new System.Drawing.Point(462, 130);
            this.lbl_TotalNumOfPassengers_UPDATE.Name = "lbl_TotalNumOfPassengers_UPDATE";
            this.lbl_TotalNumOfPassengers_UPDATE.Size = new System.Drawing.Size(119, 13);
            this.lbl_TotalNumOfPassengers_UPDATE.TabIndex = 10;
            this.lbl_TotalNumOfPassengers_UPDATE.Text = "(Number of passengers)";
            // 
            // lbl_TotalTime
            // 
            this.lbl_TotalTime.AutoSize = true;
            this.lbl_TotalTime.Location = new System.Drawing.Point(315, 156);
            this.lbl_TotalTime.Name = "lbl_TotalTime";
            this.lbl_TotalTime.Size = new System.Drawing.Size(56, 13);
            this.lbl_TotalTime.TabIndex = 20;
            this.lbl_TotalTime.Text = "Total time:";
            // 
            // lbl_TotalTime_UPDATE
            // 
            this.lbl_TotalTime_UPDATE.AutoSize = true;
            this.lbl_TotalTime_UPDATE.Location = new System.Drawing.Point(462, 156);
            this.lbl_TotalTime_UPDATE.Name = "lbl_TotalTime_UPDATE";
            this.lbl_TotalTime_UPDATE.Size = new System.Drawing.Size(59, 13);
            this.lbl_TotalTime_UPDATE.TabIndex = 23;
            this.lbl_TotalTime_UPDATE.Text = "(Total time)";
            // 
            // lbl_AverageWaitTime
            // 
            this.lbl_AverageWaitTime.AutoSize = true;
            this.lbl_AverageWaitTime.Location = new System.Drawing.Point(315, 182);
            this.lbl_AverageWaitTime.Name = "lbl_AverageWaitTime";
            this.lbl_AverageWaitTime.Size = new System.Drawing.Size(111, 13);
            this.lbl_AverageWaitTime.TabIndex = 24;
            this.lbl_AverageWaitTime.Text = "Average waiting time: ";
            // 
            // lbl_AverageWaitTime_UPDATE
            // 
            this.lbl_AverageWaitTime_UPDATE.AutoSize = true;
            this.lbl_AverageWaitTime_UPDATE.Location = new System.Drawing.Point(462, 182);
            this.lbl_AverageWaitTime_UPDATE.Name = "lbl_AverageWaitTime_UPDATE";
            this.lbl_AverageWaitTime_UPDATE.Size = new System.Drawing.Size(111, 13);
            this.lbl_AverageWaitTime_UPDATE.TabIndex = 25;
            this.lbl_AverageWaitTime_UPDATE.Text = "(Average waiting time)";
            // 
            // lbl_AverageCompTime
            // 
            this.lbl_AverageCompTime.AutoSize = true;
            this.lbl_AverageCompTime.Location = new System.Drawing.Point(315, 211);
            this.lbl_AverageCompTime.Name = "lbl_AverageCompTime";
            this.lbl_AverageCompTime.Size = new System.Drawing.Size(129, 13);
            this.lbl_AverageCompTime.TabIndex = 26;
            this.lbl_AverageCompTime.Text = "Average completion time: ";
            // 
            // lbl_AverageCompTime_UPDATE
            // 
            this.lbl_AverageCompTime_UPDATE.AutoSize = true;
            this.lbl_AverageCompTime_UPDATE.Location = new System.Drawing.Point(462, 211);
            this.lbl_AverageCompTime_UPDATE.Name = "lbl_AverageCompTime_UPDATE";
            this.lbl_AverageCompTime_UPDATE.Size = new System.Drawing.Size(129, 13);
            this.lbl_AverageCompTime_UPDATE.TabIndex = 27;
            this.lbl_AverageCompTime_UPDATE.Text = "(Average completion time)";
            // 
            // lbl_LeastTimeTaken
            // 
            this.lbl_LeastTimeTaken.AutoSize = true;
            this.lbl_LeastTimeTaken.Location = new System.Drawing.Point(315, 241);
            this.lbl_LeastTimeTaken.Name = "lbl_LeastTimeTaken";
            this.lbl_LeastTimeTaken.Size = new System.Drawing.Size(114, 13);
            this.lbl_LeastTimeTaken.TabIndex = 28;
            this.lbl_LeastTimeTaken.Text = "Least total time taken: ";
            // 
            // lbl_LeastTimeTaken_UPDATE
            // 
            this.lbl_LeastTimeTaken_UPDATE.AutoSize = true;
            this.lbl_LeastTimeTaken_UPDATE.Location = new System.Drawing.Point(464, 241);
            this.lbl_LeastTimeTaken_UPDATE.Name = "lbl_LeastTimeTaken_UPDATE";
            this.lbl_LeastTimeTaken_UPDATE.Size = new System.Drawing.Size(66, 13);
            this.lbl_LeastTimeTaken_UPDATE.TabIndex = 29;
            this.lbl_LeastTimeTaken_UPDATE.Text = "(Time taken)";
            // 
            // lbl_HighestTimeTaken
            // 
            this.lbl_HighestTimeTaken.AutoSize = true;
            this.lbl_HighestTimeTaken.Location = new System.Drawing.Point(315, 271);
            this.lbl_HighestTimeTaken.Name = "lbl_HighestTimeTaken";
            this.lbl_HighestTimeTaken.Size = new System.Drawing.Size(124, 13);
            this.lbl_HighestTimeTaken.TabIndex = 32;
            this.lbl_HighestTimeTaken.Text = "Highest total time taken: ";
            // 
            // lbl_HighestTimeTaken_UPDATE
            // 
            this.lbl_HighestTimeTaken_UPDATE.AutoSize = true;
            this.lbl_HighestTimeTaken_UPDATE.Location = new System.Drawing.Point(464, 276);
            this.lbl_HighestTimeTaken_UPDATE.Name = "lbl_HighestTimeTaken_UPDATE";
            this.lbl_HighestTimeTaken_UPDATE.Size = new System.Drawing.Size(66, 13);
            this.lbl_HighestTimeTaken_UPDATE.TabIndex = 34;
            this.lbl_HighestTimeTaken_UPDATE.Text = "(Time taken)";
            // 
            // lb_PeopleOnFloors
            // 
            this.lb_PeopleOnFloors.FormattingEnabled = true;
            this.lb_PeopleOnFloors.Location = new System.Drawing.Point(624, 63);
            this.lb_PeopleOnFloors.Name = "lb_PeopleOnFloors";
            this.lb_PeopleOnFloors.Size = new System.Drawing.Size(500, 355);
            this.lb_PeopleOnFloors.TabIndex = 37;
            // 
            // lbl_ChooseNumOfFloors
            // 
            this.lbl_ChooseNumOfFloors.AutoSize = true;
            this.lbl_ChooseNumOfFloors.Location = new System.Drawing.Point(314, 177);
            this.lbl_ChooseNumOfFloors.Name = "lbl_ChooseNumOfFloors";
            this.lbl_ChooseNumOfFloors.Size = new System.Drawing.Size(127, 13);
            this.lbl_ChooseNumOfFloors.TabIndex = 38;
            this.lbl_ChooseNumOfFloors.Text = "Choose number of floors: ";
            // 
            // cb_numOfFloors
            // 
            this.cb_numOfFloors.FormattingEnabled = true;
            this.cb_numOfFloors.Location = new System.Drawing.Point(447, 174);
            this.cb_numOfFloors.Name = "cb_numOfFloors";
            this.cb_numOfFloors.Size = new System.Drawing.Size(121, 21);
            this.cb_numOfFloors.TabIndex = 39;
            // 
            // lb_PeopleInElevator
            // 
            this.lb_PeopleInElevator.FormattingEnabled = true;
            this.lb_PeopleInElevator.Location = new System.Drawing.Point(303, 63);
            this.lb_PeopleInElevator.Name = "lb_PeopleInElevator";
            this.lb_PeopleInElevator.Size = new System.Drawing.Size(270, 17);
            this.lb_PeopleInElevator.TabIndex = 40;
            // 
            // lbl_PeopleInElevator
            // 
            this.lbl_PeopleInElevator.AutoSize = true;
            this.lbl_PeopleInElevator.Location = new System.Drawing.Point(303, 44);
            this.lbl_PeopleInElevator.Name = "lbl_PeopleInElevator";
            this.lbl_PeopleInElevator.Size = new System.Drawing.Size(49, 13);
            this.lbl_PeopleInElevator.TabIndex = 41;
            this.lbl_PeopleInElevator.Text = "Elevator:";
            // 
            // lbl_PeopleOnFloors
            // 
            this.lbl_PeopleOnFloors.AutoSize = true;
            this.lbl_PeopleOnFloors.Location = new System.Drawing.Point(621, 44);
            this.lbl_PeopleOnFloors.Name = "lbl_PeopleOnFloors";
            this.lbl_PeopleOnFloors.Size = new System.Drawing.Size(86, 13);
            this.lbl_PeopleOnFloors.TabIndex = 42;
            this.lbl_PeopleOnFloors.Text = "People on floors:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Floor 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(582, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Floor 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(582, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Floor 3:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(582, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Floor 6:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(582, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Floor 5:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(582, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Floor 4:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(582, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Floor 9:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(582, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Floor 8:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(582, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Floor 7:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(582, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Floor 0:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 552);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_PeopleOnFloors);
            this.Controls.Add(this.lbl_PeopleInElevator);
            this.Controls.Add(this.cb_numOfFloors);
            this.Controls.Add(this.lbl_ChooseNumOfFloors);
            this.Controls.Add(this.lb_PeopleOnFloors);
            this.Controls.Add(this.lbl_HighestTimeTaken_UPDATE);
            this.Controls.Add(this.lbl_HighestTimeTaken);
            this.Controls.Add(this.lbl_LeastTimeTaken_UPDATE);
            this.Controls.Add(this.lbl_LeastTimeTaken);
            this.Controls.Add(this.lbl_AverageCompTime_UPDATE);
            this.Controls.Add(this.lbl_AverageCompTime);
            this.Controls.Add(this.lbl_AverageWaitTime_UPDATE);
            this.Controls.Add(this.lbl_AverageWaitTime);
            this.Controls.Add(this.lbl_TotalTime_UPDATE);
            this.Controls.Add(this.lbl_TotalTime);
            this.Controls.Add(this.lbl_TotalNumOfPassengers_UPDATE);
            this.Controls.Add(this.lbl_TotalNumOfPassengers);
            this.Controls.Add(this.lbl_ElapsedTime_UPDATE);
            this.Controls.Add(this.lbl_ElapsedTime);
            this.Controls.Add(this.lbl_ElevatorState_UPDATE);
            this.Controls.Add(this.lbl_ElevatorState);
            this.Controls.Add(this.lbl_CurrentFloorNumber_UPDATE);
            this.Controls.Add(this.lbl_CurrentFloorNumber);
            this.Controls.Add(this.btn_Go);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.lb_PeopleInElevator);
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
        private System.Windows.Forms.Label lbl_CurrentFloorNumber;
        private System.Windows.Forms.Label lbl_CurrentFloorNumber_UPDATE;
        private System.Windows.Forms.Label lbl_ElevatorState;
        private System.Windows.Forms.Label lbl_ElevatorState_UPDATE;
        private System.Windows.Forms.Label lbl_ElapsedTime;
        private System.Windows.Forms.Label lbl_ElapsedTime_UPDATE;
        private System.Windows.Forms.Label lbl_TotalNumOfPassengers;
        private System.Windows.Forms.Label lbl_TotalNumOfPassengers_UPDATE;
        private System.Windows.Forms.Label lbl_TotalTime;
        private System.Windows.Forms.Label lbl_TotalTime_UPDATE;
        private System.Windows.Forms.Label lbl_AverageWaitTime;
        private System.Windows.Forms.Label lbl_AverageWaitTime_UPDATE;
        private System.Windows.Forms.Label lbl_AverageCompTime;
        private System.Windows.Forms.Label lbl_AverageCompTime_UPDATE;
        private System.Windows.Forms.Label lbl_LeastTimeTaken;
        private System.Windows.Forms.Label lbl_LeastTimeTaken_UPDATE;
        private System.Windows.Forms.Label lbl_HighestTimeTaken;
        private System.Windows.Forms.Label lbl_HighestTimeTaken_UPDATE;
        private System.Windows.Forms.ListBox lb_PeopleOnFloors;
        private System.Windows.Forms.Label lbl_ChooseNumOfFloors;
        private System.Windows.Forms.ComboBox cb_numOfFloors;
        private System.Windows.Forms.ListBox lb_PeopleInElevator;
        private System.Windows.Forms.Label lbl_PeopleInElevator;
        private System.Windows.Forms.Label lbl_PeopleOnFloors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

