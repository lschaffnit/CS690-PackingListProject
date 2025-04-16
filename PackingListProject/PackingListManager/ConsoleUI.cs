namespace PackingListManager;

using Spectre.Console;

public class ConsoleUI{
    DataManager dataManager;
    public ConsoleUI(){
        dataManager = new DataManager();
    }

    public void Show()
    {
       
        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] {
                    //"New list", "Check items off list"
                    "New list", "Open list"
        }));
       
        if(mode=="New list"){
            
            //dataManager = new DataManager();
            dataManager.createNewPackingList();

        }

        else if(mode == "Open list"){
            List<Item> openedList = dataManager.ProcessPackingList("packing-list.txt");

        // else if(mode=="Check items off list"){
           
            string command = "";

            do{
                Item selectedItem = AnsiConsole.Prompt(
                    new SelectionPrompt<Item>()
                        .Title("Please select item to check off:")
                        .AddChoices(openedList));

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
        }
    }

    
}