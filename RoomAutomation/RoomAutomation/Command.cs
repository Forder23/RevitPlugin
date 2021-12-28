#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RoomAutomation.Helper;
using RoomAutomation.UI;
using RoomAutomation.UI.ExceptionHandle;
using RoomAutomation.UI.SuccessHandle;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace RoomAutomation
{
    //AddInId --> [Guid("22E9B98B-13C2-4DD3-875B-616976834881")]
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private int _StartingRoomsNumber { get; set; }
        private RoomHelperMethods _RoomHelper;
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            try
            {
                //start WinForm application
                Frm_RoomNumbering frm_RoomsNumberGenerator = new Frm_RoomNumbering(commandData);
                frm_RoomsNumberGenerator.ShowDialog();
                //take user input
                _StartingRoomsNumber = frm_RoomsNumberGenerator.StartingRoomNumber;
                //make a function that gets all of the rooms, sorts them and give numbers            
                _RoomHelper = new RoomHelperMethods(commandData);
                bool RoomNumberChanged = _RoomHelper.GenerateNextRoomNumber(_StartingRoomsNumber);

                if (RoomNumberChanged == true)
                {
                    Frm_Success info = new Frm_Success();
                    info.ShowDialog();
                    return Result.Succeeded;
                }
                return Result.Failed;
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
