using Spectre.Console;

namespace PackingListManager;

public class PackingList{

    public string location {get; set;}
    public string date {get; set;}

    public List<Item> Items {get; set;}

    public PackingList(string location, string date){
        this.location = location;
        this.date = date;
        this.Items = new List<Item>();
    }

    public PackingList(){
        this.location = "trip location";
        this.date = "trip date";
        this.Items = new List<Item>();
    }

    public void checkOffItems(){
               Item selectedItem = AnsiConsole.Prompt(
                    new SelectionPrompt<Item>()
                        .Title("Please select item to check off:")
                        .AddChoices(Items));

                Console.WriteLine("You selected " + selectedItem.name);

                string checkOff = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Check off item?")
                        .AddChoices(new[] {
                            "Yes", "No"
                }));

                if(checkOff=="Yes"){
                    if(!selectedItem.isPacked){
                        selectedItem.isPacked = true;
                    }
                    
                    else{
                        Console.WriteLine("This item has already been checked off the list.");
                        string uncheck = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Would you like to uncheck this item off of the list?")
                            .AddChoices(new[] {
                                "Yes", "No"
                        }));
                        if(uncheck == "Yes"){
                            selectedItem.isPacked = false;
                        }
                    }
                }
    }

    public void removeItems(){
               Item selectedItem = AnsiConsole.Prompt(
                    new SelectionPrompt<Item>()
                        .Title("Please select item to delete:")
                        .AddChoices(Items));

                Console.WriteLine("You selected " + selectedItem.name);

                string remove = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Remove item?")
                        .AddChoices(new[] {
                            "Yes", "No"
                }));

                if(remove == "Yes"){
                    Items.Remove(selectedItem);
                }
    }
    
    public void PrintPackingList(){
        Console.WriteLine("Location: " + location);
        Console.WriteLine("Date: " + date);

        foreach(Item item in Items){
            Console.WriteLine(item);
        }
    }
}