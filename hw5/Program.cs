using hw5;
using System.IO;
using System.Security.AccessControl;

namespace hw5
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1\n2\n3");
            int choi=int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choi)
            {
                case 1:
                    string paath = @"E:\New folder";
                    string inp = Console.ReadLine();
                    q_1(paath, inp);
                    break;
                    case 2:
                string patah = @"E:\New folder";

                    q_2(patah);
                    break;
                    case 3:
                    {

                        Console.Write("x= ");
                        int? x = int.Parse(Console.ReadLine());
                        Console.Write("y= ");
                        int? y = int.Parse(Console.ReadLine());
                        Console.Write("The desired file");

                        string path = Console.ReadLine();

                        q_3(x, y, path);

                        break;
                    }
            }
        }
        static void q_3(int? x, int? y, string path)
        {
            int con = 0;
            string? exp = null;
            try
            {
                if (x == null || y == null)
                {
                    throw new ArgumentNullException("At least one of the variables is null");

                }
                else if (y == 0)
                {
                    throw new DivideByZeroException("y=0 ");
                }
                else
                {
                    int math = (int)(x / y);
                    Console.WriteLine($"x/y= {math}");
                }
            }
            catch (DivideByZeroException ex)
            {
                exp = ex.Message;
                con++;
            }
            catch (ArgumentNullException ex)
            {
                con++;
                exp = ex.Message;
            }
            catch (FormatException ex)
            {
                exp = ex.Message;
                con++;

            }
            try {

                string str = $@"{path}";
                var attribute = new FileInfo(path);
                var Readonly = attribute.IsReadOnly;
                if (File.Exists(str))
                {
                    Console.WriteLine("Found");
                    Console.ReadKey();
                    File.Delete(str);
                    Console.WriteLine("File is deleted");
                    Console.ReadKey();
                }

                else
                {
                    throw new FileNotFoundException("Not Found");

                }
            }
            
           
            catch (FileNotFoundException e)
            {
                if (con == 0)
                {
                    exp = (e.Message);
                }
                else
                {
                    exp= exp+"\n"+(e.Message);
                }
            }
            
            catch(Exception e)
            {
                if (con == 0)
                {
                    exp = (e.Message);
                }
                else
                {
                    exp =exp+ "\n" + (e.Message);
                }
            }
            finally {
                if (exp != null)
                {
                    File.Create(@"E:\New folder\Exception.txt").Close();
                    File.ReadAllLines(@"E:\New folder\Exception.txt");
                   File.WriteAllText(@"E:\New folder\Exception.txt", exp);


                }
            }
        }
        static void q_2(string path)
        {
            var filepath = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);

            foreach (var item in filepath)
            {
               
                bool v = item.Contains("maktab");
                if (!v)
                {
                    var c = item.Replace("msktab", "maktab").Replace("maktsb", "maktab").Replace("naktab", "maktab");
                   
                    File.Move(item, c);
                }
            }
        }
        static void q_1 (string path, string input)
        {
            int co = 0;

            var filepath = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);

            foreach (var item in filepath)
            {
                int i = 1;
                
            var File1 = File.ReadAllLines(item);
                foreach (var it in File1)
                {
                    if (it.Contains(input))
                    {
                        Console.WriteLine("{0}  line : {1} {2}",Path.GetFileName(item),i,it);
                        co++;
                    }
                    i++;
                }
            }
            if (co == 0)
            {
                Console.WriteLine("not found");
            }
           
        }

    }
}
