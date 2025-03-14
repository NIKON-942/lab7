namespace lab7;

public static class ListTests
{
    public static void Main()
    {
        ConsoleKey key;
        string[] menuOptions = ["TestCreateEmptyList", "TestCreatingListFromFloats", "TestAddingFloats", "TestAddingNodes", "TestDeletingByValue", "TestDeletingByNode", "TestContainsElement", "TestToArray", "TestToList", "TestClone", "TestGreaterThan", "TestSumOfElementsLessThanFirstNegative", "NewListGreaterThan", "TestDeleteElementsLessThan"];
        var selectedOption = 0;
        
        do
        {
            Console.Clear();
            for (var i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedOption)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(i + 1 + "." + menuOptions[i]);
                Console.ResetColor();
            }
        
            key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedOption = Math.Max(0, selectedOption - 1);
                    break;
                case ConsoleKey.DownArrow:
                    selectedOption = Math.Min(menuOptions.Length - 1, selectedOption + 1);
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    Handle(selectedOption);
                    key = Console.ReadKey().Key;
                    break;
            }
        } while (key != ConsoleKey.Escape);
        Console.Clear();
    }

    private static void Handle(int option)
    {
        switch (option)
        {
            case 0:
                TestCreateEmptyList();
                break;
            case 1:
                TestCreatingListFromFloats();
                break;
            case 2:
                TestAddingFloats();
                break;
            case 3:
                TestAddingNodes();
                break;
            case 4:
                TestDeletingByValue();
                break;
            case 5:
                TestDeletingByNode();
                break;
            case 6:
                TestContainsElement();
                break;
            case 7:
                TestToArray();
                break;
            case 8:
                TestToList();
                break;
            case 9:
                TestClone();
                break;
            case 10:
                TestGreaterThan();
                break;
            case 11:
                TestSumOfElementsLessThanFirstNegative();
                break;
            case 12:
                NewListGreaterThan();
                break;
            case 13:
                TestDeleteElementsLessThan();
                break;
        }
    }
    
    private static void TestCreateEmptyList()
    {
        Console.WriteLine("Test_1");
        var emptyList = new SinglyLinkedListNode();
        Console.WriteLine($"Empty list was created. List: {emptyList}. Count of list values: {emptyList.Count()}");
    }
    
    private static void TestCreatingListFromFloats()
    {
        Console.WriteLine("Test_2");
        Console.WriteLine("Creating list from values: 12.3, 13.4, -41.88, 0, 45");
        var list1 = new SinglyLinkedListNode(12.3f, 13.4f, -41.88f, 0, 45f);
        Console.WriteLine($"Created list: {list1}");
        Console.WriteLine("Creating list from values: 13e-4, -3, 0.52, -1.55, 1.45e3");
        var list2 = new SinglyLinkedListNode(13e-4f, -3f, 0.88f, -1.55f, 1.45e3f);
        Console.WriteLine($"Created list: {list2}");
    }

    private static void TestAddingFloats()
    {
        Console.WriteLine("Test_3");
        var list = new SinglyLinkedListNode();
        Console.WriteLine($"Creating empty list. List: {list}");
        list.AddNodes(2.5f, 77f, 1e-4f, 5f);
        Console.WriteLine($"Adding values 2.5, 77, 1e-4, 5. List: {list}");
        list.AddNodes(77f, 4e5f, 21f, 3e-6f);
        Console.WriteLine($"Adding values 77, 4e5, 21, 3e-6. List: {list}");
    }
    
    private static void TestAddingNodes()
    {
        Console.WriteLine("Test_4");
        var list = new SinglyLinkedListNode(78f, 16.44f);
        Console.WriteLine($"Creating new list with values 78, 16.44. List: {list}");
        var node1 = new SinglyLinkedListNode(50f);
        var node2 = new SinglyLinkedListNode(-2f, 0.33f, 54e-1f);
        Console.WriteLine($"Adding nodes to list: {node1}, {node2}");
        list.AddNodes(node1);
        list.AddNodes(node2);
        Console.WriteLine($"List after adding nodes: {list}");
    }
    
    private static void TestDeletingByValue()
    {
        Console.WriteLine("Test_5");
        var list = new SinglyLinkedListNode(44f, 10.33f, -4.32f, -32f);
        Console.WriteLine($"Creating new list with values 44, 10.33, -4.32, 32. List: {list}");
        list = list.DeleteNode(44f);
        Console.WriteLine($"Deleting value 44. List: {list}");
        list = list.DeleteNode(4f);
        Console.WriteLine($"Deleting value 4. List: {list}");
    }

    public static void TestDeletingByNode()
    {
        Console.WriteLine("Test_6");
        var node1 = new SinglyLinkedListNode(66.2f);
        var node2 = new SinglyLinkedListNode(-3.12f);
        var node3 = new SinglyLinkedListNode(92.134f);
        var node4 = new SinglyLinkedListNode(52f);
        Console.WriteLine($"Creating empty list and adding nodes: {node1}, {node2}, {node3}");
        var list = new SinglyLinkedListNode();
        list.AddNodes(node1, node2, node3);
        list = list.DeleteNode(node2);
        Console.WriteLine($"Trying to delete node {node2}: {list}");
        list = list.DeleteNode(node4);
        Console.WriteLine($"Trying to delete {node4}: {list}");
    }
    
    private static void TestContainsElement()
    {
        Console.WriteLine("Test_7");
        var list = new SinglyLinkedListNode(12f, -6.63f, 8.88f, 12f, -32f);
        Console.WriteLine($"Creating new list with values 12, -6.63, 8.88, 12, -32. List: {list}");
        var check1 = list.Contains(12f);
        var check2 = list.Contains(5f);
        var check3 = list.Contains(8.88f);
        Console.WriteLine("Checking if list contains:");
        Console.WriteLine("--> 12   - " + check1);
        Console.WriteLine("--> 5    - " + check2);
        Console.WriteLine("--> 8.88 - " + check3);
    }
    
    private static void TestToArray()
    {
        Console.WriteLine("Test_8");
        var list = new SinglyLinkedListNode(1e3f, -55f, 3.21f, 0);
        Console.WriteLine($"Creating new list with values 1e3, -55, 3.21, 0. List: {list}");
        Console.WriteLine($"Type of current list: {list.GetType()}");
        var array = list.ToArray();
        Console.WriteLine($"Array from list: {array.ToArray().Aggregate("", (s, f) => s + f + ", ")}");
        Console.WriteLine($"Type of current array {array.GetType()}");
    }
    
    private static void TestToList()
    {
        Console.WriteLine("Test_9");
        var singlyLinkedList = new SinglyLinkedListNode(1e3f, -55f, 3.21f, 0);
        Console.WriteLine($"Creating new list with values 1e3, -55, 3.21, 0. List: {singlyLinkedList}");
        Console.WriteLine($"Type of current list: {singlyLinkedList.GetType()}");
        var list = singlyLinkedList.ToList();
        Console.WriteLine($"Array from list: {list.Aggregate("", (s, f) => s + f + ", ")}");
        Console.WriteLine($"Type of current array {list.GetType()}");
    }
    
    private static void TestClone()
    {
        Console.WriteLine("Test_10");
        var list = new SinglyLinkedListNode(4e-3f, 14f, -4.90f, 0.34f);
        Console.WriteLine($"Creating new list with values 4e-3, 14, -4.90, 0.34. List: {list}");
        var cloned = (SinglyLinkedListNode)list.Clone();
        Console.WriteLine($"Cloning list: {cloned}");
        Console.WriteLine($"Checking if list == cloned: {list == cloned}");
    }

    private static void TestGreaterThan()
    {
        Console.WriteLine("Test_11");
        var list = new SinglyLinkedListNode(55f, -3.52f, 99.08f, 2f, 22f, 33f);
        Console.WriteLine($"Creating new list with values 55, -3.52, 99.08, 2, 22, 33. List: {list}");
        Console.WriteLine($"First bigger than 10.5 is {list.FirstGreaterThan(10.5f)}");
        Console.WriteLine($"First bigger than -5 is {list.FirstGreaterThan(-5)}");
        var noNumber = list.FirstGreaterThan(100);
        Console.WriteLine(noNumber.HasValue
            ? $"First greater than 100 is {noNumber}"
            : "List don't have values greater than 100");
    }
    
    private static void TestSumOfElementsLessThanFirstNegative()
    {
        Console.WriteLine("Test_12");
        var list1 = new SinglyLinkedListNode(34f, -3f, -44.56f, 9f, -8f);
        Console.WriteLine($"Creating new list with values 34, -3, -44.56, 9, -8. List: {list1}");
        Console.WriteLine($"Sum of elements that less than first negative is {list1.SumOfElementsLessThanFirstNegative()}");
        var list2 = new SinglyLinkedListNode(22.7f, -55f, -9f, 33.10f, 16f);
        Console.WriteLine($"Creating new list with values 22.7, -55, -9, 33.10, 16. List: {list2}");
        var sum2 = list2.SumOfElementsLessThanFirstNegative();
        Console.WriteLine(sum2.HasValue
            ? $"Sum of elements that less than first negative is {sum2}"
            : "List don't have values that less than first negative or don't have negative elements");
    }
    
    private static void NewListGreaterThan()
    {
        Console.WriteLine("Test_13");
        var list = new SinglyLinkedListNode(55f, -3.52f, 99.08f, 2f, 11.56f, 92f, 54.5f);
        Console.WriteLine($"Creating new list with values 55, -3.52, 99.08, 2, 11.56, 92, 54.5. List: {list}");
        var newList1 = list.NewListGreaterThan(10.5f);
        Console.WriteLine($"Creating new list with values greater than 10.5 : {newList1}");
        var newList2 = list.NewListGreaterThan(60);
        Console.WriteLine($"Creating new list with values greater than 60 : {newList2}");
    }

    private static void TestDeleteElementsLessThan()
    {
        Console.WriteLine("Test_14");
        var list = new SinglyLinkedListNode(12f, -6.63f, 8.88f, 12f, -32f, 19f, 44f, -40f, -5.45f);
        Console.WriteLine($"Creating new list with values 12, -6.63, 8.88, 12, -32, 19, 44, -40, -5.45. List: {list}");
        var newList1 = list.DeleteElementsLessThan(2.6f);
        Console.WriteLine($"Deleting from list elements less than 2.6 : {newList1}");
        var newList2 = list.DeleteElementsLessThan(40);
        Console.WriteLine($"Deleting from list elements less than 40 : {newList2}");
    }
}
