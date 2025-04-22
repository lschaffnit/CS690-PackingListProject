namespace PackingListManager;

using Spectre.Console;
//using Spectre.Console.Cli;

public class ConsoleUI{
    DataManager dataManager;
    public ConsoleUI(){
        dataManager = new DataManager();
    }

    public void Show()
    {
       
        PackingList packingList = new PackingList();
        
        //create a new list or open the existing list
        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] {
                    "New list", "Open list"
        }));
       
        if(mode=="New list"){
            
            dataManager.createNewPackingList();
            packingList = dataManager.createPackingListObjectFromFile("packing-list.txt");

        }

        else if(mode == "Open list"){

            packingList = dataManager.createPackingListObjectFromFile("packing-list.txt");
            packingList.PrintPackingList();

        }
        
        List<Item> listOfItems = packingList.Items;

        //check off items on list
        var mode2 = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Would you like to check items off of this list?")
                .AddChoices(new[] {
                    "Yes", "No"
        }));
        
        if(mode2 == "Yes")
        {
            string command = "";

            do{
                packingList.checkOffItems();
                packingList.PrintPackingList();

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

        Console.WriteLine("\nHere's your final packing list: \n");
        packingList.PrintPackingList();


    
    }
}