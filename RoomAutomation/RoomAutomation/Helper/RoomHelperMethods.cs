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
        public void GenerateNextRoomNumber(int startingRoomNumber)
        {
            int CurrentStartingRoomNumber = 0;
            int TempCurrentStartingRoomNumber = startingRoomNumber;
            Dictionary<string,List<Room>> Rooms = GetRooms(_RevitDocument);

            if (Rooms.Count > 0)
            {
                //make a check is the number used by other room or the room is located at the other floor
                //if is on the other floor multiply by 100
                using (Transaction tx = new Transaction(_RevitDocument))
                {
                    if (tx.Start("Modify rooms number") == TransactionStatus.Started)
                    {
                        foreach (KeyValuePair<string, List<Room>> roomItems in Rooms.OrderBy(lvl => lvl.Key)) //sort rooms by the floor
                        {
                            foreach (Room room in roomItems.Value)
                            {
                                
                                if (int.Parse(roomItems.Key) > 1)
                                {
                                    startingRoomNumber = CurrentStartingRoomNumber++;
                                    while (int.Parse(room.Number) == startingRoomNumber)
                                    {
                                        startingRoomNumber++; //while RoomNumber is taken increment RoomNumber
                                        CurrentStartingRoomNumber = startingRoomNumber;
                                    }
                                    int FloorLevel = int.Parse(roomItems.Key);
                                    room.Number = CalculateRoomNumber(FloorLevel, startingRoomNumber).ToString(); //Set free RoomNumber through calculation
                                }
                                else if (int.Parse(roomItems.Key) == 1)
                                {
                                    startingRoomNumber = CurrentStartingRoomNumber++;
                                    while (int.Parse(room.Number) == startingRoomNumber)
                                    {
                                        startingRoomNumber++; //while RoomNumber is taken increment RoomNumber
                                        CurrentStartingRoomNumber = startingRoomNumber;
                                    }
                                    int FloorLevel = int.Parse(roomItems.Key);
                                    room.Number = CalculateRoomNumber(FloorLevel, startingRoomNumber).ToString(); //Set free RoomNumber through calculation
                                }
                                else
                                {
                                    room.Number = (startingRoomNumber++).ToString();
                                }
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
            return;
        }

        public Dictionary<string, List<Room>> GetRooms(Autodesk.Revit.DB.Document document)
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
                    .GroupBy(lvl => lvl.Level.Name.Substring(6)) // Group Rooms by the Floor
                    .ToDictionary(rooms => rooms.Key, rooms => rooms.ToList());

                return GroupedRooms;
            }
            catch (Exception)
            {
                throw;
            }          
        }

        public int CalculateRoomNumber(int floorLvl, int RoomNumber)
        {
            return (floorLvl * __MAX_ROOMS_ON_THE_FLOOR) + RoomNumber;
        }
            
    }
}
