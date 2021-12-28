using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FurnitureAutomation.Helper;
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
    public partial class Frm_DatagridDisplay : System.Windows.Forms.Form
    {
        private readonly ExternalCommandData _CommandData;
        private readonly Autodesk.Revit.UI.UIDocument _RevitUIDoc;
        private readonly Autodesk.Revit.UI.UIApplication _RevitUIApp;

        private readonly Autodesk.Revit.ApplicationServices.Application _RevitApp;
        private readonly Autodesk.Revit.DB.Document _RevitDocument;

        public Frm_DatagridDisplay(ExternalCommandData commandData)
        {
            InitializeComponent();
            _CommandData = commandData;
            _RevitUIApp = commandData.Application;
            _RevitUIDoc = _RevitUIApp.ActiveUIDocument;
            _RevitApp = _RevitUIApp.Application;
            _RevitDocument = _RevitUIDoc.Document;
        }

        private void Frm_DatagridDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                FurnitureMethodsHelper Furniture = new FurnitureMethodsHelper(_CommandData);
                Dictionary<string, List<FamilyInstance>> FetchedFurniture = Furniture.GetFurnitureOnTheActiveView(_RevitDocument);
                Dgv_Furniture.AutoGenerateColumns = false;
                Dgv_Furniture.AutoSize = true;
                Dgv_Furniture.Columns.Add(" ", "Type");
                Dgv_Furniture.Columns.Add(" ", "Room Number");
                Dgv_Furniture.Columns.Add(" ", "Room Name");
                Dgv_Furniture.Columns.Add(" ", "Quantity");

                foreach (KeyValuePair<string, List<FamilyInstance>> item in FetchedFurniture)
                {
                    foreach (FamilyInstance piece in item.Value)
                    {
                        Dgv_Furniture.Rows.Add(item.Key, piece.Room.Number, piece.Room.Name, item.Value.Count.ToString());
                    }
                    Dgv_Furniture.Rows.Add("", "");
                }
            }
            catch (Exception)
            {
                Frm_NullException error = new Frm_NullException();
                error.ShowDialog();
            }           
        }
    }
}
