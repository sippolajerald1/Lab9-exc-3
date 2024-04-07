using System.ComponentModel.Design;

namespace Lab9_exc_3
{

    public class Receipt
    {
        public string Bag { get; set; }
        public int numberOfBags { get; set; }
        public double priced { get; set; }

        public static Receipt operator ++(Receipt receipt)
        {
            ++receipt.numberOfBags;
            Console.WriteLine(receipt.numberOfBags);
            return receipt;
        }

        public static Receipt operator --(Receipt receipt)
        {
            --receipt.numberOfBags;
            Console.WriteLine(receipt.numberOfBags);
            return receipt; 
        }

        public static Receipt operator +(Receipt receipt1, int nmbrOfBags)
        {
            receipt1.numberOfBags += nmbrOfBags;
            return receipt1;
        }

        public static Receipt operator -(Receipt receipt1, int nmbrOfBags)
        {
            receipt1.numberOfBags -= nmbrOfBags;
            return receipt1;
        }

        public static bool operator >(Receipt receipt1, Receipt receipt2)
        {
            bool larger = false;
            if (receipt1.numberOfBags > receipt2.numberOfBags)
            larger = true;
            return larger;
        }

        public static bool operator < (Receipt receipt1, Receipt receipt2)
        {
            bool smaller = false;
            if (receipt1.numberOfBags < receipt2.numberOfBags)
                smaller = true;
            return smaller;
        }



