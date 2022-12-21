using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            Renamer rr = new Renamer();

            bool checkPath = rr.Checkpath();
            if (checkPath==false)
            {
                Console.WriteLine("Enter Path of the Archieves:");
                rr.ChangePath(Console.ReadLine());
                rr.SetPath();
            }else{
                Console.Write("Default Path: ");
                ChangeColorConsoleToGreen();
                Console.WriteLine(rr.archievesPath + Environment.NewLine);
                ChangeColorConsoleToWhite();
            }

            Console.Write("If U wanna change archieve directory, paste new path into: \n");
            ChangeColorConsoleToYellow();
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory() + @"\ArchievesPath.ini" + Environment.NewLine);
            ChangeColorConsoleToWhite();

            Console.Write("Count of Archives: ");
            ChangeColorConsoleToRed();
            Console.WriteLine(rr.Getfiles().Length + Environment.NewLine);
            ChangeColorConsoleToWhite();

            Console.Write("Do u need counter of Toms?\nSelect ");
            ChangeColorConsoleToYellow(); Console.Write("Y");
            ChangeColorConsoleToWhite(); Console.Write(" or ");
            ChangeColorConsoleToGreen(); Console.Write("N");
            ChangeColorConsoleToWhite(); Console.WriteLine(".");
           

            if (Console.ReadLine() == "Y")
            {
                rr.needTom = true;
            }
            else
            {
                rr.needTom= false;
            }
            rr.RenameArchives();
            ChangeColorConsoleToGreen();
            Console.WriteLine("Well done! I removed all shit!"); 
           
            Console.ReadKey();
        }
        static void ChangeColorConsoleToRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        static void ChangeColorConsoleToGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        static void ChangeColorConsoleToWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void ChangeColorConsoleToYellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}
