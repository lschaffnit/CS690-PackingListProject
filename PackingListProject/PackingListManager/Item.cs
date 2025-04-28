namespace PackingListManager;

public class Item{
    public string name {get; set;}
    public int quantity {get; set;}

    public bool isPacked {get; set;}

    public Item(string name, int quantity){
        this.name = name;
        this.quantity = quantity;
        this.isPacked = false;
    }

    public Item(string name, int quantity, bool isPacked){
        this.name = name;
        this.quantity = quantity;
        this.isPacked = isPacked;
    }

    public override string ToString() {
        string status = "";
        if(isPacked){
            status = "\u2713"; //checkmark 
        }
        else{
            status = "X";
        }

        return status + " " + this.name.Trim() + ": " + this.quantity;
    }
}