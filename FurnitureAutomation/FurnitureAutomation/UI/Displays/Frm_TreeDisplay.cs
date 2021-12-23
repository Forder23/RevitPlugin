using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FurnitureAutomation.Helper;
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
    public partial class Frm_TreeDisplay : System.Windows.Forms.Form
    {
        private readonly ExternalCommandData _CommandData;
        private readonly Autodesk.Revit.UI.UIDocument _RevitUIDoc;
        private readonly Autodesk.Revit.UI.UIApplication _RevitUIApp;

        private readonly Autodesk.Revit.ApplicationServices.Application _RevitApp;
        private readonly Autodesk.Revit.DB.Document _RevitDocument;

        public Frm_TreeDisplay(ExternalCommandData commandData)
        {
            InitializeComponent();
            _CommandData = commandData;
            _RevitUIApp = commandData.Application;
            _RevitUIDoc = _RevitUIApp.ActiveUIDocument;
            _RevitApp = _RevitUIApp.Application;
            _RevitDocument = _RevitUIDoc.Document;
        }

        private void MakeTree()
        {
            FurnitureMethodsHelper Furniture = new FurnitureMethodsHelper(_CommandData);
            Dictionary<string, List<FamilyInstance>> FetchedFurniture = Furniture.GetFurnitureOnTheActiveView(_RevitDocument);

            foreach (KeyValuePair<string,List<FamilyInstance>> item in FetchedFurniture)
            {
                TreeNode TopNode = new TreeNode(item.Key.ToString());
                foreach (FamilyInstance piece in item.Value)
                {
                    TreeNode TopNodeChild = TopNode.Nodes.Add($"Floor {piece.Room.Level.Name}");
                    TopNodeChild.Nodes.Add($"Room {piece.Room.Number}");
                }
                TView_Furniture.Nodes.Add(TopNode);
            }
        }

        private void Btn_GenerateTreeView_Click(object sender, EventArgs e)
        {
            MakeTree();
        }
    }
}
