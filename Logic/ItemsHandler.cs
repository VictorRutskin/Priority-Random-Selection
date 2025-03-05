using Logic.Models;
using System;

namespace Logic
{
    public static class ItemsHandler
    {
        public static List<Item> items = new();

        // Add initial items based on the probability list, the values are handles from the probability list so values can be modified easily and keep same original logic
        public static void PopulateInitialItems()
        {
            foreach (var (priority, chancePrecentage, amount) in GlobalVariables.ProbabilityList)
            {
                for (int i = 0; i < amount; i++)
                {
                    int itemNumber = items.Count + 1;
                    items.Add(new Item($"Item_{itemNumber}", priority));
                }
            }
        }

        private static Random _random = new Random();

        public static Item SelectItem()
        {
            if (!items.Any()) return null!;

            // If any priority is still available, continue - else stop
            while (GlobalVariables.AvailablePriorities.Any())
            {
                int selectedPriority = Probability.DeterminePriority(GlobalVariables.AvailablePriorities, _random);
                List<Item> filteredItems = items.Where(item => item.GetPriority() == selectedPriority).ToList();

                if (filteredItems.Count > 0)
                {
                    Item selectedItem = filteredItems[_random.Next(filteredItems.Count)];
                    items.Remove(selectedItem);
                    return selectedItem;
                }

                // Remove priority from available list if no items found
                GlobalVariables.AvailablePriorities.Remove(selectedPriority);
            }

            return null!;
        }


    }

}
