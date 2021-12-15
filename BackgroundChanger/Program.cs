using System;

namespace BackgroundChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til den seje backgroundChanger 3000");

            Wallpaper wallpaper = new Wallpaper();

            wallpaper.ChangeWallpaper();

            Console.ReadLine();
        }
    }
}
