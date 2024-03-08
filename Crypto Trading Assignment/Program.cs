// <summary>
// This program is the Crypto Trading Program for CPSC1012 assignment 2
// Author: Madeline Martineau
// Date: February 28, 2024
// </summary>

double commissionRate;
double ethCost;
double yearlyReward;
double monthlyReward;
char wantsToBuy;

Random rnd = new Random();
int spotPrice = rnd.Next(2600, 3000);
Console.WriteLine("\nThank you for choosing our Ethereum trading program.");
do
{
    Console.WriteLine($"\nThe current price of Ethereum is {spotPrice:c} per 1 ETH");
    double cryptoToPurchase = GetAmount($"Enter amount of ETH to purchase: ");
    double GetAmount(String msg)
    {
        bool inValidInput = true;
        int num = 1;
        do
        {
            try
            {
                Console.Write(msg);
                num = int.Parse(Console.ReadLine());

                if (num <= 0)
                    throw new Exception($"Invalid. Must be > 0.");
                inValidInput = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (inValidInput);
        return num;
    }

    if (cryptoToPurchase <= 0.999999)
        commissionRate = 1.9;
    else if (cryptoToPurchase > 0.999999 && cryptoToPurchase <= 4.999999)
        commissionRate = 1.75;
    else if (cryptoToPurchase > 4.999999 && cryptoToPurchase <= 9.999999)
        commissionRate = 1.5;
    else
        commissionRate = 1.25;
    ethCost = spotPrice * cryptoToPurchase;
    yearlyReward = ethCost * .031 * 1;
    monthlyReward = yearlyReward / 12;
    Console.Write($"The amount of Ethereum you wish to purchase is {cryptoToPurchase:n6} ETH. \nThe cost of this Ethereum will be {ethCost:c}. Would you like to stake your {cryptoToPurchase:n6} Ethereum? (Y/n) ");
    char stakeChoice = char.Parse(Console.ReadLine().ToUpper());
    double commissionCost = commissionRate / 100 * ethCost;
    double totalCost = commissionCost + ethCost;
    Console.WriteLine($"The commission rate for this amount of ETH purchased is {commissionRate}%. \nThe cost of the commission will be {commissionCost:c}. \nThe total cost of this purchase including commission is {totalCost:c}.");
    if (stakeChoice == 'Y')
        Console.WriteLine($"You have chosen to stake your Ethereum. \nYou should expect a monthly reward of {monthlyReward:c}");
    else
        Console.WriteLine("You have chosen not to stake your Ethereum.");
    Console.Write("Would you like to confirm your trade? (Y/n) ");
    char tradeConfirm = char.Parse(Console.ReadLine().ToUpper());
    if (tradeConfirm == 'Y')
        Console.WriteLine("Trade confirmed. Thank you for your purchase.");
    else
        Console.WriteLine("Trade cancelled.");
    Console.Write("Would you like to make another trade? (Y/n) ");
    wantsToBuy = char.Parse(Console.ReadLine().ToUpper());
} while (wantsToBuy == 'Y');
Console.WriteLine("Thank you for using our program. Goodbye");
