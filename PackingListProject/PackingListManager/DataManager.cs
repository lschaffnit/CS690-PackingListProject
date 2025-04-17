namespace PackingListManager;

using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Spectre.Console;

public class DataManager{

    public DataManager(){
        
    }

    public PackingList createNewPackingList(){
              
        string location = "location";
        string date = "date";
        
        Console.Write("Enter location of trip: ");
        location = Console.ReadLine();

        Console.Write("Enter date of trip: ");
        date = Console.ReadLine();

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
                var splitLine= line.Split(":", StringSplitOptions.RemoveEmptyEntries);
                Item item = new Item(splitLine[1], int.Parse(splitLine[2]), bool.Parse(splitLine[0]));
                openedPackingList.Add(item);
            }
            return openedPackingList;
        }

        return null;

    }

    public PackingList createPackingListObjectFromFile(string fileName){

        if(File.Exists(fileName))
        {
            PackingList packingListFromFile = new PackingList();
            var packingListFileContent = File.ReadAllLines(fileName);
            //string listLocation = packingListFileContent[0];
            packingListFromFile.location = packingListFileContent[0];
            //string listDate = packingListFileContent[1];
            packingListFromFile.date = packingListFileContent[1];

            //PackingList openedPackingList = new PackingList(listLocation, listDate);
            //List<Item> openedPackingList = new List<Item>();
                        
            // List<string> fileContentAsList = packingListFileContent.ToList();
            // fileContentAsList.RemoveAt(0); //remove location
            // fileContentAsList.RemoveAt(0); //remove date

            // foreach(var line in fileContentAsList){
            //     var splitLine= line.Split(":", StringSplitOptions.RemoveEmptyEntries);
            //     Item item = new Item(splitLine[1], int.Parse(splitLine[2]), bool.Parse(splitLine[0]));
            //     packingListFromFile.Items.Add(item);
            // }

            packingListFromFile.Items = ProcessPackingList(fileName);
            return packingListFromFile;
        }
        return null;
    }

    public static void createTxtFileFromPackingListObject(PackingList packingList, string fileName){
        FileSaver fileSaver = new FileSaver(fileName);

        fileSaver.AppendLine(packingList.location);
        fileSaver.AppendLine(packingList.date);

        foreach(var item in packingList.Items){
            fileSaver.AppendData(item);
        }
    }
}