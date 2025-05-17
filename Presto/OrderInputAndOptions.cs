namespace Presto
{
    public class OrderInputAndOptions
    {
        // Stores all completed entrees in the order
        public List<List<Menu>> AllEntrees { get; private set; }

        // Stores the current entree being customized
        public List<Menu> CurrentEntree { get; private set; }

        // Used to calculate and show the total price of the order
        private CustomerReceipt _receipt;

        public OrderInputAndOptions()
        {
            AllEntrees = new List<List<Menu>>();
            CurrentEntree = new List<Menu>();
        }

        public void StartNewEntree()
        {
            CurrentEntree = new List<Menu>();
        }

        public void FinalizeEntree()
        {
            if (CurrentEntree.Any())
            {
                AllEntrees.Add(new List<Menu>(CurrentEntree));
                CurrentEntree.Clear();
            }
        }

        public void SetCustomerReceipt(CustomerReceipt receipt)
        {
            _receipt = receipt;
        }

        public int GetNumberInput(string prompt, int min, int max)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Please type a number.");
                }
                else if (number < min || number > max)
                {
                    Console.WriteLine("Number is out of range. Try again.");
                }
                else
                {
                    return number;
                }
            }
        }

        public void ShowMenuOptions(string title, Menu[] options)
        {
            Console.WriteLine($"\n{title}");
            int index = 1;
            foreach (Menu option in options)
            {
                string priceText = option.Price == 0.00m ? "" : $"....{option.Price.ToString("c")}";
                Console.WriteLine($"{index}. {option.Name.ToUpper()}{priceText}");
                index++;
            }
        }

        public bool GetYesOrNo(string question)
        {
            do
            {
                Console.WriteLine($"{question}(Y/N)");
                string input = Console.ReadLine().ToUpper();

                if (input == "Y") return true;
                if (input == "N") return false;

                Console.WriteLine("Please enter Y or N.");
            } while (true);
        }

        public void ChooseEntreeType()
        {
            Menu[] options =
            {
                new Menu { Name = "SHAWARMA WRAP", Price = 0.00m },
                new Menu { Name = "SHAWARMA PLATE", Price = 0.00m },
            };

            ShowMenuOptions("SHAWARMA TYPE:", options);
            int choice = GetNumberInput("Pick your shawarma type: ", 1, 2) - 1;
            CurrentEntree.Insert(0, options[choice]);
        }

        public void ChooseBread()
        {
            Menu[] options =
            {
                new Menu { Name = "PITA BREAD", Price = 0.00m },
                new Menu { Name = "FLATBREAD", Price = 0.00m },
                new Menu { Name = "GARLIC WRAP", Price = 0.00m }
            };

            ShowMenuOptions("BREAD CHOICE:", options);
            int choice = GetNumberInput("Pick your bread: ", 1, 3) - 1;

            CurrentEntree.Add(options[choice]);
            Console.WriteLine($"You picked: {options[choice].Name}.");
        }

        public void ChooseProtein()
        {
            Menu[] options =
            {
                new Menu { Name = "BEEF", Price = 10.00m },
                new Menu { Name = "CHICKEN", Price = 9.00m },
                new Menu { Name = "LAMB", Price = 11.50m }
            };

            ShowMenuOptions("MEAT CHOICE:", options);
            int choice = GetNumberInput("Pick your meat: ", 1, 3) - 1;

            CurrentEntree.Add(options[choice]);
            decimal total = _receipt.CalculateSubTotal();
            Console.WriteLine($"You picked: {options[choice].Name}, total: ${total}");

            decimal extraMeatCost = Math.Round(options[choice].Price * 0.40m, 2);

            if (GetYesOrNo($"Add extra meat for ${extraMeatCost}?"))
            {
                Menu extraMeat = new Menu { Name = "EXTRA MEAT", Price = extraMeatCost };
                CurrentEntree.Add(extraMeat);
                total = _receipt.CalculateSubTotal();
                Console.WriteLine($"Extra meat added. Total now: ${total}");
            }
        }

        public void ChooseRice()
        {
            Menu[] options =
            {
                new Menu { Name = "WHITE RICE", Price = 0.00m },
                new Menu { Name = "BROWN RICE", Price = 0.00m },
                new Menu { Name = "NO RICE", Price = 0.00m }
            };

            ShowMenuOptions("RICE CHOICE:", options);
            int choice = GetNumberInput("Pick your rice: ", 1, 3) - 1;

            CurrentEntree.Add(options[choice]);
            Console.WriteLine($"You picked: {options[choice].Name}.");
        }

        public void ChooseSide()
        {
            Menu[] options =
            {
                new Menu { Name = "PICKLES", Price = 0.00m },
                new Menu { Name = "TOMATO SALAD", Price = 0.00m },
                new Menu { Name = "NO SIDES", Price = 0.00m }
            };

            ShowMenuOptions("SIDE CHOICE:", options);
            int choice = GetNumberInput("Pick your side: ", 1, 3) - 1;

            CurrentEntree.Add(options[choice]);
            Console.WriteLine($"You picked: {options[choice].Name}.");
        }

        public void ChooseAddOns()
        {
            Menu[] options =
            {
                new Menu { Name = "GARLIC SAUCE", Price = 0.00m },
                new Menu { Name = "HOT SAUCE", Price = 0.00m },
                new Menu { Name = "HUMMUS", Price = 1.00m },
                new Menu { Name = "EXTRA PICKLES", Price = 0.50m },
                new Menu { Name = "FRIES", Price = 1.75m }
            };

            while (true)
            {
                ShowMenuOptions("ADD-ONS:", options);
                int choice = GetNumberInput("Pick an add-on: ", 1, 5) - 1;

                if (CurrentEntree.Contains(options[choice]))
                {
                    Console.WriteLine($"You already picked {options[choice].Name}. Try something else.");
                }
                else
                {
                    CurrentEntree.Add(options[choice]);
                    decimal total = _receipt.CalculateSubTotal();
                    Console.WriteLine($"Added: {options[choice].Name}. New total: ${total}");
                }

                if (!GetYesOrNo("Add another topping?"))
                {
                    break;
                }
            }
        }

        public void ClearEntreeType()
        {
            CurrentEntree.RemoveAll(item => item.Name == "SHAWARMA WRAP" || item.Name == "SHAWARMA PLATE");
        }

        public void ClearBread()
        {
            CurrentEntree.RemoveAll(item => item.Name.Contains("BREAD") || item.Name.Contains("WRAP"));
        }

        public void ClearProtein()
        {
            CurrentEntree.RemoveAll(item => new[] { "BEEF", "CHICKEN", "LAMB", "EXTRA MEAT" }.Contains(item.Name));
        }

        public void ClearRice()
        {
            CurrentEntree.RemoveAll(item => new[] { "WHITE RICE", "BROWN RICE", "NO RICE" }.Contains(item.Name));
        }

        public void ClearSide()
        {
            CurrentEntree.RemoveAll(item => new[] { "PICKLES", "TOMATO SALAD", "NO SIDES" }.Contains(item.Name));
        }

        public void ClearAddOns()
        {
            CurrentEntree.RemoveAll(item => new[] { "GARLIC SAUCE", "HOT SAUCE", "HUMMUS", "EXTRA PICKLES", "FRIES" }.Contains(item.Name));
        }
    }
}
