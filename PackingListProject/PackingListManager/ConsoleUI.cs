namespace PackingListManager;

using Spectre.Console;

public class ConsoleUI{

     List<Item> testList = new List<Item>();

    public ConsoleUI(){
        testList.Add(new Item("item1", 1));
        testList.Add(new Item("item2", 2));
        testList.Add(new Item("item3", 3));
    }

    public void Show()
    {
       
        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] {
                    "New list", "Check items off list"
        }));
       
        if(mode=="New list"){
            Console.Write("Enter date of trip: ");
            string date = Console.ReadLine();

            Console.Write("Enter location of trip: ");
            string location = Console.ReadLine();

            string packingListFileName = "packing-list.txt";
            FileSaver fileSaver = new FileSaver(packingListFileName);
            fileSaver.AppendLine(location + ": " + date);

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
        }

        else if(mode=="Check items off list"){
           
            string command;

            do{


                Item selectedItem = AnsiConsole.Prompt(
                    new SelectionPrompt<Item>()
                        .Title("Please select item to check off:")
                        .AddChoices(testList));

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

    public static string AskForInput(string message){
        Console.Write(message);
        return Console.ReadLine();
    }
}