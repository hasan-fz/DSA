namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pick type:");
            Console.WriteLine("1. Sorting");
            Console.WriteLine("2. Trees");
            Console.WriteLine();
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '1':
                    Sort.Begin();
                    break;
                default:
                    break;
            }
            
        }
    }
}
