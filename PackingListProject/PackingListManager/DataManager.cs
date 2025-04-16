namespace PackingListManager;

using System.Runtime.CompilerServices;
using Spectre.Console;

public class DataManager{
    
    //FileSaver fileSaver;
    //public List<Item> testList = new List<Item>();
   // public List<Item> testList {get;}
    //PackingList packingList;

    public DataManager(){
        

        //fileSaver = new FileSaver("packing-list.txt");
        
        // testList = new List<Item>();
        // testList.Add(new Item("item1", 1));
        // testList.Add(new Item("item2", 2));
        // testList.Add(new Item("item3", 3));

        //packingList = new PackingList();
    }

    public PackingList createNewPackingList(){
              
        string location = "location";
        string date = "date";
        
        Console.Write("Enter location of trip: ");
        location = Console.ReadLine();
        //packingList.location = Console.ReadLine();

        Console.Write("Enter date of trip: ");
        date = Console.ReadLine();
        //packingList.date = Console.ReadLine();

        //string packingListFileName = "packing-list.txt";

        FileSaver fileSaver = new FileSaver("packing-list.txt");

        PackingList newPackingList = new PackingList(location, date);

        fileSaver.AppendLine(location);
        fileSaver.AppendLine(date);

        string command;

            do{

                string itemName = AskForInput("Enter name of item: ");
                int numItem = int.Parse(AskForInput("Enter quantity: "));
                Item item = new Item(itemName, numItem);

                fileSaver.AppendData(item);

                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What's next?")
                        .AddChoices(new[] {
                            "Continue", "End"
                }));
            }
            while(command != "End");
        return newPackingList;
    }

    public static string AskForInput(string message){
        Console.Write(message);
        return Console.ReadLine();
    }

    public List<Item> ProcessPackingList(string fileName){
        if(File.Exists(fileName))
        {

            var packingListFileContent = File.ReadAllLines(fileName);
            string listLocation = packingListFileContent[0];
            string listDate = packingListFileContent[1];

            //PackingList openedPackingList = new PackingList(listLocation, listDate);
            List<Item> openedPackingList = new List<Item>();
                        
            List<string> fileContentAsList = packingListFileContent.ToList();
            fileContentAsList.RemoveAt(0); //remove location
            fileContentAsList.RemoveAt(0); //remove date

            foreach(var line in fileContentAsList){
                //Console.WriteLine(line);
                var splitLine= line.Split(":", StringSplitOptions.RemoveEmptyEntries);
                // Console.WriteLine("item name: " + splitLine[1]);
                // Console.WriteLine("item quantity: " + splitLine[2]);
                // Console.WriteLine("packed: " + splitLine[0]);
                Item item = new Item(splitLine[1], int.Parse(splitLine[2]), bool.Parse(splitLine[0]));
                //openedPackingList.addItem(item);
                openedPackingList.Add(item);
            }
            //Console.WriteLine(packingListFileContent[0]);
            //foreach(var line in packingListFileContent){
                //Console.WriteLine(line);
                
            //}
            return openedPackingList;
        }

        return null;

    }
}