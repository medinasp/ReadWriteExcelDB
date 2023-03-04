using ReadWriteExcelSql.Models.Interfaces;
using ReadWriteExcelSql.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace ReadWriteExcelSql.Models.Services
{
    public class ServiceExcel : IServiceExcel
    {
        public List<ExcelDataViewModel> ReadExcelFile()
        {
            string path = @"C:\1A\TemplateDefinicaoDosSonhos.xlsx";
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
                        }

                        lines.Add(excelDataViewModel);
                    }
                }
            }
            catch (IOException erro)
            {
                Console.WriteLine("Deu erro");
                Console.WriteLine(erro.Message);
            }

            return lines;
        }

        public void SaveToDatabase(string[][] recebida, int totalLinhas)
        {
            List<UpExcel> upExcels = new List<UpExcel>();

            for (int i = 0; i < totalLinhas; i++)
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

            using (var context = new ContextBase())
            {
                context.UpExcels.AddRange(upExcels);
                context.SaveChanges();
            }
        }
    }
}