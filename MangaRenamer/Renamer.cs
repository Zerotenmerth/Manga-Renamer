using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MangaRenamer
{
    class Renamer
    {
        string[] files;
        private string settingFile = @".\ArchievesPath.ini";
        public string archievesPath;
        public bool needTom = false;
        public Renamer ()
        {

        }
        public void ChangePath(string x)
        {
            archievesPath = x;
        }
        public bool Checkpath()
        {
            if (!File.Exists(settingFile))
            {
                File.Create(settingFile);
            }
            else
            {
                archievesPath = File.ReadAllText(settingFile);
            }
            if (Directory.Exists(archievesPath))
            {
                return true;
            }
            else return false;
        }
        public void SetPath()
        {
            File.WriteAllText(settingFile, archievesPath);
        }
        public string[] Getfiles()
        {
            files = Directory.GetFiles(archievesPath, "*.zip*");
            return files;
        }
        private string CorrectRenameExtraChapters(string name) 
        {
            
                name = name.Replace(".", ",");
                name = (Convert.ToSingle(name) + 1).ToString();
                name = name.Replace(",", ".");
                return name;
        }
        public void RenameArchives()
        {
            for (int i = 0; i < files.Length; i++)
            {
                string name = files[i];
                string[] temp = name.Split('\\'); string temp1 = temp[temp.Length - 1]; string firstPart = temp1.Remove(temp1.IndexOf("Том") - 1);
                temp1 = temp1.Substring(temp1.IndexOf("Том"));
                temp = temp1.Split(' ');
                string secondPart = "";
                if (temp[temp.Length - 2].Contains("."))
                    secondPart = "Ch" + CorrectRenameExtraChapters(temp[temp.Length - 2]);
                else
                   secondPart = "Ch" + temp[temp.Length - 2];
                if (needTom == true)
                {
                    secondPart= secondPart.Replace("Ch", "Tom" + temp[1] + "_ch");
                }

                string newName = archievesPath + "\\"  + secondPart + "_" +firstPart + ".zip";
                File.Move(files[i], newName);
                RemoveShit(newName);
            }
        }
        public void RemoveShit(string x)
        {
            using (ZipFile zip = ZipFile.Read(x))
            {
                ZipEntry lastElement= zip.Entries.Last();
                zip.RemoveEntry(lastElement.FileName);
                zip.Save();
            }
        }
    }
}
