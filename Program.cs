using System;
using System.IO;

namespace FileManager
{
    class Program
    {
       
       
        static void Main(string[] args)
        {
            string[] tmp = new string[2];
            int i = 0;
               StreamReader mainfile;
               string rep;
               string[] final= new string[10];
               StreamReader folderfile;
               string _mainfile="", _folderfile;
               StreamReader multifiles;
               string[] folder_names;
               string line = "",temp="", linend="";
               int count = 0,maincount=0;
              _mainfile = @"D:\New folder12\softwares\Scripts\file\main\file.txt";
               string _multifiles = "";
            string outputLocation = "";
            outputLocation = @"D:\New folder12\softwares\Scripts\file\output\out.txt";
            {
                //   _folderfile = @"D:\file manager\file\listdocu.txt";

                //  Console.WriteLine("enter file location: ");
                // _mainfile = Console.ReadLine();
                //  Console.WriteLine("enter folder file location: ");
                //    _folderfile = Console.ReadLine();
            }
            _multifiles = @"D:\New folder12\softwares\Scripts\file\folders.txt";
            multifiles = new StreamReader(_multifiles);
            //  _folderfile = @"D:\file manager\file\listdocu.txt";


            mainfile = new StreamReader(_mainfile);

            while ((_folderfile = multifiles.ReadLine()) != null)
            {
                   //  Console.WriteLine(_folderfile);
                
                    folderfile = new StreamReader(_folderfile);

                folder_names = counter(folderfile);
                starter(mainfile);
                // Console.WriteLine(line);
              //  tester(folder_names);
                writer(folder_names);
                tester(final);
                {
                    /*
                    Console.WriteLine("is there any other folder file?: ");
                    rep = Console.ReadLine();
                    if(rep.ToLower() == "true" || rep.ToLower() == "yes" || rep.ToLower() == "y")
                    {*/
                }
                temp = null;
                count = 0;
                folderfile = null;
                //  Console.WriteLine("enter folder file location: ");
                //    _folderfile = Console.ReadLine();
                // _folderfile = @"D:\file manager\file\listlocal.txt";
                folder_names = null;
                { /*
                folderfile = new StreamReader(_folderfile);
                counter(folderfile);
                starter(mainfile);
                // Console.WriteLine(line);
                tester(folder_names);
                writer(folder_names);
                tester(final);
                 Console.ReadKey();
              }  */
                }
            }
         //   foreach (string t in final)
            {
                File.WriteAllLines (outputLocation, final);
            }
            Console.ReadKey();





            string[] counter(StreamReader t)
            {
                string[] arrayer;
                string ln;
                while ((ln = t.ReadLine()) != null)
                {
                  //  Console.WriteLine(ln);
                    count++;
                    temp += ln+',';
                }
              temp =   temp.TrimEnd(','); 
                arrayer = new string[count];
                arrayer = temp.Split(',');
                return arrayer;
            }
            void starter(StreamReader t)
            {
                string ln;
                while ((ln = t.ReadLine()) != null)
                {
                    Console.WriteLine(ln);
                    maincount++;
                   if(ln.Contains("CopyFolder"))
                    {
                        line = ln;
                    }
                   else if(ln.Contains("END"))
                    {
                        
                        tmp = line.Split(',');
                        line = tmp[0].TrimEnd('"');
                        linend ="\"," +tmp[1];
                        maincount--;
                        break;
                    }
                }
            }
            void tester(string[] r)
            {
                foreach(string f in r)
                {
                    Console.WriteLine(f);
                }
            }
            void writer(string[] arr)
            {
               
                foreach(string d in arr)
                {
                    i++;
                    try
                    {
                        final[i] =  line+ d+linend;
                    }
                    catch(IndexOutOfRangeException)
                    {
                        string[] tt = new string[final.Length+1];
                        tt[final.Length] =line+ d+ linend;
                        final.CopyTo(tt, 0);
                        final = new string[final.Length + 10];
                        tt.CopyTo(final, 0);
                    }
                }

            }
        }
    }
}
