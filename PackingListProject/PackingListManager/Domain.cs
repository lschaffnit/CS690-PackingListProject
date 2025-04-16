using System.Reflection.Metadata.Ecma335;
using Spectre.Console;

namespace PackingListManager;

public class PackingList{

    public string location {get;}
    public string date {get;}

    public List<Item> Items {get;}

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

    public void addItem(Item item)
    {
        Items.Add(item);
    }

}

public class Item{
    public string name {get;}
    public int quantity {get;}

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
        string status;
        if(isPacked){
            status = ":check_mark:";
        }
        else{
            status = ":cross_mark:";
        }

        return status + " " + this.name + ": " + this.quantity;
    }
}