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

namespace RoomAutomation
{
    //AddInId --> [Guid("22E9B98B-13C2-4DD3-875B-616976834881")]
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Rooms Panel");

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData buttonData = new PushButtonData("btn_Automation","Room Automation",thisAssemblyPath,"RoomAutomation.Command");

            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;

            // Optionally, other properties may be assigned to the button
            // a) tool-tip
            pushButton.ToolTip = "Automation Room";

            DirectoryInfo CurrentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            string RoomAutomationPluginLogoLocation = Path
                .Combine(CurrentDirectory.Parent.Parent.Parent.Parent.FullName, @"Plugin Logos\Rafaelo.jpg");

            // b) large bitmap
            Uri uriImage = new Uri(RoomAutomationPluginLogoLocation);
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication uiApp)
        {
            return Result.Succeeded;
        }
    }
}
