namespace PackingList;

using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select mode: create a new list (new) or open list (open)");
        string mode = Console.ReadLine();

        if(mode=="new"){
            Console.Write("Enter date of trip: ");
            string date = Console.ReadLine();

            Console.Write("Enter location of trip: ");
            string location = Console.ReadLine();

            File.AppendAllText("test-packing-list.txt", location+ ": " + date + Environment.NewLine);

            string command;

            do{

                Console.Write("Enter name of item: ");
                string itemName = Console.ReadLine();

                Console.Write("Enter quantity: ");
                int numItem = int.Parse(Console.ReadLine());

                File.AppendAllText("test-packing-list.txt", itemName + ": " + numItem + Environment.NewLine);

                Console.Write("Enter command (end OR continue): ");
                command = Console.ReadLine();
            }
            while(command != "end");
        }
    }
}
