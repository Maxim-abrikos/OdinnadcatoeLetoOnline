using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Linq;

namespace OdinnadcatoeLetoOnline.Pages
{
    public class IndexModel : PageModel
    {
        private readonly string _counterPath = "App_Data/download_count.txt";
        private readonly string _zipPath = "wwwroot/game.zip";

        public int DownloadCount { get; set; }
        public string BackgroundImage { get; set; }

        public void OnGet()
        {
            DownloadCount = GetCount();
            BackgroundImage = GetRandomBackground();
        }

        public IActionResult OnGetDownload()
        {
            var count = GetCount() + 1;
            System.IO.File.WriteAllText(_counterPath, count.ToString());

            return Redirect("/game.zip");
        }

        private int GetCount()
        {
            if (System.IO.File.Exists(_counterPath))
            {
                var text = System.IO.File.ReadAllText(_counterPath);
                if (int.TryParse(text, out int count)) return count;
            }
            return 0;
        }

        private string GetRandomBackground()
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            if (!Directory.Exists(folder)) return "/images/default.png";

            var files = Directory.GetFiles(folder)
                .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png"))
                .Select(Path.GetFileName)
                .ToArray();

            if (files.Length == 0) return "/images/default.png";
            var rnd = new Random();
            return "/images/" + files[rnd.Next(files.Length)];
        }
    }
}