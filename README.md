# Priority-Random-Selection

## Objective
- The purpose of the project is to create a console application that will randomly select an item from a list of 15 objects. Each object will have a field called "Priority", which will be an integer value. Specifically, five of the objects will have a priority of 1, five will have a priority of 2, and five will have a priority of 3.
- The application will run 7 times, and for each run, the program will randomly select one of the 15 objects based on their priority. The probability of selecting an object with priority 1 will be 60%, priority 2 will be 30%, and priority 3 will be 10%.
- After each run, the program will print the selected object along with its priority, and remove it from the list. The goal of the project is to demonstrate the ability to select objects from a list based on specific criteria, and use probability to determine the likelihood of selecting certain objects.


## Overview
This project implements a probability-based item selection system in C#. The system uses predefined priority and probability values to randomly select items, ensuring fairness while maintaining a weighted selection process.

## Features
- Configurable priority-based item selection
- Probability normalization for fair distribution
- Exception handling with informative error messages
- Unit tests using `Xunit` to ensure code reliability

## Technologies Used
- C#
- .NET Core 9
- Xunit (for unit testing)

## How It Works
1. **Validation:**
   - `GlobalVariables.ValidateGlobalVariables()` ensures the probability list is valid before execution.

2. **Initialization:**
   - `ItemsHandler.PopulateInitialItems()` creates items based on priority and probability.

3. **Selection Process:**
   - A priority is determined using `Probability.DeterminePriority()` based on predefined chances.
   - An item with the selected priority is retrieved and removed from the list.

4. **Error Handling:**
   - Invalid configurations trigger exceptions with detailed messages.

## Configuration
Modify values in `GlobalVariables.cs`:
```csharp
public static int TimesToRun = 7;
public static List<(int Priority, double Chance, int AmountOfItems)> ProbabilityList = new List<(int, double, int)>
{
    (1, 60, 5),
    (2, 30, 5),
    (3, 10, 5),
};
```
Ensure the `Chance` values sum to 100%.
