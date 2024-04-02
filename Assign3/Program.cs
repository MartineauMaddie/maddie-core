
int physicalSize = 31;
int logicalSize = 0;
double[] values = new double[physicalSize];
string[] dates = new string[physicalSize];
string fileName = "";
double minValue = 0.0;
double maxValue = 100.0;
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

string Prompt(string prompt)
{
	string myString = "";
	while (true)
	{
		try
		{
			Console.Write(prompt);
			myString = Console.ReadLine().Trim();
			if (string.IsNullOrWhiteSpace(myString))
				throw new Exception($"Empty Input: Please enter something.");
			break;
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
	DateTime date = DateTime.Today;
	while (true)
	{
		try
		{
			Console.Write(prompt);
			date = DateTime.Parse(Console.ReadLine());
			break;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	return date.ToString("MM-dd-yyyy");
}

// double PromptInt(string prompt)
// {
// 	int num = 0;
// 	while (true)
// 	{
// 		try
// 		{
// 			Console.Write(prompt);
// 			num = int.Parse(Console.ReadLine());
// 			break;
// 		}
// 		catch (Exception ex)
// 		{
// 			Console.WriteLine(ex.Message);
// 		}
// 	}
// 	return num;
// }

double PromptDoubleBetweenMinMax(string prompt, double min, double max)
{
	double num = 0;
	while (true)
	{
		try
		{
			Console.WriteLine($"{prompt} between {min} and {max}: ");
			num = double.Parse(Console.ReadLine());
			if (num < min || num > max)
				throw new Exception($"Invalid. Must be between {min} and {max}.");
			break;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	return num;
}

void DisplayMemoryValues(string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine($"\nThere are {logicalSize} Loaded Entries.\n");
	Console.WriteLine("{0,-15} {1,10:}\n", "Date", "Value");
	for (int i = 0; i < logicalSize; i++)
	{
		Console.WriteLine("{0,-15} {1,10:}", dates[i], values[i]);
	}
}

int LoadFileValuesToMemory(string[] dates, double[] values)
{
	string fileName = Prompt("Enter file name with extension .csv or .txt: ");
	int logicalSize = 0;
	string filePath = $"./data/{fileName}";
	if (!File.Exists(filePath))
		throw new Exception($"The file {fileName} does not exist.");
	string[] csvFileInput = File.ReadAllLines(filePath);
	for (int i = 0; i < csvFileInput.Length; i++)
	{
		string[] items = csvFileInput[i].Split(',');
		if (i != 0)
		{
			dates[logicalSize] = items[0];
			values[logicalSize] = double.Parse(items[1]);
			logicalSize++;
		}
	}
	Console.WriteLine($"Load complete. {fileName} has {logicalSize} data entries.");
	return logicalSize;
}

void SaveMemoryValuesToFile(string filename, string[] dates, double[] values, int logicalSize)
{
	string fileName = Prompt("Enter file name with extension .csv or .txt: ");
	string filePath = $"./data/{fileName}";
	if (logicalSize == 0)
		throw new Exception("No entries loaded. Please load a file into memory or add an entry.");
	if (logicalSize > 1)
		Array.Sort(dates, values, 0, logicalSize);
	string[] csvLines = new string[logicalSize + 1];
	csvLines[0] = "dates,values";
	for (int i = 1; i <= logicalSize; i++)
	{
		csvLines[i] = dates[i - 1] + "," + values[i - 1].ToString();
	}
	File.WriteAllLines(filePath, csvLines);
	Console.WriteLine($"Save complete. {fileName} has {logicalSize} data entries.");
}

int AddMemoryValues(string[] dates, double[] values, int logicalSize)
{
	double value = 0.0;
	string dateString = "";
	dateString = PromptDate("Enter date format MM-dd-yyyy: ");
	bool dupeFound = false;
	for (int i = 0; i < logicalSize; i++)
	{
		if (dates[i].Equals(dateString))
			dupeFound = true;
	}
	if (dupeFound == true)
		throw new Exception($"{dateString} is already in memory. Edit entry instead.");
	value = PromptDoubleBetweenMinMax($"Enter a double value ", 0.0, 100.0);
	dates[logicalSize] = dateString;
	values[logicalSize] = value;
	logicalSize++;
	return logicalSize;
}

void EditMemoryValues(string[] dates, double[] values, int logicalSize)
{
	double value = 0.0;
	string dateString = "";
	if (logicalSize == 0)
		throw new Exception("No entries loaded. Please load a file into memory or add and entry.");
	dateString = PromptDate("Enter date format MM-dd-yyyy: ");
	bool edit = false;
	int editIndex = 0;
	for (int i = 0; i < logicalSize; i++)
		if (dates[i].Equals(dateString))
		{
			edit = true;
			editIndex = i;
		}
	if (edit == false)
		throw new Exception($"{dateString} isn't in memory. Add entry instead.");
	value = PromptDoubleBetweenMinMax($"Enter a double value ", minValue, maxValue);
	values[editIndex] = value;
}

double FindHighestValueInMemory(double[] values, int logicalSize)
{
	double max = values[0];
	for (int i = 0; i < logicalSize; i++)
	{
		if (values[i] > max)
			max = values[i];
	}
	double maxIndex = 0;
	for (int i = 0; i < logicalSize; i++)
	{
		if (values[i].Equals(max))
			maxIndex = i;
	}
	Console.WriteLine($"The index of the highest value is {maxIndex}.");
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
	double minIndex = 0;
	for (int i = 0; i < logicalSize; i++)
	{
		if (values[i].Equals(min))
			minIndex = i;
	}
	Console.WriteLine($"The index of the lowest value is {minIndex}.");
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
	double rawMax = FindHighestValueInMemory(values, logicalSize);
	double salesVal = Math.Ceiling(rawMax / 5.0) * 5.0;
	double yIncrement = 5;
	double yAxis = salesVal / yIncrement;
	Console.Write($"\n{"Sales",6}\n");
	for (int i = 0; i <= yAxis; i++)
	{
		Console.Write($"{salesVal,3:c0}|");
		for (int col = 1; col <= physicalSize; col++)
		{
			for (int j = 0; j < logicalSize; j++)
			{
				string dayCheck = dates[j].Substring(3, 2);
				if (dayCheck.Substring(0, 1) == "0")
					dayCheck = dayCheck.Substring(1, 1);
				if (col.ToString() == dayCheck)
				{
					if (values[j] >= (salesVal - 2.5) && values[j] < (salesVal + 2.5))
						Console.Write($"{values[j],3}");
					else
					{
						Console.Write($"{" ",3}");
					}
				}
				if (j == logicalSize - 1)
				{
					if (salesVal == 0)
						Console.Write($"{"0",3}");
					else
						Console.Write($"{" ",3}");
				}
			}
		}
		Console.WriteLine($"");
		salesVal = salesVal - yIncrement;
	}
	//////////////////////////////////// God bless composite formatting
	Console.Write($"{"_____",4}");
	for (int i = 1; i <= physicalSize; i++)
		Console.Write($"{"____",4}");
	Console.Write($"\n{"Date",4}|");
	for (int i = 1; i <= physicalSize; i++)
		Console.Write($"{i,3}|");
	Console.WriteLine($"");
	//////////////////////////////////// Hurray The X axis is done
}
