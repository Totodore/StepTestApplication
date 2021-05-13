
namespace StepTestData1
{
    partial class AddParticipant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddParticipant));
            this.Title = new MaterialSkin.Controls.MaterialLabel();
            this.NewParticipantBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ImportParticipantBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.AddedParticipants = new System.Windows.Forms.ListView();
            this.UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Age = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserSex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartSessionBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.Back = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Step15 = new MaterialSkin.Controls.MaterialRadioButton();
            this.Step20 = new MaterialSkin.Controls.MaterialRadioButton();
            this.Step25 = new MaterialSkin.Controls.MaterialRadioButton();
            this.Step30 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Depth = 0;
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Roboto", 11F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.MouseState = MaterialSkin.MouseState.HOVER;
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(800, 81);
            this.Title.TabIndex = 4;
            this.Title.Text = "Add participants to the test";
            this.Title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // NewParticipantBtn
            // 
            this.NewParticipantBtn.Depth = 0;
            this.NewParticipantBtn.Location = new System.Drawing.Point(498, 132);
            this.NewParticipantBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewParticipantBtn.Name = "NewParticipantBtn";
            this.NewParticipantBtn.Primary = true;
            this.NewParticipantBtn.Size = new System.Drawing.Size(200, 41);
            this.NewParticipantBtn.TabIndex = 5;
            this.NewParticipantBtn.Text = "New participant";
            this.NewParticipantBtn.UseVisualStyleBackColor = true;
            this.NewParticipantBtn.Click += new System.EventHandler(this.NewParticipantBtn_Click);
            // 
            // ImportParticipantBtn
            // 
            this.ImportParticipantBtn.Depth = 0;
            this.ImportParticipantBtn.Location = new System.Drawing.Point(146, 132);
            this.ImportParticipantBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ImportParticipantBtn.Name = "ImportParticipantBtn";
            this.ImportParticipantBtn.Primary = true;
            this.ImportParticipantBtn.Size = new System.Drawing.Size(200, 41);
            this.ImportParticipantBtn.TabIndex = 6;
            this.ImportParticipantBtn.Text = "Import a list";
            this.ImportParticipantBtn.UseVisualStyleBackColor = true;
            this.ImportParticipantBtn.Click += new System.EventHandler(this.ImportParticipantBtn_Click);
            // 
            // AddedParticipants
            // 
            this.AddedParticipants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserName,
            this.Age,
            this.UserSex});
            this.AddedParticipants.HideSelection = false;
            this.AddedParticipants.Location = new System.Drawing.Point(177, 239);
            this.AddedParticipants.Name = "AddedParticipants";
            this.AddedParticipants.ShowGroups = false;
            this.AddedParticipants.Size = new System.Drawing.Size(308, 137);
            this.AddedParticipants.TabIndex = 7;
            this.AddedParticipants.UseCompatibleStateImageBehavior = false;
            this.AddedParticipants.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddedParticipants_KeyUp);
            // 
            // UserName
            // 
            this.UserName.Tag = "Name";
            this.UserName.Text = "Name";
            // 
            // Age
            // 
            this.Age.Tag = "Age";
            this.Age.Text = "Age";
            // 
            // UserSex
            // 
            this.UserSex.Tag = "Sex";
            this.UserSex.Text = "Sex";
            // 
            // StartSessionBtn
            // 
            this.StartSessionBtn.Depth = 0;
            this.StartSessionBtn.Enabled = false;
            this.StartSessionBtn.Location = new System.Drawing.Point(532, 397);
            this.StartSessionBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartSessionBtn.Name = "StartSessionBtn";
            this.StartSessionBtn.Primary = true;
            this.StartSessionBtn.Size = new System.Drawing.Size(256, 41);
            this.StartSessionBtn.TabIndex = 8;
            this.StartSessionBtn.Text = "Start the test session";
            this.StartSessionBtn.UseVisualStyleBackColor = true;
            this.StartSessionBtn.Click += new System.EventHandler(this.StartSessionBtn_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(173, 194);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(116, 24);
            this.materialLabel1.TabIndex = 9;
            this.materialLabel1.Text = "Participants:";
            // 
            // Back
            // 
            this.Back.Depth = 0;
            this.Back.Location = new System.Drawing.Point(12, 12);
            this.Back.MouseState = MaterialSkin.MouseState.HOVER;
            this.Back.Name = "Back";
            this.Back.Primary = true;
            this.Back.Size = new System.Drawing.Size(94, 39);
            this.Back.TabIndex = 11;
            this.Back.Text = "< Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Step15
            // 
            this.Step15.AutoSize = true;
            this.Step15.Checked = true;
            this.Step15.Depth = 0;
            this.Step15.Font = new System.Drawing.Font("Roboto", 10F);
            this.Step15.Location = new System.Drawing.Point(554, 221);
            this.Step15.Margin = new System.Windows.Forms.Padding(0);
            this.Step15.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Step15.MouseState = MaterialSkin.MouseState.HOVER;
            this.Step15.Name = "Step15";
            this.Step15.Ripple = true;
            this.Step15.Size = new System.Drawing.Size(73, 30);
            this.Step15.TabIndex = 12;
            this.Step15.TabStop = true;
            this.Step15.Tag = "15";
            this.Step15.Text = "15cm";
            this.Step15.UseVisualStyleBackColor = true;
            // 
            // Step20
            // 
            this.Step20.AutoSize = true;
            this.Step20.Depth = 0;
            this.Step20.Font = new System.Drawing.Font("Roboto", 10F);
            this.Step20.Location = new System.Drawing.Point(554, 260);
            this.Step20.Margin = new System.Windows.Forms.Padding(0);
            this.Step20.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Step20.MouseState = MaterialSkin.MouseState.HOVER;
            this.Step20.Name = "Step20";
            this.Step20.Ripple = true;
            this.Step20.Size = new System.Drawing.Size(73, 30);
            this.Step20.TabIndex = 13;
            this.Step20.Tag = "20";
            this.Step20.Text = "20cm";
            this.Step20.UseVisualStyleBackColor = true;
            // 
            // Step25
            // 
            this.Step25.AutoSize = true;
            this.Step25.Depth = 0;
            this.Step25.Font = new System.Drawing.Font("Roboto", 10F);
            this.Step25.Location = new System.Drawing.Point(554, 304);
            this.Step25.Margin = new System.Windows.Forms.Padding(0);
            this.Step25.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Step25.MouseState = MaterialSkin.MouseState.HOVER;
            this.Step25.Name = "Step25";
            this.Step25.Ripple = true;
            this.Step25.Size = new System.Drawing.Size(73, 30);
            this.Step25.TabIndex = 14;
            this.Step25.Tag = "25";
            this.Step25.Text = "25cm";
            this.Step25.UseVisualStyleBackColor = true;
            // 
            // Step30
            // 
            this.Step30.AutoSize = true;
            this.Step30.Depth = 0;
            this.Step30.Font = new System.Drawing.Font("Roboto", 10F);
            this.Step30.Location = new System.Drawing.Point(554, 345);
            this.Step30.Margin = new System.Windows.Forms.Padding(0);
            this.Step30.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Step30.MouseState = MaterialSkin.MouseState.HOVER;
            this.Step30.Name = "Step30";
            this.Step30.Ripple = true;
            this.Step30.Size = new System.Drawing.Size(73, 30);
            this.Step30.TabIndex = 15;
            this.Step30.Tag = "30";
            this.Step30.Text = "30cm";
            this.Step30.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(516, 193);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(92, 24);
            this.materialLabel2.TabIndex = 16;
            this.materialLabel2.Text = "Step size:";
            // 
            // AddParticipant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.Step30);
            this.Controls.Add(this.Step25);
            this.Controls.Add(this.Step20);
            this.Controls.Add(this.Step15);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.StartSessionBtn);
            this.Controls.Add(this.AddedParticipants);
            this.Controls.Add(this.ImportParticipantBtn);
            this.Controls.Add(this.NewParticipantBtn);
            this.Controls.Add(this.Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddParticipant";
            this.Text = "Add Participants";
            this.Load += new System.EventHandler(this.AddParticipant_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel Title;
        private MaterialSkin.Controls.MaterialRaisedButton NewParticipantBtn;
        private MaterialSkin.Controls.MaterialRaisedButton ImportParticipantBtn;
        private System.Windows.Forms.ListView AddedParticipants;
        private MaterialSkin.Controls.MaterialRaisedButton StartSessionBtn;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialRaisedButton Back;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader Age;
        private System.Windows.Forms.ColumnHeader UserSex;
        private MaterialSkin.Controls.MaterialRadioButton Step15;
        private MaterialSkin.Controls.MaterialRadioButton Step20;
        private MaterialSkin.Controls.MaterialRadioButton Step25;
        private MaterialSkin.Controls.MaterialRadioButton Step30;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}