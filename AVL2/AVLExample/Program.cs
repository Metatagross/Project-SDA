using AVLTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLExample
{
    class Program
    {
        public static void RunCommands ( AVL<int> tree , string path )
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach(string line in lines)
            {
                if(line.Contains("Insert:"))
                {
                    string onlyNum = line.Remove(0 , "Insert:".Length);
                    string[] numbers = onlyNum.Split(' ');
                    foreach(var item in numbers)
                    {
                        int num;
                        if(Int32.TryParse(item , out num))
                        {
                            tree.Insert(num);
                            Console.WriteLine($"Inserted {num}");
                        }
                    }
                }
                else if(line.Contains("Delete:"))
                {
                    string onlyNum = line.Remove(0 , "Delete:".Length);
                    string[] numbers = onlyNum.Split(' ');
                    foreach(var item in numbers)
                    {
                        int num;
                        if(Int32.TryParse(item , out num))
                        {
                            tree.Delete(num);
                            Console.WriteLine($"Deleted {num}");

                        }
                    }
                }
                else if(line.Contains("Find:"))
                {
                    string onlyNum = line.Remove(0 , "Find:".Length);
                    string[] numbers = onlyNum.Split(' ');
                    foreach(var item in numbers)
                    {
                        int num;
                        if(Int32.TryParse(item , out num))
                        {
                            if(tree.Find(num) != null)
                            {
                                Console.WriteLine($"Found {num}");
                            }
                        }
                    }
                }
            }
        }
        static void Main ( string[] args )
        {
            string path = @"D:\CSharp\ProjectX\AVL2\Commands\Commands.txt";
            DateTime d = DateTime.Now;
            AVL<int> tree = new AVL<int>();
            RunCommands(tree , path);
            tree.Clear();
            TimeSpan elapse = DateTime.Now - d;
            Console.WriteLine(elapse.ToString());
        }
    }
}