        internal class Program
        {
            static void Main(string[] args)
            {
                Receipt[] myReceipts = new Receipt[100];
                for (int i = 0; i < myReceipts.Length; i++)
                {
                    myReceipts[i] = new Receipt();
                }
                int selection = Menu();
                int index = 0, entry = 0;
                string ans = "";
                while (selection != 6)
                {
                    switch (selection)
                    {
                        case 1:
                            if (index < 100)
                            {
                                Console.WriteLine("Price per Bag: ");
                                myReceipts[index].priced = double.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Console.WriteLine("Type of bag (paper or plastic or natural): ");
                                myReceipts[index].Bag = Console.ReadLine();
                                Console.WriteLine();
                                Console.WriteLine("Number of bags: ");
                                myReceipts[index].numberOfBags = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                index++;
                            }
                            else
                                Console.WriteLine("You have enterred too many entries - see programming");
                            break;
                        case 2:
                            for (int i = 0; i < myReceipts.Length; i++)
                            {
                                if (myReceipts[i].Bag != "" && myReceipts[i].Bag != null)
                                {
                                    Console.WriteLine($"Type of Bag: {myReceipts[i].Bag}");
                                    Console.WriteLine($"Number of bags: {myReceipts[i].numberOfBags}");
                                    Console.WriteLine($"Price of bags: {myReceipts[i].priced}");

                                }
                            }
                            break;

                        case 3:
                            entry = pickEntry(index);
                            Console.Write("Change price Y for Yes ");
                            ans = Console.ReadLine();
                            if (ans == "Y" || ans == "y")
                            {
                                Console.Write("Price: ");
                                myReceipts[entry].priced = double.Parse(Console.ReadLine());
                            }
                            Console.WriteLine();
                            Console.Write("Change number of bags:  Y for Yes ");
                            ans = Console.ReadLine();
                            if (ans == "Y" || ans == "y")
                            {
                                Console.Write("Number of bags: ");
                                myReceipts[entry].numberOfBags = int.Parse(Console.ReadLine());
                            }
                            Console.WriteLine();
                            break;

                        case 4:
                            entry = pickEntry(index);

                            Console.Write("Increase number of bags by 1? Y for Yes");
                            ans = Console.ReadLine();
                            if (ans == "Y" || ans == "y")
                            {
                                // calls the operator++ method
                                myReceipts[entry]++;
                                Console.WriteLine();
                                break;
                            }

                            Console.Write("Decrease number of bags by 1? Y for Yes ");
                            ans = Console.ReadLine();
                            if (ans == "Y" || ans == "y")
                            {
                                // calls the operator-- method
                                myReceipts[entry]--;
                                Console.WriteLine();
                                break;
                            }

                            Console.Write("Increase number of bags > 1? Y for Yes");
                            ans = Console.ReadLine();
                            if (ans == "Y" || ans == "y")
                            {
                                Console.Write("Enter the number of bags: ");
                                int bgs;
                                while (!int.TryParse(Console.ReadLine(), out bgs))
                                    Console.WriteLine($"Please a number");
                                // calls the operator+ method
                                // the method should receive an
                                // object and a integer as arguments
                                myReceipts[entry] += bgs;
                                Console.WriteLine();
                                break;
                            }

                            Console.Write("Decrease number of bags > 1? Y for Yes");
                            ans = Console.ReadLine();
                            if (ans == "Y" || ans == "y")
                            {
                                Console.Write("Enter the number of bags: ");
                                int bgs;
                                while (!int.TryParse(Console.ReadLine(), out bgs))
                                    Console.WriteLine("Please a number");
                                // calls the operator- method
                                // the method should receive an
                                // object and a integer as arguments
                                myReceipts[entry] -= bgs;
                                Console.WriteLine();
                                break;
                            }

                            break;
                        case 5:
                            Receipt totalPaper = new Receipt();
                            totalPaper.Bag = "Paper ";
                            //totalPaper.numberOfBags = int.Parse("Total paper numbers ");
                            Receipt totalPlastic = new Receipt();
                            totalPlastic.Bag = "Plastic ";
                            //totalPlastic.numberOfBags = int.Parse("Total plastic numbers ");
                            Receipt totalNatural = new Receipt();
                            totalNatural.Bag = "Natural ";
                            //totalNatural.numberOfBags = int.Parse("Total natural numbers ");
                            for (int i = 0; i < myReceipts.Length; i++)
                            {
                                switch (myReceipts[i].Bag)
                                {
                                    case "Paper": case "paper":
                                        totalPaper.numberOfBags += myReceipts[i].numberOfBags;
                                        break;
                                    case "Plastic": case "plastic":
                                        totalPlastic.numberOfBags += myReceipts[i].numberOfBags;
                                        break;
                                    case "Natural": case "natural":
                                        totalNatural.numberOfBags += myReceipts[i].numberOfBags;
                                        break;

                                }
                            }
                            Console.WriteLine("Total number of bags by type");
                            //calls operator >
                            if (totalPaper > totalPlastic && totalPaper > totalNatural)
                            {
                                Console.WriteLine("The largest number of bags was spent on paper!");
                                Console.WriteLine($"Your total paper number of bags = {totalPaper.numberOfBags}");
                                Console.WriteLine($"Your total plastic number of bags = {totalPlastic.numberOfBags}");
                                Console.WriteLine($"Your total natural number of bags = {totalNatural.numberOfBags}");
                            }
                            // calls operator >
                            else if (totalPlastic > totalPaper && totalPlastic > totalNatural)
                            {
                                Console.WriteLine("The largest number of bags was spent on plastic");
                                Console.WriteLine($"Your total plastic bags = {totalPlastic.numberOfBags}");
                                Console.WriteLine($"Your total plastic bags = {totalPaper.numberOfBags}");
                                Console.WriteLine($"Your total natural bags = {totalNatural.numberOfBags}");
                            }
                            else
                            {
                                Console.WriteLine("The largest number of bags was natural");
                                Console.WriteLine($"Your total natural hours = {totalNatural.numberOfBags}");
                                Console.WriteLine($"Your total plastic bags = {totalPlastic.numberOfBags}");
                                Console.WriteLine($"Your total paper bags = {totalPaper.numberOfBags}");

                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                            selection = Menu();
                               
                    }
                }
            
            }
            public static int Menu()
            {
                int choice = 0;
                Console.WriteLine("Please make a selection from the menu");
                Console.WriteLine("1 - Add an entry");
                Console.WriteLine("2 - Print all ");
                Console.WriteLine("3 - Change price or bag type ");
                Console.WriteLine("4 - Adjust number of bags");
                Console.WriteLine("5 - Total categories and compare");
                Console.WriteLine("6 - Quit");

                while (!int.TryParse(Console.ReadLine(), out choice))
                
                    Console.WriteLine("Please select 1 - 6");
                return choice;
                
            }
        
            public static int pickEntry(int index)
            {
                Console.WriteLine("What entry would you like to change?)");
                Console.WriteLine($"1 through {index}");
                int entry;
                while (!int.TryParse(Console.ReadLine(), out entry))
                    Console.WriteLine($"Please select 1 - {index}");
                entry -= 1; // subtract 1 to begin index at 0
                return entry;
            }
        }

    }

