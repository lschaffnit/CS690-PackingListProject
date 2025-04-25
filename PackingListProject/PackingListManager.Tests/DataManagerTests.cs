namespace PackingListManager.Tests;

using System.Runtime.CompilerServices;
using PackingListManager;

public class DataManagerTests
{
    DataManager dataManager;
    
    public DataManagerTests()
    {
        File.WriteAllText("test-packing-list.txt", "Location" + Environment.NewLine + "Date" + Environment.NewLine + "False: item one: 2" + Environment.NewLine + "True: item two: 3");
        dataManager = new DataManager();
    }

    [Fact]
    public void Test_CreatePackingListObjectFromFile()
    {
        PackingList testList = dataManager.createPackingListObjectFromFile("test-packing-list.txt");
        Assert.Equal("Location", testList.location);
        Assert.Equal("Date", testList.date);

        Assert.Equal(2, testList.Items.Count);

        Assert.False(testList.Items[0].isPacked);
        var itemOne = testList.Items[0];
        Assert.Equal(" item one", itemOne.name);
        Assert.Equal(2, testList.Items[0].quantity);

        Assert.True(testList.Items[1].isPacked);
        var itemTwo = testList.Items[1];
        Assert.Equal(" item two", itemTwo.name);
        Assert.Equal(3, testList.Items[1].quantity);
    }

    [Fact]
    public void Test_CreateTxtFileFromPackingListObject()
    {
        PackingList testList = new PackingList("Location", "Date");
        testList.Items.Add(new Item("item one", 2));
        testList.Items.Add(new Item("item two", 3));
        testList.Items[1].isPacked = true;
        DataManager.createTxtFileFromPackingListObject(testList, "testlist.txt");
        var testFileContent = File.ReadAllLines("testlist.txt");

        Assert.Equal("Location", testFileContent[0]);
        Assert.Equal("Date", testFileContent[1]);
        Assert.Equal("False: item one: 2", testFileContent[2]);
        Assert.Equal("True: item two: 3", testFileContent[3]);
    }
}