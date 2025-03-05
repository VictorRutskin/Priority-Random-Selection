using Logic.Models;

namespace Logic
{
    public static class Probability
    {   
        // Get Priority based on probability
        public static int DeterminePriority(List<int> availablePriorities, Random random)
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
