using Microsoft.AspNetCore.Mvc;
using ReadWriteExcelSql.Models.ViewModels;
using ReadWriteExcelSql.Models;
using OfficeOpenXml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;

namespace ReadWriteExcelSql.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            List<ExcelDataViewModel> model = new List<ExcelDataViewModel>();
            string pathtext = @"C:\1A\file1.txt";
            List<string> linesText = new List<string>();

            try
            {
               using (StreamReader sr = new StreamReader(pathtext))
                    {
                        while (!sr.EndOfStream)
                        {
                            string linetxt = sr.ReadLine();
                            linesText.Add(linetxt);
                        }
                    }
            }
            catch(IOException erro)
            {
                Console.WriteLine("Deu erro");
                Console.WriteLine(erro.Message);
            }
            ViewBag.linesText = linesText;


            string path = @"C:\1A\TemplateDefinicaoDosSonhos.xlsx";
            //            List<string> lines = new List<string>();
            List<ExcelDataViewModel> lines = new List<ExcelDataViewModel>();
            try
            {
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    for (int row = 1; row <= rowCount; row++)
                    {
                        ExcelDataViewModel excelDataViewModel = new ExcelDataViewModel();
                        for (int col = 1; col <= colCount; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Value;
                            excelDataViewModel.valores.Add((cellValue ?? "").ToString());
//                            line += (cellValue ?? "").ToString() + " ";
                        }
                        //lines.Add(line);
                        lines.Add(excelDataViewModel);
                    }
                }
            }
            catch (IOException erro)
            {
                Console.WriteLine("Deu erro");
                Console.WriteLine(erro.Message);
            }

            ViewBag.Lines = lines;
            return View(lines);

        }

        // [HttpPost]
        //public ActionResult ImportDb(List<ExcelDataViewModel> model)
        //{
        //    var list = new List<UpExcel>();
        //    var totalLines = new List<UpExcel>();
        //    ExcelDataViewModel excelDataViewModel = new ExcelDataViewModel();

        //    foreach (var excelUp in model)
        //    {
        //        foreach (var value in excelUp.valores)
        //        {
        //            //for (var cont = 1; cont < excelDataViewModel[0].valores.Count; cont++)
        //            //{
        //            //    list.Add(new UpExcel
        //            //    {
        //            //        Col1 = value
        //            //    });

        //            //}
        //        }
        //    }

        //    using (var context = new ContextBase())
        //    {
        //        context.UpExcels.AddRange(list);
        //        context.SaveChanges();
        //        totalLines = context.UpExcels.ToList();
        //    }

        //    return View();
        //}

        [HttpPost]
        public ActionResult ImportDb(string[][] recebida)
        {
            List<UpExcel> upExcels = new List<UpExcel>();

            for (int i = 0; i < recebida.Length; i++)
            {
                UpExcel upExcel = new UpExcel();

                for (int j = 0; j < recebida[i].Length; j++)
                {
                    if (j == 0)
                    {
                        upExcel.Col1 = recebida[i][j];
                    }
                    else if (j == 1)
                    {
                        upExcel.Col2 = recebida[i][j];
                    }
                    else if (j == 2)
                    {
                        upExcel.Col3 = recebida[i][j];
                    }
                    else if (j == 3)
                    {
                        upExcel.Col4 = recebida[i][j];
                    }
                }

                upExcels.Add(upExcel);
            }

            // Salva a lista no banco de dados
            //_context.UpExcels.AddRange(upExcels);
            //_context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
