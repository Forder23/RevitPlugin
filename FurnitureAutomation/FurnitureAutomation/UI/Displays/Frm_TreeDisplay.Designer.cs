
namespace FurnitureAutomation.UI.Displays
{
    partial class Frm_TreeDisplay
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
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_GenerateTreeView = new System.Windows.Forms.Button();
            this.TView_Furniture = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tree Display of the furniture";
            // 
            // Btn_GenerateTreeView
            // 
            this.Btn_GenerateTreeView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Btn_GenerateTreeView.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Btn_GenerateTreeView.ForeColor = System.Drawing.Color.White;
            this.Btn_GenerateTreeView.Location = new System.Drawing.Point(513, 31);
            this.Btn_GenerateTreeView.Name = "Btn_GenerateTreeView";
            this.Btn_GenerateTreeView.Size = new System.Drawing.Size(275, 35);
            this.Btn_GenerateTreeView.TabIndex = 1;
            this.Btn_GenerateTreeView.Text = "Generate a tree view";
            this.Btn_GenerateTreeView.UseVisualStyleBackColor = false;
            this.Btn_GenerateTreeView.Click += new System.EventHandler(this.Btn_GenerateTreeView_Click);
            // 
            // TView_Furniture
            // 
            this.TView_Furniture.Font = new System.Drawing.Font("Arial", 10F);
            this.TView_Furniture.Location = new System.Drawing.Point(16, 76);
            this.TView_Furniture.Name = "TView_Furniture";
            this.TView_Furniture.Size = new System.Drawing.Size(772, 322);
            this.TView_Furniture.TabIndex = 2;
            // 
            // Frm_TreeDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 423);
            this.Controls.Add(this.TView_Furniture);
            this.Controls.Add(this.Btn_GenerateTreeView);
            this.Controls.Add(this.label1);
            this.Name = "Frm_TreeDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tree Display";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_GenerateTreeView;
        private System.Windows.Forms.TreeView TView_Furniture;
    }
}