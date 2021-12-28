using Autodesk.Revit.UI;
using FurnitureAutomation.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureAutomation.UI.Displays
{
    public partial class Frm_TextualDisplay : Form
    {
        private readonly ExternalCommandData _CommandData;
        private readonly Autodesk.Revit.UI.UIDocument _RevitUIDoc;
        private readonly Autodesk.Revit.UI.UIApplication _RevitUIApp;

        private readonly Autodesk.Revit.ApplicationServices.Application _RevitApp;
        private readonly Autodesk.Revit.DB.Document _RevitDocument;
        public Frm_TextualDisplay(ExternalCommandData commandData)
        {
            InitializeComponent();
            _CommandData = commandData;
            _RevitUIApp = commandData.Application;
            _RevitUIDoc = _RevitUIApp.ActiveUIDocument;
            _RevitApp = _RevitUIApp.Application;
            _RevitDocument = _RevitUIDoc.Document;
        }

        private iTextSharp.text.Document Btn_GeneratePDF_Click(object sender, EventArgs e)
        {
            PDFGenerator _PDFGenerator = new PDFGenerator(_CommandData);
            iTextSharp.text.Document GeneratorPDF = _PDFGenerator.GeneratePDFDoc();
            if (GeneratorPDF != null)
            {
                MessageBox.Show($"Successfully created PDF document on location: {_PDFGenerator.GetPath()}.", "Info",MessageBoxButtons.OK);
                return GeneratorPDF;
            }
            else
            {
                MessageBox.Show($"PDF Document isn't created: {_PDFGenerator.GetPath()}", "Warning", MessageBoxButtons.OKCancel);
                return null;
            }
        }
    }
}
