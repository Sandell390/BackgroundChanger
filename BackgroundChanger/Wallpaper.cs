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
        public FileHandler file;

        public string CurrentImage;

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        /// <summary>
        /// imports user32.dll to call SystemParametersInfo wich we use to change the wallpaper
        /// </summary>
        /// <param name="uAction">The action we wanna use</param>
        /// <param name="uParam">A parameter whose usage and format depends on the system parameter being queried or set. For more information about system-wide parameters, see the uiAction parameter. If not otherwise indicated, you must specify zero for this parameter.</param>
        /// <param name="lpvParam">path</param>
        /// <param name="fuWinIni">Update and or change file</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public Wallpaper()
        {
            file = new FileHandler();
            ImagePaths = file.InitImagePaths();
        }

        /// <summary>
        /// Updates the list with image paths
        /// </summary>
        public void UpdateImagePaths()
        {
            ImagePaths = file.InitImagePaths();
        }

        /// <summary>
        /// Checks if theres images in our list
        /// </summary>
        /// <returns>returns null if none</returns>
        public string NoImagesFound()
        {
            if (ImagePaths.Count <= 0)
            {
                return "Der er ikke nogen billeder i mappen";
            }
            return null;
        }

        /// <summary>
        /// Changes the wallpaper on Windows 10 machine
        /// </summary>
        /// <param name="userinput">the userinput</param>
        /// <returns>returns error message if userinput is wrong else null</returns>
        public string ChangeWallpaper(int userinput)
        {
            try
            {
                CurrentImage = ImagePaths[userinput];
            
                //Change the wallpaper
                SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                CurrentImage,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }
            catch
            {
                return "Not a valid number";
            }
            return null;
        }
    }
}
