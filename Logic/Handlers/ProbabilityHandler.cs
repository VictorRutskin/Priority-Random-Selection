using Logic.Models;

namespace Logic.Handlers
{
    public class ProbabilityHandler
    {
        private readonly Random _random = new Random();

        // Get Priority based on probability
        public int DeterminePriority(List<int> availablePriorities, List<(int Priority, double Chance, int AmountOfItems)> probabilityList)
        {
            var filteredProbabilities = probabilityList.Where(p => availablePriorities.Contains(p.Priority)).ToList();

            // Calculate the total sum of the original probability values
            double totalOriginalChance = filteredProbabilities.Sum(p => p.Chance);
            // Normalize probabilities so they sum to 100%
            var normalizedProbabilities = filteredProbabilities.Select(p => (p.Priority, Chance: p.Chance / totalOriginalChance * 100, p.AmountOfItems)).ToList();

            // Random value between 0 and 100
            double randomValue = _random.NextDouble() * 100;
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
