namespace PackingListManager.Tests;
using PackingListManager;

public class FileSaverTests
{
    FileSaver fileSaver;
    string testFileName;

    public FileSaverTests(){
        testFileName = "test-PackingList.txt";
        fileSaver = new FileSaver(testFileName);
    }
   
    [Fact]
    public void Test_FileSaver_Append()
    {
        fileSaver.AppendLine("Hello, World!");
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("Hello, World!" + Environment.NewLine, contentFromFile);
    }

    [Fact]
    public void Test_FileSaver_AppendData()
    {
        Item testItem = new Item("test item 1", 1);
       
        fileSaver.AppendData(testItem);
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal("False test item 1: 1" + Environment.NewLine, contentFromFile);
    }
}
