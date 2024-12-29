namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pick type:\n1. Sorting\n2. Trees\n");
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '1':
                    Sort.Begin();
                    break;
                case '2':
                    Trees.Begin();
                    break;
                default:
                    break;
            }
            
        }
    }
}
