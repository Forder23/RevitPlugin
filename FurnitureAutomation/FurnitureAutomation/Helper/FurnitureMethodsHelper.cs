using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAutomation.Helper
{
    public class FurnitureMethodsHelper
    {
        private readonly Autodesk.Revit.UI.UIDocument _RevitUIDoc;
        private readonly Autodesk.Revit.UI.UIApplication _RevitUIApp;

        private readonly Autodesk.Revit.ApplicationServices.Application _RevitApp;
        private readonly Autodesk.Revit.DB.Document _RevitDocument;

        public FurnitureMethodsHelper(ExternalCommandData commandData)
        {
            _RevitUIApp = commandData.Application;
            _RevitUIDoc = _RevitUIApp.ActiveUIDocument;
            _RevitApp = _RevitUIApp.Application;
            _RevitDocument = _RevitUIDoc.Document;
        }

        public Dictionary<string,List<FamilyInstance>> GetFurnitureOnTheActiveView(Autodesk.Revit.DB.Document _revitDocument)
        {
            
            List<FamilyInstance> Furniture = new FilteredElementCollector(_revitDocument, _revitDocument.ActiveView.Id)
                .OfCategory(BuiltInCategory.OST_Furniture)    
                .Cast<FamilyInstance>()
                .ToList();

            var GroupedFurniture = Furniture
                    .GroupBy(f => f.Symbol.FamilyName) // Group Rooms by the Floor
                    .ToDictionary(f => f.Key, furniture => furniture.ToList());
            

            return GroupedFurniture == null ? null : GroupedFurniture;
        }
    }
}
