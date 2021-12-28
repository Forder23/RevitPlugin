#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

#endregion

namespace FurnitureAutomation
{
    //AddInId --> [Guid("40BD139F-6369-43DB-B93C-02E60E387E04")]
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Furniture Panel");

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData buttonData = new PushButtonData("btn_FurnitureDisplay", "Furniture Automation", thisAssemblyPath, "FurnitureAutomation.Command");

            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;

            // Optionally, other properties may be assigned to the button
            // a) tool-tip
            pushButton.ToolTip = "Display Furniture";

            DirectoryInfo CurrentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            string FurnitureAutomationPluginLogoLocation = Path
                .Combine(CurrentDirectory.Parent.Parent.Parent.Parent.FullName,@"Plugin Logos\Ranko_JR_1.jpg");
            // b) large bitmap
            Uri uriImage = new Uri(FurnitureAutomationPluginLogoLocation);
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
