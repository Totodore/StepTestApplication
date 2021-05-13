
namespace StepTestData1
{
    partial class TestSession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestSession));
            this.TabView = new System.Windows.Forms.TabControl();
            this.Back = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // TabView
            // 
            this.TabView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabView.Location = new System.Drawing.Point(0, 0);
            this.TabView.Name = "TabView";
            this.TabView.SelectedIndex = 0;
            this.TabView.Size = new System.Drawing.Size(800, 450);
            this.TabView.TabIndex = 0;
            this.TabView.SelectedIndexChanged += new System.EventHandler(this.TabView_SelectedIndexChanged);
            // 
            // Back
            // 
            this.Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Back.Depth = 0;
            this.Back.Location = new System.Drawing.Point(12, 400);
            this.Back.MouseState = MaterialSkin.MouseState.HOVER;
            this.Back.Name = "Back";
            this.Back.Primary = true;
            this.Back.Size = new System.Drawing.Size(94, 39);
            this.Back.TabIndex = 11;
            this.Back.Text = "< Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // TestSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.TabView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestSession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Session";
            this.Load += new System.EventHandler(this.TestSession_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabView;
        private MaterialSkin.Controls.MaterialRaisedButton Back;
    }
}