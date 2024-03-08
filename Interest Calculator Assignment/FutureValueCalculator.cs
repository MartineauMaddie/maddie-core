// <summary>
// This program is the compound interest calculator for CPSC1012 assignment 1
// Author: Madeline Martineau
// Date: January 15, 2024
// </summary>

/*
Formula
FV = I x (1 + R)T

Where:
FV = Future value or futureValue
I = Initial investment amount or initialInvest
R = Monthly interest rate or monthInterestRate
T = Number of months to leave invested or monthsToInvest
*/

Console.Write("Enter the intitial investment amount: ");
double initialInvest = double.Parse(Console.ReadLine());
Console.Write("Enter the annual interest rate as a percentage: ");
double yearInterestRate = double.Parse(Console.ReadLine());
double monthInterestRate = yearInterestRate / 100 / 12;
Console.Write("Enter the number of years to leave invested: ");
int yearsToInvest = int.Parse(Console.ReadLine());
int monthsToInvest = yearsToInvest * 12;
double futureValue = initialInvest * Math.Pow(1 + monthInterestRate, monthsToInvest);
Console.WriteLine($"The future value amount of {initialInvest:c} in {yearsToInvest} years is {futureValue:c}.");

