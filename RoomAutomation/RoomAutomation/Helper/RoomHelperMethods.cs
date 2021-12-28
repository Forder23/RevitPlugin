using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAutomation.Helper
{
    public class RoomHelperMethods
    {
        private const int __MAX_ROOMS_ON_THE_FLOOR = 100;
        private readonly Autodesk.Revit.UI.UIDocument _RevitUIDoc;
        private readonly Autodesk.Revit.UI.UIApplication _RevitUIApp;

        private readonly Autodesk.Revit.ApplicationServices.Application _RevitApp;
        private readonly Autodesk.Revit.DB.Document _RevitDocument;

        public RoomHelperMethods(ExternalCommandData commandData)
        {
            _RevitUIApp = commandData.Application;
            _RevitUIDoc = _RevitUIApp.ActiveUIDocument;
            _RevitApp = _RevitUIApp.Application;
            _RevitDocument = _RevitUIDoc.Document;
        }
        public bool GenerateNextRoomNumber(int startingRoomNumber)
        {
            bool RoomsExist = false;
            Dictionary<int,List<Room>> Rooms = GetRooms(_RevitDocument);

            if (Rooms.Count > 0)
            {
                using (Transaction tx = new Transaction(_RevitDocument))
                {
                    if (tx.Start("Modify rooms number") == TransactionStatus.Started)
                    {
                        foreach (KeyValuePair<int, List<Room>> roomItems in Rooms.OrderBy(lvl => lvl.Key)) //sort rooms by the floor
                        {
                            foreach (Room room in roomItems.Value)
                            {
                                room.Number = (++startingRoomNumber).ToString(); //Set free RoomNumber through calculation
                                ///TO DO///
                                
                                //Implement changing background of the floor for each room
                                //as an indicator that something is going on in the background!!
                                RoomsExist = true;
                            }
                        }
                    }
                    else
                    {
                        tx.RollBack();
                    }
                        tx.Commit();
                }
            }
            else
            {
                RoomsExist = false;
            }
            return RoomsExist;
        }

        public Dictionary<int, List<Room>> GetRooms(Autodesk.Revit.DB.Document document)
        {
            try
            {
                // Find all Room instances in the document by using category filter and cast them into Room objects from Element Type
                List<Room> Rooms = new FilteredElementCollector(document)
                    .OfCategory(BuiltInCategory.OST_Rooms)
                    .ToElements()
                    .Cast<Room>()
                    .ToList();

                var GroupedRooms = Rooms
                    .OrderBy(x => x.Number)
                    .GroupBy(lvl => int.Parse(lvl.Level.Id.ToString())) // Group Rooms by the Floor
                    .ToDictionary(rooms => rooms.Key, rooms => rooms.ToList());
                    
                return GroupedRooms == null ? null : GroupedRooms;
            }
            catch (Exception)
            {
                return null;
            }          
        }            
    }
}
