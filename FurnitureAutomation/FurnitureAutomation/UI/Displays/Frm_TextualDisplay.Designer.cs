
namespace FurnitureAutomation.UI.Displays
{
    partial class Frm_TextualDisplay
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
            this.Btn_GeneratePDF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_GeneratePDF
            // 
            this.Btn_GeneratePDF.Font = new System.Drawing.Font("Arial", 10F);
            this.Btn_GeneratePDF.Location = new System.Drawing.Point(99, 66);
            this.Btn_GeneratePDF.Name = "Btn_GeneratePDF";
            this.Btn_GeneratePDF.Size = new System.Drawing.Size(195, 61);
            this.Btn_GeneratePDF.TabIndex = 0;
            this.Btn_GeneratePDF.Text = "Create PDF document";
            this.Btn_GeneratePDF.UseVisualStyleBackColor = true;
            this.Btn_GeneratePDF.Click += new System.EventHandler(this.Btn_GeneratePDF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generate PDF document ready for print";
            // 
            // Frm_TextualDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 167);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_GeneratePDF);
            this.Name = "Frm_TextualDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Textual Display";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_GeneratePDF;
        private System.Windows.Forms.Label label1;
    }
}