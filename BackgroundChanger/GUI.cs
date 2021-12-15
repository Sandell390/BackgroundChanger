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
        Wallpaper wallpaper;
        public GUI()
        {
            wallpaper = new Wallpaper();
        }

        /// <summary>
        /// Start menu GUI
        /// </summary>
        public void StartMenu()
        {
            Console.WriteLine("1. Update Wallpaper");
            Console.WriteLine("2. Update folder");
            switch (Userinput())
            {
                case 1:
                    ShowALlImagePaths();
                    ChangeWallpaper();
                    break;
                case 2:
                    wallpaper.UpdateImagePaths();
                    Console.WriteLine("Folder has  been updated.");
                break;
            }
        }

        /// <summary>
        /// Updates the GUI
        /// </summary>
        public void UpdateGUI()
        {
            Console.ReadLine();
            Console.Clear(); 
            StartMenu();
        }

        /// <summary>
        /// Shows all images
        /// </summary>
        private void ShowALlImagePaths()
        {
            Console.WriteLine("Vælg en wallpaper: ");
            for (int i = 0; i < wallpaper.ImagePaths.Count; i++)
            {
                Console.WriteLine($"{i}. {Path.GetFileName(wallpaper.ImagePaths[i])}");
            }
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
            if (NoImageError())
                return;
            Console.WriteLine(wallpaper.ChangeWallpaper(Userinput()));
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
