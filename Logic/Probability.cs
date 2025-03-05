using System;
namespace Logic
{
    public static class Probability
    {
        private static Random random = new Random();

        public static Item SelectItem()
        {
            if (!MainLogic.items.Any()) return null!;

            // If any priority is still available, continue - else stop
            while (GlobalVariables.availablePriorities.Any())
            {
                int selectedPriority = DeterminePriority(GlobalVariables.availablePriorities);
                List<Item> filteredItems = MainLogic.items.Where(item => item.GetPriority() == selectedPriority).ToList();

                if (filteredItems.Count > 0)
                {
                    Item selectedItem = filteredItems[random.Next(filteredItems.Count)];
                    MainLogic.items.Remove(selectedItem);
                    return selectedItem;
                }

                // Remove priority from available list if no items found
                GlobalVariables.availablePriorities.Remove(selectedPriority);
            }

            return null!;
        }

        // Get Priority based on probability
        private static int DeterminePriority(List<int> availablePriorities)
        {
            var filteredProbabilities = GlobalVariables.ProbabilityList.Where(p => availablePriorities.Contains(p.Priority)).ToList();

            // Calculate the total sum of the original probability values
            double totalOriginalChance = filteredProbabilities.Sum(p => p.Chance);
            // Normalize probabilities so they sum to 100%
            var normalizedProbabilities = filteredProbabilities.Select(p => (p.Priority, Chance: (p.Chance / totalOriginalChance) * 100, p.AmountOfItems)).ToList();

            // Random value between 0 and 100
            double randomValue = random.NextDouble() * 100;  
            double totalChanceValue = 0.0;
            // Check the probabilities and return the selected priority
            foreach (var (priority, chance, amountOfItems) in normalizedProbabilities)
            {
                totalChanceValue += chance;
                if (randomValue <= totalChanceValue)
                    return priority;
            }

            // If no priority was selected, there is a logic error, this should never happen.
            throw new InvalidOperationException("Priority selection failed due to an unexpected probability calculation issue, Please Contact the company support ;)");
        }



    }
}
