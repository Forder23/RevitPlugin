using Autodesk.Revit.UI;
using FurnitureAutomation.UI.ExceptionHandle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureAutomation.UI.Displays
{
    public partial class Frm_ChooseDisplay : Form
    {
        private readonly ExternalCommandData _CommandData;
        private readonly Autodesk.Revit.UI.UIDocument _RevitUIDoc;
        private readonly Autodesk.Revit.UI.UIApplication _RevitUIApp;

        private readonly Autodesk.Revit.ApplicationServices.Application _RevitApp;
        private readonly Autodesk.Revit.DB.Document _RevitDocument;
        public Frm_ChooseDisplay(ExternalCommandData commandData)
        {
            InitializeComponent();
            _CommandData = commandData;
            _RevitUIApp = commandData.Application;
            _RevitUIDoc = _RevitUIApp.ActiveUIDocument;
            _RevitApp = _RevitUIApp.Application;
            _RevitDocument = _RevitUIDoc.Document;
        }

        private void Btn_GridDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_DatagridDisplay GridDisplay = new Frm_DatagridDisplay(_CommandData);
                GridDisplay.ShowDialog();
            }
            catch (Exception)
            {
                Frm_NullException error = new Frm_NullException();
                error.ShowDialog();
            }
            
        }

        private void Btn_TreeDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_TreeDisplay TreeDisplay = new Frm_TreeDisplay(_CommandData);
                TreeDisplay.ShowDialog();
            }
            catch (Exception)
            {
                Frm_NullException error = new Frm_NullException();
                error.ShowDialog();
            }
        }

        private void Btn_TextualDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_TextualDisplay PDFDisplay = new Frm_TextualDisplay(_CommandData);
                PDFDisplay.ShowDialog();
            }
            catch (Exception)
            {
                Frm_NullException error = new Frm_NullException();
                error.ShowDialog();
            }
            
        }
    }
}
