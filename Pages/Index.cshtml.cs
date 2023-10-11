using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Net;

using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using Contracts.Models;

namespace Contracts.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;


        public IndexModel(ILogger<IndexModel> logger, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            this.hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }

        [BindProperty]
        public Person Person { get; set; }

        public IActionResult OnGet()
        {
            // Inițializați obiectul Person sau încărcați datele existente aici
            Person = new Person();
            return Page();
        }

        public FileResult OnGetDownloadFile() {
            //get the file from somewhere in bytes
            var path = Path.Combine(hostingEnvironment.WebRootPath,"Files\\Contract.pdf");
            var bytes = System.IO.File.ReadAllBytes(path);

            //send file to front-end - user download
            return File(bytes, "application/octet-stream", "Contract.pdf");
        }

        public IActionResult OnPost(string capturedImage)
        {
            capturedImage = capturedImage.Substring(22, capturedImage.Length - 22);
            byte[] imageBytes = Convert.FromBase64String(capturedImage);

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                // Create a Bitmap from the MemoryStream
                Bitmap bitmap = new Bitmap(ms);

                // Specify the path to save the image to
                string outputPath = "output.jpg"; // Change the file extension based on the image format

                // Save the Bitmap to the specified path
                bitmap.Save(outputPath);

                Console.WriteLine($"Image saved to {outputPath}");

                // Dispose of the Bitmap when done
                bitmap.Dispose();
            }

            return Page();
        }
    }
}