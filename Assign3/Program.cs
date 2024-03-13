﻿
int physicalSize = 31;
int logicalSize = 0;
double[] values = new double[physicalSize];
string[] dates = new string[physicalSize];
string fileName = "";

bool goAgain = true;
while (goAgain)
{
	try
	{
		DisplayMainMenu();
		string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
		if (mainMenuChoice == "L")
			logicalSize = LoadFileValuesToMemory(dates, values);
		if (mainMenuChoice == "S")
			SaveMemoryValuesToFile(fileName, dates, values, logicalSize);
		if (mainMenuChoice == "D")
			DisplayMemoryValues(dates, values, logicalSize);
		if (mainMenuChoice == "A")
			logicalSize = AddMemoryValues(dates, values, logicalSize);
		if (mainMenuChoice == "E")
			EditMemoryValues(dates, values, logicalSize);
		if (mainMenuChoice == "Q")
		{
			goAgain = false;
			throw new Exception("Bye, hope to see you again.");
		}
		if (mainMenuChoice == "R")
		{
			while (true)
			{
				if (logicalSize == 0)
					throw new Exception("No entries loaded. Please load a file into memory");
				DisplayAnalysisMenu();
				string analysisMenuChoice = Prompt("\nEnter an Analysis Menu Choice: ").ToUpper();
				if (analysisMenuChoice == "A")
				{
					double avg = FindAverageOfValuesInMemory(values, logicalSize);
					Console.WriteLine($"The average of values in memory is {avg}");
				}
				if (analysisMenuChoice == "H")
				{
					double max = FindHighestValueInMemory(values, logicalSize);
					Console.WriteLine($"The highest value in memory is {max}");
				}
				if (analysisMenuChoice == "L")
				{
					double min = FindLowestValueInMemory(values, logicalSize);
					Console.WriteLine($"The lowest value in memory is {min}");
				}
				if (analysisMenuChoice == "G")
					GraphValuesInMemory(dates, values, logicalSize);
				if (analysisMenuChoice == "R")
					throw new Exception("Returning to Main Menu");
			}
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine($"{ex.Message}");
	}
}

void DisplayMainMenu()
{
	Console.WriteLine("\nMain Menu");
	Console.WriteLine("L) Load Values from File to Memory");
	Console.WriteLine("S) Save Values from Memory to File");
	Console.WriteLine("D) Display Values in Memory");
	Console.WriteLine("A) Add Value in Memory");
	Console.WriteLine("E) Edit Value in Memory");
	Console.WriteLine("R) Analysis Menu");
	Console.WriteLine("Q) Quit");
}

void DisplayAnalysisMenu()
{
	Console.WriteLine("\nAnalysis Menu");
	Console.WriteLine("A) Find Average of Values in Memory");
	Console.WriteLine("H) Find Highest Value in Memory");
	Console.WriteLine("L) Find Lowest Value in Memory");
	Console.WriteLine("G) Graph Values in Memory");
	Console.WriteLine("R) Return to Main Menu");
}

// string Prompt(string prompt)
// {
// 	string response = "";
// 	Console.Write(prompt);
// 	response = Console.ReadLine();
// 	return response;
// }

string Prompt(string prompt)
{
	bool inValidInput = true;
	string myString = "";
	while (inValidInput)
	{
		try
		{
			Console.Write(prompt);
			myString = Console.ReadLine().Trim();
			if (string.IsNullOrWhiteSpace(myString))
				throw new Exception($"Empty Input: Please enter something.");
			inValidInput = false;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	return myString;
}

string PromptDate(string prompt)
{
	bool inValidInput = true;
	DateTime date = DateTime.Today;
	while (inValidInput)
	{
		try
		{
			Console.Write(prompt);
			date = DateTime.Parse(Console.ReadLine());
			inValidInput = false;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	return date.ToString("MM-dd-yyyy");
}

int LoadFileValuesToMemory(string[] dates, double[] values)
{
	string fileName = Prompt("Enter file name including .csv or .txt: ");
	int logicalSize = 0;
	string filePath = $"./data/{fileName}";
	if (!File.Exists(filePath))
		throw new Exception($"The file {fileName} does not exist.");
	string[] csvFileInput = File.ReadAllLines(filePath);
	for (int i = 0; i < csvFileInput.Length; i++)
	{
		Console.WriteLine($"lineIndex: {i}; line: {csvFileInput[i]}");
		string[] items = csvFileInput[i].Split(',');
		for (int j = 0; j < items.Length; j++)
		{
			Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
		}
		if (i != 0)
		{
			dates[logicalSize] = items[0];
			values[logicalSize] = double.Parse(items[1]);
			logicalSize++;
		}
	}
	Console.WriteLine($"Load complete. {fileName} has {logicalSize} data entries");
	return logicalSize;
}

void DisplayMemoryValues(string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine($"\nCurrent Loaded Entries: {logicalSize}\n");
	Console.WriteLine("{0,-15} {1,10:}\n", "Date", "Value");
	for (int i = 0; i < logicalSize; i++)
	{
		Console.WriteLine("{0,-15} {1,10:}", dates[i], values[i]);
	}
}

void SaveMemoryValuesToFile(string filename, string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");

}

// Demo-1-Writing to a file with arrays
// void Demo1()
// {
//   try
//   {
//     const string csvFileName = "Data.dat";
//     int arraySize = 10;
//     string[] csvLines = new string[arraySize];
//     csvLines[0] = "first,line,of,array,csv";
//     csvLines[1] = "second,line,of,array,csv";
//     csvLines[9] = "hi";
//     File.WriteAllLines(csvFileName, csvLines);
//     Console.WriteLine($"Data successfully written to file at: {Path.GetFullPath(csvFileName)}");
//   }
//   catch (Exception ex)
//   {
//     Console.WriteLine($"Exception in demo1: {ex.Message}");
//   }
// }

int AddMemoryValues(string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	return 0;
	//TODO: Replace this code with yours to implement this function.
}

// int AddMemoryValues(string[] dates, double[] values, int logicalSize)
// {
// 	double value = 0.0;
// 	string dateString = "";
// 	dateString = PromptDate("Enter date format mm-dd-yyyy (eg 11-23-2023): ");
// 	bool found = false;
// 	for (int i = 0; i < logicalSize; i++)
// 		if (dates[i].Equals(dateString))
// 			found = true;
// 	if (found == true)
// 		throw new Exception($"{dateString} is already in memory. Edit entry instead.");
// 	value = PromptDoubleBetweenMinMax($"Enter a double value ", 0.0, 1000.0);
// 	dates[logicalSize] = dateString;
// 	values[logicalSize] = value;
// 	logicalSize++;
// 	return logicalSize;
// }

void EditMemoryValues(string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	//TODO: Replace this code with yours to implement this function.
}

double FindHighestValueInMemory(double[] values, int logicalSize)
{
	double max = values[0];
	for (int i = 0; i < logicalSize; i++)
	{
		if (values[i] > max)
			max = values[i];
	}
	return max;
}

double FindLowestValueInMemory(double[] values, int logicalSize)
{
	double min = values[0];
	for (int i = 0; i < logicalSize; i++)
	{
		if (values[i] < min)
			min = values[i];
	}
	return min;
}

double FindAverageOfValuesInMemory(double[] values, int logicalSize)
{
	double sum = 0;
	for (int i = 0; i < logicalSize; i++)
		sum = sum + values[i];
	double avg = sum / logicalSize;
	return avg;
}

void GraphValuesInMemory(string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	//TODO: Replace this code with yours to implement this function.
}

double PromptDoubleBetweenMinMax(String prompt, double min, double max)
{
	bool invalidInput = true;
	double num = 0;
	while (invalidInput)
	{
		try
		{
			Console.WriteLine($"{prompt} between {min} and {max}: ");
			num = double.Parse(Console.ReadLine());
			if (num < min || num > max)
				throw new Exception($"Invalid. Must be between {min} and {max}.");
			invalidInput = false;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	return num;
}