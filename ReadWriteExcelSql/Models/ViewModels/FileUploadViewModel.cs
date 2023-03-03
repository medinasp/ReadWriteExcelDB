namespace ReadWriteExcelSql.Models.ViewModels
{
    public class FileUploadViewModel
    {
        public IFormFile XlsFile { get; set; }
        /*create ExcelDataViewModel  object because we need to add read
         excel data and mapping in ExcelDataViewModel*/
        public List<ExcelDataViewModel> ExcelDataViewModel { get; set; }
        public FileUploadViewModel()//Create contractor
        {
            //call ExcelDataViewModel  this object in contractor
            ExcelDataViewModel = new List<ExcelDataViewModel>();
        }
    }
}
