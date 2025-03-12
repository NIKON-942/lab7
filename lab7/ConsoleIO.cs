// namespace lab7;
//
// public class ConsoleIO
// {
     // public static void Main()
     // {
     //     ConsoleKey key;
     //     var list = new SinglyLinkedListNode();
     //     
     //     string[] menuOptions = ["Add element", "Delete element", "(Task 1) Find first bigger than", "(Task 2) Find sum of elements less than first negative", "(Task 3) New list bigger than", "(Task 4) Delete lower than"];
     //     var selectedOption = 0;
     //     
     //     do
     //     {
     //         Console.Clear();
     //         Console.WriteLine($"List: {list}");
     //         
     //         for (var i = 0; i < menuOptions.Length; i++)
     //         {
     //             if (i == selectedOption)
     //             {
     //                 Console.BackgroundColor = ConsoleColor.Gray;
     //                 Console.ForegroundColor = ConsoleColor.Black;
     //             }
     //             Console.WriteLine(i + 1 + "." + menuOptions[i]);
     //             Console.ResetColor();
     //         }
     //
     //         key = Console.ReadKey().Key;
     //         switch (key)
     //         {
     //             case ConsoleKey.UpArrow:
     //                 selectedOption = Math.Max(0, selectedOption - 1);
     //                 break;
     //             case ConsoleKey.DownArrow:
     //                 selectedOption = Math.Min(menuOptions.Length - 1, selectedOption + 1);
     //                 break;
     //             case ConsoleKey.Enter:
     //                 HandleOption(selectedOption, ref list);
     //                 break;
     //         }
     //     } while (key != ConsoleKey.Escape);
     //     Console.Clear();
     // }
//
//     private static void HandleOption(int selectedOption, ref SinglyLinkedListNode list)
//     {
//         Console.Clear();
//         switch (selectedOption)
//         {
//             case 0:
//                 Console.Write("Enter a new element of list: ");
//                 var newValue = ReadFloat();
//                 list.AddNodes(newValue);
//                 Console.WriteLine("Node successfully added");
//                 break;
//             case 1:
//                 Console.Write("Enter a value of element to delete: ");
//                 var toDelete = ReadFloat();
//                 list = list.DeleteNode(toDelete);
//                 Console.WriteLine("Node successfully deleted");
//                 break;
//             case 2:
//                 Console.Write("Enter a value to find the first greater: ");
//                 var greaterThan = ReadFloat();
//                 var greaterValue = list.FirstBiggerThan(greaterThan);
//                 Console.WriteLine(greaterValue != null 
//                     ? $"First value greater than {greaterThan} is {greaterValue}" 
//                     : "No node found with greater value");
//                 break;
//             case 3:
//                 var sum = list.SumOfElementsLessThanFirstNegative();
//                 Console.WriteLine(sum != null 
//                     ? $"Sum of elements that less than first negative is {sum}" 
//                     : "List doesn't have elements less than first negative element");
//                 break;
//             case 4:
//                 Console.Write("Enter a value to create new list with values greater than: ");
//                 var listGreaterThan = ReadFloat();
//                 var greaterList = list.NewListGreaterThan(listGreaterThan);
//                 if (greaterList != null)
//                 {
//                     Console.WriteLine($"New list with values greater than {listGreaterThan}: {greaterList}");
//                     Console.WriteLine("Do you want to replace the previous list with the new one? (1-yes/2-no)");
//                     if (ReadInt() == 1)
//                         list = greaterList;
//                 }
//                 break;
//             case 5:
//                 Console.Write("Enter a value elements lower that you want to delete: ");
//                 var deleteLessThan = ReadFloat();
//                 list = list.DeleteElementsLowerThan(deleteLessThan);
//                 Console.WriteLine($"Elements lower than {deleteLessThan} deleted");
//                 break;
//         }
//         Console.ReadKey();
//     }
//
//     private static float ReadFloat()
//     {
//         float? value = null;
//         while (value == null)
//         {
//             try
//             {
//                 value = Convert.ToSingle(Console.ReadLine());
//             }
//             catch (Exception e)
//             {
//                 Console.Write("Entered incorrect value. Try again: ");
//             }
//         }
//         return value.Value;
//     }
//     
//     private static int ReadInt()
//     {
//         int? value = null;
//         while (value == null)
//         {
//             try
//             {
//                 value = Convert.ToInt32(Console.ReadLine());
//             }
//             catch (Exception e)
//             {
//                 Console.Write("Entered incorrect value. Try again: ");
//             }
//         }
//         return value.Value;
//     }
// }