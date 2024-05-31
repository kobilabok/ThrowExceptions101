﻿
/* Create and throw exceptions challenge!!! 

Update the sample application using the following requirements:

1. All methods must be converted from static string methods to static void methods.
2. The Process1 method must throw exceptions for each type of issue encountered.
3. The Workflow1 method must catch and handle the FormatException exceptions.
4. The top-level statements must catch and handle the DivideByZeroException exceptions.
5. The Message property of the exception must be used to notify the user of the issue.

NOTE: Solution is below!
NOTE: This repo was commited to GitHub



string[][] userEnteredValues = new string[][]
{
    new string[] { "1", "2", "3"},
    new string[] { "1", "two", "3"},
    new string[] { "0", "1", "2"}
};

string overallStatusMessage = "";

overallStatusMessage = Workflow1(userEnteredValues);

if (overallStatusMessage == "operating procedure complete")
{
    Console.WriteLine("'Workflow1' completed successfully.");
}
else
{
    Console.WriteLine("An error occurred during 'Workflow1'.");
    Console.WriteLine(overallStatusMessage);
}

static string Workflow1(string[][] userEnteredValues)
{
    string operationStatusMessage = "good";
    string processStatusMessage = "";

    foreach (string[] userEntries in userEnteredValues)
    {
        processStatusMessage = Process1(userEntries);

        if (processStatusMessage == "process complete")
        {
            Console.WriteLine("'Process1' completed successfully.");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("'Process1' encountered an issue, process aborted.");
            Console.WriteLine(processStatusMessage);
            Console.WriteLine();
            operationStatusMessage = processStatusMessage;
        }
    }

    if (operationStatusMessage == "good")
    {
        operationStatusMessage = "operating procedure complete";
    }

    return operationStatusMessage;
}

static string Process1(String[] userEntries)
{
    string processStatus = "clean";
    string returnMessage = "";
    int valueEntered;

    foreach (string userValue in userEntries)
    {
        bool integerFormat = int.TryParse(userValue, out valueEntered);

        if (integerFormat == true)
        {
            if (valueEntered != 0)
            {
                checked
                {
                    int calculatedValue = 4 / valueEntered;
                }
            }
            else
            {
                returnMessage = "Invalid data. User input values must be non-zero values.";
                processStatus = "error";
            }
        }
        else
        {
            returnMessage = "Invalid data. User input values must be valid integers.";
            processStatus = "error";
        }
    }

    if (processStatus == "clean")
    {
        returnMessage = "process complete";
    }

    return returnMessage;
}


*/

string[][] userEnteredValues = new string[][]
{
    new string[] { "1", "2", "3"},
    new string[] { "1", "two", "3"},
    new string[] { "0", "1", "2"}
};

try{
    Workflow1(userEnteredValues);
    Console.WriteLine("'Workflow1' completed successfully.");
}
catch(DivideByZeroException ex){
    Console.WriteLine("An error occurred during 'Workflow1'.");
    Console.WriteLine(ex.Message);
}

static void Workflow1(string[][] userEnteredValues)
{
    foreach (string[] userEntries in userEnteredValues)
    {
        try{
            Process1(userEntries);
            Console.WriteLine("'Process1' completed successfully.");
            Console.WriteLine();
        }
        catch (FormatException ex){
            Console.WriteLine("'Process1' encountered an issue, process aborted.");
            Console.WriteLine(ex.Message);
            Console.WriteLine();
        }
    }
}

static void Process1(String[] userEntries)
{
    int valueEntered;

    foreach (string userValue in userEntries)
    {
        bool integerFormat = int.TryParse(userValue, out valueEntered);

        if (integerFormat == true)
        {
            if (valueEntered != 0)
            {
                checked
                {
                    int calculatedValue = 4 / valueEntered;
                }
            }
            else
            {
                throw new DivideByZeroException("Invalid data. User input values must be non-zero values.");
            }
        }
        else
        {
            throw new FormatException("Invalid data. User input values must be valid integers.");
        }
    }
}