using System;

public class CardHolder
{
    private string cardNum;
    private int pin;
    private string firstName;
    private string lastName;
    private double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string GetNum()
    {
        return cardNum;
    }

    public int GetPin()
    {
        return pin;
    }

    public string GetFirstName()
    {
        return firstName;
    }

    public string GetLastName()
    {
        return lastName;
    }

    public double GetBalance()
    {
        return balance;
    }

    public void SetNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void SetPin(int newPin)
    {
        pin = newPin;
    }

    public void SetFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void SetLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void SetBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit ");
        }
        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.SetBalance(currentUser.GetBalance() + deposit);
            Console.WriteLine("Thank you for you $$. Your new balance is: " + currentUser.GetBalance());
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw? ");
            double withdraw = Double.Parse(Console.ReadLine());
            //Check if the user has enough money
            if (currentUser.GetBalance() < withdraw)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.SetBalance(currentUser.GetBalance() - withdraw);
                Console.WriteLine("You're good to go! Thank you :)");
            }
        }

        void balance(CardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.GetBalance());
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("5455 6282 0164 2946", 1547, "Reges", "Oliveira", 200.33));
        cardHolders.Add(new CardHolder("6011 7239 3184 2687", 2500, "Tuyxa", "Bawa", 153.25));
        cardHolders.Add(new CardHolder("5025 3845 7216 9918", 3504, "Fules", "Pazus", 100.52));
        cardHolders.Add(new CardHolder("4485 9425 5837 6199", 3621, "Luohi", "Loil", 10.25));

        //Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        CardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.GetPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again."); }
        }
        Console.WriteLine("Welcome " + currentUser.GetFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you Have a nice day :)");
    }
}

