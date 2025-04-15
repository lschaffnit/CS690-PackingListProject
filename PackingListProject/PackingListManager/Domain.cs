using System.Reflection.Metadata.Ecma335;
using Spectre.Console;

namespace PackingListManager;

public class PackingList{

    public string name {get;}
    public string date {get;}

    public List<Item> Items {get;}

    public PackingList(string name, string date){
        this.name = name;
        this.date = date;
        this.Items = new List<Item>();
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