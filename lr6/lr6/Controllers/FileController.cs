using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace lr6.Controllers
{
    public class FileController : Controller
    {
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            var content = $"Ім'я: {firstName}\nПрізвище: {lastName}";
            var byteArray = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(byteArray);

            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "default.txt";
            }
            else if (!fileName.EndsWith(".txt"))
            {
                fileName += ".txt";
            }

            return File(stream, "text/plain", fileName);
        }
    }
}