using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Autodesk.Revit.UI;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using System.Reflection;

namespace FurnitureAutomation.Helper
{
    public class PDFGenerator
    {
        private readonly Autodesk.Revit.UI.UIDocument _RevitUIDocument;
        private readonly Autodesk.Revit.UI.UIApplication _RevitUIApplication;

        private readonly Autodesk.Revit.ApplicationServices.Application _RevitApplication;
        private readonly Autodesk.Revit.DB.Document _RevitDocument;
        private readonly ExternalCommandData _CommandData;
        private string PathOfTheCreatedPDF;
        public PDFGenerator() { }
        public PDFGenerator(ExternalCommandData commandData)
        {
            _RevitUIApplication = commandData.Application;
            _RevitUIDocument = _RevitUIApplication.ActiveUIDocument;
            _RevitApplication = _RevitUIApplication.Application;
            _RevitDocument = _RevitUIDocument.Document;
            _CommandData = commandData;
        }
        public iTextSharp.text.Document GeneratePDFDoc()
        {
            try
            {
                DirectoryInfo CurrentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
                string format = "Mddyyyyhhmmsstt";
                string CreatedAt = DateTime.Now.ToString(format);
                PathOfTheCreatedPDF = Path.Combine(CurrentDirectory.Parent.Parent.Parent.FullName, 
                                                    $@"Documents\FurnitureByTypes_{CreatedAt}.pdf");

                iTextSharp.text.Document _PDFDocument = new iTextSharp.text.Document(PageSize.A4, 10, 10, 30, 30);
                PdfWriter _PDFWriter = PdfWriter.GetInstance(_PDFDocument, new FileStream(PathOfTheCreatedPDF, FileMode.Create));
                _PDFDocument.Open();

                Paragraph Header = new Paragraph("Furniture for the active document made through Revit API");
                _PDFDocument.Add(Header);

                Paragraph Separator = new Paragraph(new Chunk
                    (new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, 1, 1)));

                FurnitureMethodsHelper Furniture = new FurnitureMethodsHelper(_CommandData);
                Dictionary<string, List<FamilyInstance>> FetchedFurniture = Furniture.GetFurnitureOnTheActiveView(_RevitDocument);

                if (FetchedFurniture == null)
                {
                    return null;
                }

                foreach (KeyValuePair<string, List<FamilyInstance>> item in FetchedFurniture)
                {
                    Paragraph TypeOfFurniture = new Paragraph(item.Key.ToString());
                    _PDFDocument.Add(TypeOfFurniture);
                    foreach (FamilyInstance piece in item.Value)
                    {
                        Paragraph RoomNumberAndFloor = new Paragraph($"Room Number: {piece.Room.Number} on the floor {piece.Room.Level.Name}");
                        Paragraph QuantityOfTheElements = new Paragraph($"Number of elements on the floor: {item.Value.Count}");
                        _PDFDocument.Add(RoomNumberAndFloor);
                        _PDFDocument.Add(QuantityOfTheElements);
                    }
                    _PDFDocument.Add(Separator);
                }

                _PDFDocument.Add(Separator);
                _PDFDocument.Add(Separator);

                _PDFDocument.Close();
                return _PDFDocument;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public string GetPath()
        {
            return PathOfTheCreatedPDF;
        }
    }
}
