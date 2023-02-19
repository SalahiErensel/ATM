using System;

//Defining card holder's parameters
public class card_holder
{
    string card_number;
    int password;
    string first_name;
    string last_name;
    double balance;

    //Constructor
    public card_holder(string card_number, int password, string first_name, string last_name, double balance)
    {
        this.card_number = card_number;
        this.password = password;
        this.first_name = first_name;
        this.last_name = last_name;
        this.balance = balance;
    }

    //Getting card_number
    public string getNumber()
    {
        return card_number;
    }

    //Getting password
    public int getPassword()
    {
        return password;
    }

    //Getting first_name
    public string getFirstName()
    {
        return first_name;
    }

    //Getting last_name
    public string getLastName()
    {
        return last_name;
    }

    //getting balance
    public double getBalance()
    {
        return balance;
    }

    //seting card_number
    public void setNumber(String newCardNumber)
    {
        card_number = newCardNumber;
    }

    //seting password
    public void setPassword(int newPassword)
    {
        password = newPassword;
    }
    //seting first_name
    public void setFirstName(String newFirstName)
    {
        first_name = newFirstName;
    }

    //seting last_name
    public void setLastName(String newLastName)
    {
        last_name = newLastName;
    }

    //seting balance
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    //main method to run application
    public static void Main(String[] args)
    {

        //menu options for users
        void printOptions()
        {
            Console.WriteLine("\nPlease choose one of the options:");
            Console.WriteLine("\n1. Deposit");
            Console.WriteLine("\n2. Withdraw");
            Console.WriteLine("\n3. Show Balance");
            Console.WriteLine("\n4. Exit");
            Console.Write("\nOption -> ");
        }

        //deposit option
        void deposit(card_holder currentUser)
        {
            Console.WriteLine("\nHow much do you want to deposit? ");
            Console.Write("\nAmount -> ");
            double deposit = Double.Parse(Console.ReadLine());

            //setting new balance for the user after deposit
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("\n" + deposit + "$ is deposited to your account. Your new balance is: " + currentUser.getBalance() + "$");
        }

        //withdraw option
        void withdraw(card_holder currentUser)
        {
            Console.WriteLine("\nHow much do you want to withdraw? ");
            Console.Write("\nAmount -> ");
            double withdrawal = Double.Parse(Console.ReadLine());

            //checking if user has enough amount of money to withdraw
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("\nInsufficient balance. The amount of money you have is: " + currentUser.getBalance() + "$");
            }
            else
            {
                //setting new balance for the user after withdraw
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("\nYou successfully withdrawed " + withdrawal + "$. Your current balance is :" + currentUser.getBalance() + "$");
            }
        }

        //show balance option
        void balance(card_holder currentUser)
        {
            Console.WriteLine("\nYour current balance: " + currentUser.getBalance() + "$");
        }

        //Random Number Generator for balances of users.

        //creating card holders in a list with their card_number, password, name, surname and balance 
        List<card_holder> cardHolders = new List<card_holder>();
        cardHolders.Add(new card_holder("111111111111", 1234, "Salahi", "Erensel", 1000.65));
        cardHolders.Add(new card_holder("222222222222", 1222, "Asaf", "Ertaç", 6000.50));
        cardHolders.Add(new card_holder("333333333333", 3332, "Ramadan K.", "Coşkun", 450.50));
        cardHolders.Add(new card_holder("444444444444", 4456, "Kenan", "Günergin", 100000.70));
        cardHolders.Add(new card_holder("555555555555", 3166, "Uğur Berkay", "Çalışkan", 55.40));
        cardHolders.Add(new card_holder("666666666666", 3332, "Ali G.", "Akyüz", 670.67));

        //getting card number from user
        Console.WriteLine("Welcome to Salahi Bank\n");
        Console.WriteLine("Today's date is: " + DateTime.Now);
        Console.WriteLine("\nPlease enter your card number: ");
        Console.Write("\nCard Number -> ");
        String cardNumber = "";
        card_holder currentUser;

        //checking if card number is cırrect or not
        while (true)
        {
            try
            {
                cardNumber = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.card_number == cardNumber);
                if (currentUser != null)
                {
                    break;
                }
                //throwing error message to user
                else
                {
                    Console.WriteLine("\nCard number is wrong. Please try again!");
                    Console.WriteLine("> ");
                }
            }
            //throwing error message to user
            catch
            {
                Console.WriteLine("\nCard number is wrong. Please try again!");
                Console.WriteLine("> ");
            }
        }

        //Getting card password from user
        Console.WriteLine("\nPlease enter your password: ");
        Console.Write("\nPassword -> ");
        int user_password = 0;

        //checking if the password is correct or not
        while (true)
        {
            try
            {
                user_password = int.Parse(Console.ReadLine());

                if (currentUser.getPassword() == user_password)
                {
                    break;
                }
                //throwing error message to user
                else
                {
                    Console.WriteLine("\nPassword is wrong. Please try again!");
                    Console.WriteLine("> ");
                }
            }
            //throwing error message to user
            catch
            {
                Console.WriteLine("\nPassword is wrong. Please try again!");
                Console.WriteLine("> ");
            }
        }

        //welcome message after login
        Console.WriteLine("\nWelcome to Salahi Bank Dear " + currentUser.first_name + " " + currentUser.last_name);
        Console.WriteLine("\nDate: " + DateTime.Now);
        int option = 0;

        //showing options to user
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {

            }

            //if user selects 1st option
            if (option == 1)
            {
                deposit(currentUser);
            }

            //if user selects 2nd option
            else if (option == 2)
            {
                withdraw(currentUser);
            }

            //if user selects 3rd option
            else if (option == 3)
            {
                balance(currentUser);
            }

            //if user selects 4th option
            else if (option == 4)
            {
                break;
            }

            else
            {
                option = 0;
                Console.WriteLine("\nPlease enter a valid option!");
            }
        }

        //finishing the application if the 4th option is selected
        while (option != 4);
        Console.WriteLine("\nThank you Dear " + currentUser.first_name + " " + currentUser.last_name + " Have a nice day!");
    }
}