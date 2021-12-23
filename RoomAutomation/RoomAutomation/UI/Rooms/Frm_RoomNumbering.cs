using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomAutomation.UI
{
    public partial class Frm_RoomNumbering : Form
    {
        private readonly Autodesk.Revit.UI.UIDocument _RevitUIDoc;
        private readonly Autodesk.Revit.UI.UIApplication _RevitUIApp;

        private readonly Autodesk.Revit.ApplicationServices.Application _RevitApp;
        private readonly Autodesk.Revit.DB.Document _RevitDocument;

        public int StartingRoomNumber { get; set; }
        public Frm_RoomNumbering(ExternalCommandData commandData)
        {
            InitializeComponent();

            _RevitUIApp = commandData.Application;
            _RevitUIDoc = _RevitUIApp.ActiveUIDocument;
            _RevitApp = _RevitUIApp.Application;
            _RevitDocument = _RevitUIDoc.Document;
        }

        private void Frm_RoomNumbering_Load(object sender, EventArgs e)
        {
            Lbl_Note.Visible = false;
        }

        private void TBox_RoomsNumber_MouseHover(object sender, EventArgs e)
        {
            Lbl_Note.Visible = true;
        }

        private void TBox_RoomsNumber_MouseLeave(object sender, EventArgs e)
        {
            Lbl_Note.Visible = false;
        }

        private void Btn_GetRoomNumber_Click(object sender, EventArgs e)
        {
            try
            {
                if (StartingRoomNumber >= 0)
                {
                    StartingRoomNumber = int.Parse(TBox_RoomsNumber.Text);
                    MessageBox.Show($"Room numbers will autoincrement from the number {StartingRoomNumber}.", "Info", MessageBoxButtons.OK);
                    Close();
                }                
            }
            catch (Exception)
            {
                TBox_RoomsNumber.Clear();
                TBox_RoomsNumber.Focus();
            }            
        }


    }
}
