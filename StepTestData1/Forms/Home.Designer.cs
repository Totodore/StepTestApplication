
namespace StepTestData1
{
    partial class Home
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.NewSession = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ConsultPrevious = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Title = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // NewSession
            // 
            this.NewSession.Depth = 0;
            this.NewSession.Location = new System.Drawing.Point(450, 220);
            this.NewSession.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewSession.Name = "NewSession";
            this.NewSession.Primary = true;
            this.NewSession.Size = new System.Drawing.Size(304, 45);
            this.NewSession.TabIndex = 1;
            this.NewSession.Text = "Start a new test session";
            this.NewSession.UseVisualStyleBackColor = true;
            this.NewSession.Click += new System.EventHandler(this.NewSession_Click);
            // 
            // ConsultPrevious
            // 
            this.ConsultPrevious.Depth = 0;
            this.ConsultPrevious.Location = new System.Drawing.Point(48, 220);
            this.ConsultPrevious.MouseState = MaterialSkin.MouseState.HOVER;
            this.ConsultPrevious.Name = "ConsultPrevious";
            this.ConsultPrevious.Primary = true;
            this.ConsultPrevious.Size = new System.Drawing.Size(304, 45);
            this.ConsultPrevious.TabIndex = 2;
            this.ConsultPrevious.Text = "Consult previous tests";
            this.ConsultPrevious.UseVisualStyleBackColor = true;
            this.ConsultPrevious.Click += new System.EventHandler(this.ConsultPrevious_Click);
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
            this.Title.TabIndex = 3;
            this.Title.Text = "Step Test Data Application";
            this.Title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.ConsultPrevious);
            this.Controls.Add(this.NewSession);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton NewSession;
        private MaterialSkin.Controls.MaterialRaisedButton ConsultPrevious;
        private MaterialSkin.Controls.MaterialLabel Title;
    }
}

