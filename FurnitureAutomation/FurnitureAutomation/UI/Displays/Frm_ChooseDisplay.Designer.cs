
namespace FurnitureAutomation.UI.Displays
{
    partial class Frm_ChooseDisplay
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
            this.Btn_TextualDisplay = new System.Windows.Forms.Button();
            this.Btn_GridDisplay = new System.Windows.Forms.Button();
            this.Btn_TreeDisplay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_TextualDisplay
            // 
            this.Btn_TextualDisplay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Btn_TextualDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_TextualDisplay.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Btn_TextualDisplay.ForeColor = System.Drawing.Color.White;
            this.Btn_TextualDisplay.Location = new System.Drawing.Point(58, 33);
            this.Btn_TextualDisplay.Name = "Btn_TextualDisplay";
            this.Btn_TextualDisplay.Size = new System.Drawing.Size(198, 36);
            this.Btn_TextualDisplay.TabIndex = 0;
            this.Btn_TextualDisplay.Text = "Textual display";
            this.Btn_TextualDisplay.UseVisualStyleBackColor = false;
            this.Btn_TextualDisplay.Click += new System.EventHandler(this.Btn_TextualDisplay_Click);
            // 
            // Btn_GridDisplay
            // 
            this.Btn_GridDisplay.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Btn_GridDisplay.Location = new System.Drawing.Point(294, 33);
            this.Btn_GridDisplay.Name = "Btn_GridDisplay";
            this.Btn_GridDisplay.Size = new System.Drawing.Size(194, 36);
            this.Btn_GridDisplay.TabIndex = 1;
            this.Btn_GridDisplay.Text = "Datagrid Display";
            this.Btn_GridDisplay.UseVisualStyleBackColor = true;
            this.Btn_GridDisplay.Click += new System.EventHandler(this.Btn_GridDisplay_Click);
            // 
            // Btn_TreeDisplay
            // 
            this.Btn_TreeDisplay.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Btn_TreeDisplay.ForeColor = System.Drawing.Color.DimGray;
            this.Btn_TreeDisplay.Location = new System.Drawing.Point(536, 33);
            this.Btn_TreeDisplay.Name = "Btn_TreeDisplay";
            this.Btn_TreeDisplay.Size = new System.Drawing.Size(202, 36);
            this.Btn_TreeDisplay.TabIndex = 2;
            this.Btn_TreeDisplay.Text = "Tree Display";
            this.Btn_TreeDisplay.UseVisualStyleBackColor = true;
            this.Btn_TreeDisplay.Click += new System.EventHandler(this.Btn_TreeDisplay_Click);
            // 
            // Frm_ChooseDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 105);
            this.Controls.Add(this.Btn_TreeDisplay);
            this.Controls.Add(this.Btn_GridDisplay);
            this.Controls.Add(this.Btn_TextualDisplay);
            this.Name = "Frm_ChooseDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Display";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_TextualDisplay;
        private System.Windows.Forms.Button Btn_GridDisplay;
        private System.Windows.Forms.Button Btn_TreeDisplay;
    }
}