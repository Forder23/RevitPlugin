
namespace RoomAutomation.UI
{
    partial class Frm_RoomNumbering
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
            this.TBox_RoomsNumber = new System.Windows.Forms.TextBox();
            this.Lbl_Note = new System.Windows.Forms.Label();
            this.Btn_GetRoomNumber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F);
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your starting rooms number!";
            // 
            // TBox_RoomsNumber
            // 
            this.TBox_RoomsNumber.Location = new System.Drawing.Point(346, 24);
            this.TBox_RoomsNumber.Name = "TBox_RoomsNumber";
            this.TBox_RoomsNumber.Size = new System.Drawing.Size(261, 25);
            this.TBox_RoomsNumber.TabIndex = 1;
            this.TBox_RoomsNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBox_RoomsNumber.MouseLeave += new System.EventHandler(this.TBox_RoomsNumber_MouseLeave);
            this.TBox_RoomsNumber.MouseHover += new System.EventHandler(this.TBox_RoomsNumber_MouseHover);
            // 
            // Lbl_Note
            // 
            this.Lbl_Note.AutoSize = true;
            this.Lbl_Note.Font = new System.Drawing.Font("Arial", 8.7F);
            this.Lbl_Note.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Note.Location = new System.Drawing.Point(329, 53);
            this.Lbl_Note.Name = "Lbl_Note";
            this.Lbl_Note.Size = new System.Drawing.Size(305, 17);
            this.Lbl_Note.TabIndex = 2;
            this.Lbl_Note.Text = "NOTE: Consideres number E.g. 100-200 etc..";
            // 
            // Btn_GetRoomNumber
            // 
            this.Btn_GetRoomNumber.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_GetRoomNumber.Location = new System.Drawing.Point(633, 21);
            this.Btn_GetRoomNumber.Name = "Btn_GetRoomNumber";
            this.Btn_GetRoomNumber.Size = new System.Drawing.Size(179, 29);
            this.Btn_GetRoomNumber.TabIndex = 3;
            this.Btn_GetRoomNumber.Text = "Generate rooms number";
            this.Btn_GetRoomNumber.UseVisualStyleBackColor = true;
            this.Btn_GetRoomNumber.Click += new System.EventHandler(this.Btn_GetRoomNumber_Click);
            // 
            // Frm_RoomNumbering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1002, 102);
            this.Controls.Add(this.Btn_GetRoomNumber);
            this.Controls.Add(this.Lbl_Note);
            this.Controls.Add(this.TBox_RoomsNumber);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Name = "Frm_RoomNumbering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_RoomNumbering";
            this.Load += new System.EventHandler(this.Frm_RoomNumbering_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBox_RoomsNumber;
        private System.Windows.Forms.Label Lbl_Note;
        private System.Windows.Forms.Button Btn_GetRoomNumber;
    }
}