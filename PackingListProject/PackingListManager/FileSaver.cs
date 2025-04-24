namespace PackingListManager;

using System.IO;

public class FileSaver{
    string fileName;

    public FileSaver(string fileName){
        this.fileName = fileName;
        File.Create(this.fileName).Close();
    }

    public void AppendLine(string line){
        File.AppendAllText(this.fileName, line + Environment.NewLine);
    }

    public void AppendData(Item item){
        File.AppendAllText(this.fileName, item.isPacked + ": " + item.name.Trim() + ": " + item.quantity + Environment.NewLine);
    }
}