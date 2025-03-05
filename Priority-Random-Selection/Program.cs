using Logic;
using Logic.Handlers;
using Logic.Models;
//////////////////////////////////////////////////////////////////////////////////////

GlobalVariables globalVariables = new GlobalVariables();
ProbabilityHandler probabilityHandler = new ProbabilityHandler();
ItemsHandler itemsHandler = new ItemsHandler(probabilityHandler);

try
{
    // Validate configurations
    globalVariables.ValidateGlobalVariables();

    // Populate items
    itemsHandler.PopulateInitialItems(globalVariables.ProbabilityList);

    // Run selection process
    for (int i = 0; i < globalVariables.TimesToRun; i++)
    {
        Console.WriteLine($"Run Number: {i + 1}");

        Item? selectedItem = itemsHandler.SelectItem(globalVariables.AvailablePriorities, globalVariables.ProbabilityList);

        if (selectedItem != null)
        {
            Console.WriteLine($"Selected: {selectedItem.GetName()} | Priority {selectedItem.GetPriority()}");
        }
        else
        {
            Console.WriteLine("No items are left in the list.");
            break;
        }

        Console.WriteLine(); // space
    }

    Console.WriteLine("THE END.");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Error: {ex.Message}");
    Console.ResetColor();
}
finally
{
    Console.WriteLine("Press Enter to exit...");
    Console.ReadLine();
}
    
