using System.Data;
using System.Runtime.InteropServices;

namespace methods
{
    internal class Program
    {


        static List<int> Sorting( List<int> listname, string type)
        {
            if (listname.Count != 0)
            {
                if (type == "A")
                {

                    int swap;

                    for (int j = 0; j < listname.Count - 1; j++)
                    {
                        for (int i = 0; i < listname.Count - 1; i++)
                        {
                            if (listname[i] > listname[i + 1])
                            {
                                swap = listname[i];
                                listname[i] = listname[i + 1];
                                listname[i + 1] = swap;

                            }

                        }

                    }
                    string temp = PrintWithFormat(listname);
                    MessageSuccess($"[ {temp}]", "Order Ascending");
                }
                else if (type == "D")
                {

                    int swap;

                    for (int j = 0; j < listname.Count - 1; j++)
                    {
                        for (int i = 0; i < listname.Count - 1; i++)
                        {
                            if (listname[i] < listname[i + 1])
                            {
                                swap = listname[i];
                                listname[i] = listname[i + 1];
                                listname[i + 1] = swap;

                            }

                        }

                    }
                    string temp = PrintWithFormat( listname);

                    MessageSuccess($"[ {temp}]", "Order Descending");
                }

            }
            else
            {
                MessageError("There is no data in the list");

            }
            return listname;
        }

        static string PrintWithFormat( List<int> listname)
        {
            string tamplateView = "";
            for (int i = 0; i < listname.Count; i++)
            {
                tamplateView += $"{listname[i]} ";
            }

            return tamplateView;
        }

        static void MessageSuccess(string message, string title = "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{title} \n");
            Console.WriteLine($" {message}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void MessageError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Main(string[] args)

        {
            // dynamic list actions

            //values
            List<int> values = [];

            string choice = default;


            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine($"\nMain menu\nP => Print numbers \nA => Add a number(Bouns => 'without duplication ')\n" +
                    $"M => Calculate the Average\nS => Smallest number\nL => Largest Number\n" +
                    $"F => Search For Value\nC => Clear the list \n" +
                    $"K => Swap two Numbers (Bouns)\n" +
                    $"X => Add Bulk of numbers (Bouns)\n" +
                    $"Y => Ordered Ascending (Bouns)\n" +
                    $"D => Ordered Descending (Bouns)\n" +
                    $"Q => Quit\n ");

                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("Enter Your Choice\n");
                choice = Console.ReadLine().Trim().ToUpper();


                switch (choice)

                {

                    case "P":
                        if (values.Count == 0)
                        {
                            MessageError("[ ] - the  list is empty");
                        }
                        else
                        {
                            string tamplateView = PrintWithFormat( values);
                            MessageSuccess($"[ {tamplateView} ]", "List numbers view");
                        }

                        break;

                    case "A":

                        Console.Write("Enter number: ");
                        int addednum = Convert.ToInt32(Console.ReadLine().Trim());
                        bool founded = false;
                        for (int i = 0; i < values.Count; i++)
                        {
                            if (addednum == values[i])
                            {
                                founded = true;
                                break;
                            }

                        }

                        if (!founded)
                        {
                            values.Add(addednum);
                            MessageSuccess($"'{addednum}' Added Successfully");

                        }
                        else
                        {
                            MessageError($"\n'{addednum}' Is already exists");

                        }

                        break;
                    case "M":


                        if (values.Count == 0)
                        {
                            MessageError("Unable To Calculate the Mean No Data..");
                        }
                        else
                        {
                            double total = 0;
                            for (int i = 0; i < values.Count; i++)
                            {
                                total += values[i];
                            }

                            double avg = total / values.Count;

                            MessageSuccess($"Average: {avg}");

                        }

                        break;

                    case "S":


                        if (values.Count != 0)
                        {
                            int smallest = values[0];
                            for (int i = 0; i < values.Count; i++)
                            {
                                if (values[i] < smallest)
                                {
                                    smallest = values[i];
                                }
                            }

                            MessageSuccess($"\n'{smallest}' is The smallest number\n");
                        }
                        else
                        {
                            MessageError($"There is no data in the list");
                        }

                        break;
                    case "L":
                        if (values.Count != 0)
                        {
                            int largest = values[0];

                            for (int i = 0; i < values.Count; i++)
                            {
                                if (values[i] > largest)
                                {
                                    largest = values[i];
                                }
                            }

                            MessageSuccess($"'{largest}' is The largest number");

                        }
                        else
                        {
                            MessageError($"There is no data in the list");
                        }

                        break;

                    case "F":

                        Console.WriteLine("Enter the number you are looking for");

                        int inputnum = Convert.ToInt32(Console.ReadLine());


                        int index = -1;


                        for (int i = 0; i < values.Count; i++)
                        {
                            if (values[i] == inputnum)
                            {
                                index = i;

                                break;
                            }
                        }
                        if (index == -1)
                        {
                            MessageError($"'{inputnum}' Not Found");

                        }
                        else
                        {
                            MessageSuccess($"the index  of the  number  is '{index}'");

                        }


                        break;

                    case "C":

                        values.Clear();
                        MessageSuccess("List has been deleted successfully");

                        break;

                    case "K":


                        Console.WriteLine("Enter two numbers separated by space :");
                        string[] inputNumbers = Console.ReadLine().Trim().Split();

                        if (inputNumbers.Length < 2)
                        {
                            MessageError("Should Enter two values");
                            break;
                        }
                        int inputOne = Convert.ToInt32(inputNumbers[0]);
                        int inputTWo = Convert.ToInt32(inputNumbers[1]);


                        List<int> indexes = new List<int>();

                        bool foundedItem = false;
                        for (int i = 0; i < values.Count; i++)
                        {
                            if (inputOne == values[i] || inputTWo == values[i])
                            {
                                indexes.Add(i);
                            }

                        }

                        if (indexes.Count == 2)
                        {
                            foundedItem = true;
                            int temp = values[indexes[0]];
                            values[indexes[0]] = values[indexes[1]];
                            values[indexes[1]] = temp;

                            string tamplateView = PrintWithFormat(values);

                            MessageSuccess($"\n[ {tamplateView}]\n", "Swaped Successfully");
                        }

                        if (!foundedItem)
                        {
                            MessageError("Inputs not found");
                        }
                        break;

                    case "X":

                        Console.WriteLine("Enter numbers separated by space :");

                        string? input = Console.ReadLine();

                        if (input == null || input == "" || input == " ")
                        {
                            MessageError("Values Required");
                            break;
                        }


                        string[] bulkAdd = input.Trim().Split();

                        for (int i = 0; i < bulkAdd.Length; i++)
                        {
                            values.Add(Convert.ToInt32(bulkAdd[i]));
                        }

                        string formatView = PrintWithFormat(values);
                        MessageSuccess($"[ {formatView}]", "Added successfully");

                        break;

                    case "Y":

                        Sorting( values, "A");

                        break;

                    case "D":

                        Sorting( values, "D");

                        break;
                    case "Q":


                        MessageSuccess("Goodbye..");

                        break;
                    default:
                        MessageError($"\n'{choice}' Unknown Selection Please Try Again \n\n");
                        break;
                }

            } while (choice != "Q");



        }
    }
}