namespace Logic
{
    public static class GlobalVariables
    {
        // How many times to run the selection
        public static int TimesToRun = 7;

        // List of probabilities
        public static List<(int Priority, double Chance, int AmountOfItems)> ProbabilityList = new List<(int, double, int)>
        {
            (1, 60, 5),
            (2, 30, 5),
            (3, 10, 5),
        };

        public static List<int> availablePriorities = ProbabilityList.Select(p => p.Priority).ToList();

        public static void ValidateGlobalVariables()
        {
            List<string> errors = new List<string>();

            ValidateTimesToRun(errors);
            ValidateTotalChance(errors);
            ValidateDuplicatePriorities(errors);
            ValidateProbabilityEntries(errors);

            // If any errors, throw exception with the number of errors
            if (errors.Any())
                throw new ArgumentException($"Validation failed:\n{string.Join("\n", errors)}");
        }

        // Validating TimesToRun
        private static void ValidateTimesToRun(List<string> errors)
        {
            if (TimesToRun is < 1 or > 10_000)
                errors.Add($"{errors.Count + 1}. TimesToRun must be between 1 and 10,000.");
        }

        // Validating the total chance values add up to 100, with tolerance for floating-point precision error
        private static void ValidateTotalChance(List<string> errors)
        {
            const double Tolerance = 0.0000001;
            double totalChance = ProbabilityList.Sum(p => p.Chance);
            if (Math.Abs(totalChance - 100) > Tolerance)
                errors.Add($"{errors.Count + 1}. Total Chance values all together must be 100.");
        }

        // Validating no duplicate priorities
        private static void ValidateDuplicatePriorities(List<string> errors)
        {
            var duplicatePriorities = ProbabilityList.GroupBy(p => p.Priority).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            if (duplicatePriorities.Any())
                errors.Add($"{errors.Count + 1}. Duplicate priority values found: {string.Join(", ", duplicatePriorities)}");
        }

        // Validating individual probability entries
        private static void ValidateProbabilityEntries(List<string> errors)
        {
            foreach (var (priority, chance, amount) in ProbabilityList)
            {
                if (priority is < 1 or > 10_000)
                    errors.Add($"{errors.Count + 1}. Priority {priority} must be between 1 and 10,000.");
                if (chance is <= 0 or > 100)
                    errors.Add($"{errors.Count + 1}. Chance {chance} must be between 0 (not including 0) and 100.");
                if (amount is < 1 or > 10_000)
                    errors.Add($"{errors.Count + 1}. Amount of items {amount} must be between 1 and 10,000.");
            }
        }
    }
}
