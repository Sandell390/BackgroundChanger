using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BackgroundChanger
{
    public class FileHandler
    {
        public FileHandler()
        {
            CreateFolder();
        }

        /// <summary>
        /// Initialises all .png images
        /// </summary>
        /// <returns>returns list of strings</returns>
        public List<string> InitImagePaths()
        {
            return Directory.GetFiles(@"C:\Wallpapers\", "*.png").ToList();

        }

        /// <summary>
        /// Creates folder at C:\ if not exists
        /// </summary>
        public void CreateFolder()
        {
            if (!Directory.Exists(@"C:\Wallpapers"))
            {
                Directory.CreateDirectory(@"C:\Wallpapers");
            }
        }
    }
}
