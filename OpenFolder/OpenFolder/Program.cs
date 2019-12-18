using System;
using System.IO;

namespace OpenFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Test";//where must search the file
            string file = "Found.txt"; // file name that must search

            string filedir=string.Empty;// for get the file direction that we search

            FileSearch(path, file, ref filedir);//function call

            if (filedir.Length>0)//if file found we get it path in <filedir> by ref modifier
            {
                Console.WriteLine($"Searching file directory: {filedir}");
            }
            else//if <filedir>==0
            {
                Console.WriteLine("File don't found");
            }

        }

        private static void FileSearch(string path, string filename, ref string direction)
        {

            if (Directory.Exists(path))
            {
                try
                {
                    if (Directory.GetFiles(path, filename).Length > 0)
                    {
                        Console.WriteLine("file found");
                        direction = path;
                        return;
                    }

                    foreach (string dir in Directory.GetDirectories(path))
                    {
                        FileSearch(dir, filename, ref direction);
                    }              

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine($"the folder <{path}> don't exists");
            }

        }



    }
}
