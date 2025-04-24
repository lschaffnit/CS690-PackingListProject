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
       
        if(mode=="New list" || !File.Exists("packing-list.txt")){
            
            dataManager.createNewPackingList();
            packingList = dataManager.createPackingListObjectFromFile("packing-list.txt");

        }

        else if(mode == "Open list"){

            packingList = dataManager.createPackingListObjectFromFile("packing-list.txt");
            packingList.PrintPackingList();
    
        }
        
        List<Item> listOfItems = packingList.Items;

        var mode2 = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What's next?")
                .AddChoices(new[] {
                    "Check items off of this list", "Edit this list", "Done with this list"
        }));
        
        if(mode2 == "Check items off of this list")
        {
            string command = "";

            do{
                packingList.checkOffItems();
                packingList.PrintPackingList();

                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What's next?")
                        .AddChoices(new[] {
                            "Check off another item", "Done checking off items"
                }));
            }
            while(command != "Done checking off items");

            //update packinglist file
            DataManager.createTxtFileFromPackingListObject(packingList, "packing-list.txt");

        }

        else if(mode2 == "Edit this list"){
            string editMode = "";
            do{
                editMode = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What's next?")
                        .AddChoices(new[] {
                            "Add item", "Edit item", "Remove item", "Done editing list"
                }));

                if(editMode == "Add item"){

                    dataManager.addItem(packingList);

                }
                else if(editMode == "Remove item"){
                    packingList.removeItems();
                }
            }
            while(editMode != "Done editing list");
        }

        Console.WriteLine("\nHere's your final packing list: \n");
        packingList.PrintPackingList();


    
    }
}