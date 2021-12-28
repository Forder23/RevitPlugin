#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using FurnitureAutomation.Helper;
using FurnitureAutomation.UI.Displays;
using FurnitureAutomation.UI.ExceptionHandle;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace FurnitureAutomation
{
    //AddInId --> [Guid("40BD139F-6369-43DB-B93C-02E60E387E04")]
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication _RevitUIApplication = commandData.Application;
            UIDocument _RevitUIDocument = _RevitUIApplication.ActiveUIDocument;
            Application _RevitApplication = _RevitUIApplication.Application;
            Document _RevitDocument = _RevitUIDocument.Document;

            try
            {
                //Start WinForm
                Frm_ChooseDisplay display = new Frm_ChooseDisplay(commandData);
                display.ShowDialog();
                return Result.Succeeded;
            }
            catch (Exception)
            {
                Frm_NullException error = new Frm_NullException();
                error.ShowDialog();
                return Result.Failed;
            }
            
        }
    }
}
