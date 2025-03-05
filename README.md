# Priority-Based Random Selection

## Overview
This project is a C# console application that selects items randomly based on predefined probabilities. The system ensures fair and weighted selection by normalizing probabilities and dynamically managing item availability.

## Features
- **Configurable priority-based selection**: Items are chosen based on probability distributions.
- **Probability normalization**: Ensures correct probability scaling.
- **Robust error handling**: Provides informative error messages for misconfigurations.
- **Unit tests with Xunit**: Ensures system reliability.

## Technologies Used
- C#
- .NET Core 9
- Xunit (for unit testing)

## How It Works
### Validation
Before execution, `GlobalVariables.ValidateGlobalVariables()` verifies:
- The total probability sums to 100%.
- There are no duplicate priority values.
- Each probability value falls within valid ranges.

### Initialization
- `ItemsHandler.PopulateInitialItems()` creates items according to their priority and probability.
- `ProbabilityHandler.DeterminePriority()` selects a priority based on weighted probabilities.

### Selection Process
1. The program runs a set number of times (`TimesToRun`).
2. On each iteration, a priority is determined probabilistically.
3. An item matching the selected priority is retrieved and removed from the list.
4. The process continues until all items are exhausted or `TimesToRun` is reached.

### Error Handling
If configurations are invalid, exceptions are thrown with detailed messages for debugging.

## Configuration
Modify values in `GlobalVariables.cs`:
```csharp
public int TimesToRun = 7;
public List<(int Priority, double Chance, int AmountOfItems)> ProbabilityList = new List<(int, double, int)>
{
    (1, 60, 5),
    (2, 30, 5),
    (3, 10, 5),
};
```
- Ensure `Chance` values sum to 100%.
- The number of items (`AmountOfItems`) can be adjusted per priority.

