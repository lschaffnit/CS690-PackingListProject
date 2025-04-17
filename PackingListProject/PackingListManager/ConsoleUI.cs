namespace PackingListManager;

using Spectre.Console;
using Spectre.Console.Cli;

public class ConsoleUI{
    DataManager dataManager;
    public ConsoleUI(){
        dataManager = new DataManager();
    }

    public void Show()
    {
       
        PackingList packingList = new PackingList();
        
        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] {
                    //"New list", "Check items off list"
                    "New list", "Open list"
        }));
       
        if(mode=="New list"){
            
            //dataManager = new DataManager();
            packingList = dataManager.createNewPackingList();

        }

        else if(mode == "Open list"){
            //List<Item> openedList = dataManager.ProcessPackingList("packing-list.txt");
            packingList = dataManager.createPackingListObjectFromFile("packing-list.txt");
            
           
        }
        
        List<Item> listOfItems = packingList.Items;

        var mode2 = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Would you like to check items off of this list?")
                .AddChoices(new[] {
                    "Yes", "No"
        }));
        
        if(mode2 == "Yes")
        {
            //List<Item> listOfItems = packingList.Items;
            string command = "";

            do{
            
                //List<Item> listOfItems = dataManager.ProcessPackingList("packing-list.txt");
               // List<Item> listOfItems = packingList.Items;
                Item selectedItem = AnsiConsole.Prompt(
                    new SelectionPrompt<Item>()
                        .Title("Please select item to check off:")
                        .AddChoices(listOfItems));

                Console.WriteLine("You selected " + selectedItem.name);

                string checkOff = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Check off item?")
                        .AddChoices(new[] {
                            "Yes"
                }));

                if(checkOff=="Yes"){
                    selectedItem.isPacked = true;
                }

                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What's next?")
                        .AddChoices(new[] {
                            "Continue", "End"
                }));
            }
            while(command != "End");

            //update packinglist file
            DataManager.createTxtFileFromPackingListObject(packingList, "packing-list.txt");

        }
        else
        {
            Console.WriteLine("Goodbye");
        }


    
    }
}