using Microsoft.AspNetCore.Mvc;
using ReadWriteExcelSql.Models;
using ReadWriteExcelSql.Models.Interfaces;
using ReadWriteExcelSql.Models.ViewModels;
using System.Collections.Generic;

namespace ReadWriteExcelSql.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IServiceExcel _service;

        public ExcelController(IServiceExcel service)
        {
            _service = service;
        }

        public IActionResult ReadExcelFile()
        {
            var lines = _service.ReadExcelFile();
            return View(lines);
        }

        [HttpPost]
        public IActionResult SaveToDatabase(string[][] recebida, int totalLinhas)
        {

            _service.SaveToDatabase(recebida, totalLinhas);

            return RedirectToAction("ReadExcelFile");
        }
    }
}