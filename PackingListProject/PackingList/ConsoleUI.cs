namespace PackingList;

public class ConsoleUI{

    public ConsoleUI(){

    }

    public void Show()
    {
        string mode = AskForInput("Select mode: create a new list (new) or open list (open)");;

        if(mode=="new"){
            Console.Write("Enter date of trip: ");
            string date = Console.ReadLine();

            Console.Write("Enter location of trip: ");
            string location = Console.ReadLine();

            string packingListFileName = location + date + ".txt";
            FileSaver fileSaver = new FileSaver(packingListFileName);
            fileSaver.AppendLine(location + ": " + date);

            string command;

            do{

                string itemName = AskForInput("Enter name of item: ");
                
                int numItem = int.Parse(AskForInput("Enter quantity: "));

                //File.AppendAllText("test-packing-list.txt", itemName + ": " + numItem + Environment.NewLine);
                fileSaver.AppendLine(itemName + ": " + numItem);

                command = AskForInput("Enter command (end OR continue): ");
            }
            while(command != "end");
        }
    }

    public static string AskForInput(string message){
        Console.Write(message);
        return Console.ReadLine();
    }
}