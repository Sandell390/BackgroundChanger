using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundChanger
{
    public class Wallpaper
    {
        public List<string> ImagePaths;

        public string CurrentImage;

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public Wallpaper()
        {
            ImagePaths = new List<string>();
            CreateFolder();
            
        }

        public void ChangeWallpaper()
        {
            if (ImagePaths.Count <= 0)
            {
                Console.WriteLine("Der er ikke nogen billeder i mappen");
                return;
            }


            Console.WriteLine("Vælg en wallpaper: ");
            for (int i = 0; i < ImagePaths.Count; i++)
            {
                Console.WriteLine($"{i}. {Path.GetFileName(ImagePaths[i])}");
            }

            int res = -1;
            while (res < 0 || res > ImagePaths.Count)
            {
                string userString = Console.ReadLine();
                while (!int.TryParse(userString, out res))
                {
                    Console.WriteLine("Du skrev ikke et gyldigt tal, prøv igen");
                    userString = Console.ReadLine();

                }
            }

            CurrentImage = ImagePaths[res];
            
            //Change the wallpaper
            SystemParametersInfo(SPI_SETDESKWALLPAPER,
            0,
            CurrentImage,
            SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public void InitImagePaths()
        {
            ImagePaths = Directory.GetFiles(@"C:\Wallpapers\", "*.png").ToList();

        }

        private void CreateFolder()
        {
            if (!Directory.Exists(@"C:\Wallpapers"))
            {
                Directory.CreateDirectory(@"C:\Wallpapers");
            }
            InitImagePaths();
        }
    }
}
