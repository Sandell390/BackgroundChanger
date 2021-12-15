using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundChanger
{
    public class GUI
    {
        public TimeSpan sleepTime;
        Wallpaper wallpaper;
        public GUI()
        {
            wallpaper = new Wallpaper();
        }

        private void Menu()
        {
            Console.WriteLine("Hvor længe vil du vente til at baggrunden skifter?");
            Console.WriteLine("1. 1 hour");
            Console.WriteLine("2. 1 day");
            Console.WriteLine("3. 7 days");
            switch (Userinput())
            {
                case 1:
                    sleepTime = TimeSpan.FromHours(1);
                    break;
                case 2:
                    sleepTime = TimeSpan.FromDays(1);
                    break;
                case 3:
                    sleepTime = TimeSpan.FromDays(7);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Updates the GUI
        /// </summary>
        public void UpdateGUI()
        {
            Menu();
            ChangeWallpaper();
        }

        /// <summary>
        /// Checks for userinput
        /// </summary>
        /// <returns>userinput</returns>
        private int Userinput()
        {
            int res = -1;
            string userString = Console.ReadLine();
            while (!int.TryParse(userString, out res))
            {
                Console.WriteLine("Du skrev ikke et gyldigt tal, prøv igen");
                userString = Console.ReadLine();

            }
            return res;
        }

        /// <summary>
        /// Changes the wallpapers
        /// </summary>
        private void ChangeWallpaper()
        {
            while (true)
            {
                if (NoImageError())
                    return;
                Console.WriteLine(wallpaper.ChangeWallpaper());
                Console.WriteLine($"Background changed to {Path.GetFileName(wallpaper.CurrentImage)}");
                wallpaper.UpdateImagePaths();
                Thread.Sleep(sleepTime);
            }
        }

        /// <summary>
        /// Checks if theres any images in our list.
        /// </summary>
        /// <returns></returns>
        private bool NoImageError()
        {
            string temp = wallpaper.NoImagesFound();
            if (!string.IsNullOrEmpty(temp))
            {
                Console.WriteLine(temp);
                return true;
            }
            return false;
        }
    }
}
