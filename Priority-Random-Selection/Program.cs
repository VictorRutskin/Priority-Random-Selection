using Logic;
//////////////////////////////////////////////////////////////////////////////////////

try
{
    GlobalVariables.ValidateGlobalVariables();
    MainLogic.PopulateInitialItems();
    for (int i = 0; i < GlobalVariables.TimesToRun; i++)
    {
        Console.WriteLine($"Run Number: {i + 1}");
        Item selectedItem = Probability.SelectItem();
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
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.ReadLine();
}