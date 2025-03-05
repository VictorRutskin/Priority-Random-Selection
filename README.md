# Priority-Random-Selection

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
