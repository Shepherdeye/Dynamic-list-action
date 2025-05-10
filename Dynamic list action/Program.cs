using System.Data;
using System.Runtime.InteropServices;

namespace Dynamic_list_action
{
    internal class Program
    {
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
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine("\n[ ] - the  list is empty \n");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        else
                        {
                            string tamplateView = "";
                            for (int i = 0; i < values.Count; i++)
                            {
                                tamplateView += $"{values[i]} ";
                            }
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine($"\n[ {tamplateView}]\n");
                            Console.ForegroundColor = ConsoleColor.White;

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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n '{addednum}' Added Successfully \n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"\n'{addednum}' Is already exists\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }




                        break;
                    case "M":


                        if (values.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nUnable To Calculate the Mean No Data.. \n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            double total = 0;
                            for (int i = 0; i < values.Count; i++)
                            {
                                total += values[i];
                            }

                            double avg = total / values.Count;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nAverage: {avg}\n");
                            Console.ForegroundColor = ConsoleColor.White;
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
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine($"\n'{smallest}' is The smallest number\n");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"\n'There is no data in the list'\n");
                            Console.ForegroundColor = ConsoleColor.White;
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
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine($"\n'{largest}' is The largest number\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"\n'There is no data in the list' \n");
                            Console.ForegroundColor = ConsoleColor.White;
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n'{inputnum}' Not Found\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nthe index  of the  number  is '{index}'\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                            break;

                    case "C":

                        values.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nList has been deleted successfully\n");
                        Console.ForegroundColor = ConsoleColor.White;


                        break;

                    case "K":


                        Console.WriteLine("Enter two numbers separated by space :");
                        string[] inputNumbers = Console.ReadLine().Trim().Split();

                        if (inputNumbers.Length < 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nShould Enter two values\n");
                            Console.ForegroundColor = ConsoleColor.White;

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


                            string tamplateView = "";
                            for (int i = 0; i < values.Count; i++)
                            {
                                tamplateView += $"{values[i]} ";
                            }
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine($"\nSwaped Successfully");
                            Console.WriteLine($"\n[ {tamplateView}]\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (!foundedItem)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInputs not found\n");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        break;

                    case "X":

                        Console.WriteLine("Enter numbers separated by space :");

                        string? input = Console.ReadLine();

                        if (input == null || input == "" || input == " ")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Values Required");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        };

                        string[] bulkAdd = input.Trim().Split();


                        for (int i = 0; i < bulkAdd.Length; i++)
                        {
                            values.Add(Convert.ToInt32(bulkAdd[i]));
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nAdded successfully\n");
                        Console.ForegroundColor = ConsoleColor.White;


                        break;



                    case "Y":


                        if (values.Count != 0)
                        {
                            int swap;

                            for (int j = 0; j < values.Count - 1; j++)
                            {
                                for (int i = 0; i < values.Count - 1; i++)
                                {
                                    if (values[i] > values[i + 1])
                                    {
                                        swap = values[i];
                                        values[i] = values[i + 1];
                                        values[i + 1] = swap;

                                    }

                                }

                            }

                            string temp = "";
                            for (int i = 0; i < values.Count; i++)
                            {
                                temp += $"{values[i]} ";
                            }

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n'Order Ascending '\n");
                            Console.WriteLine($"[ {temp}]\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"\n'There is no data in the list'\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                        break;

                    case "D":


                        if (values.Count != 0)
                        {
                            int swap;

                            for (int j = 0; j < values.Count - 1; j++)
                            {
                                for (int i = 0; i < values.Count - 1; i++)
                                {
                                    if (values[i] < values[i + 1])
                                    {
                                        swap = values[i];
                                        values[i] = values[i + 1];
                                        values[i + 1] = swap;

                                    }

                                }

                            }

                            string temp = "";
                            for (int i = 0; i < values.Count; i++)
                            {
                                temp += $"{values[i]} ";
                            }

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n'Order Descending '\n");
                            Console.WriteLine($"[ {temp}]\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"\n'There is no data in the list'\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case "Q":


                        Console.WriteLine("\nGoodbye  ..\n");

                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n'{choice}' Unknown Selection Please Try Again \n\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }

            } while (choice != "Q");



        }
    }
}