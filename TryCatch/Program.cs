using System;
using System.Collections.Generic;
using System.IO;

namespace EssentialTrainingApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ReadTextFile();

        }

        public static void ReadTextFile()
        {
            try
            {

                using (var sr = new StreamReader(@"A:\file1.txt")) //Text file location to read
                {
                    string contents = sr.ReadToEnd();
                    Console.WriteLine(contents);
                
                }
            }
            catch(DirectoryNotFoundException ex)
            {
                Console.WriteLine("Could not file the file");
            }catch(FileNotFoundException ex)
            {
                Console.WriteLine("File not found");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("finally run all the time");
            }
        }

    }
}

    





