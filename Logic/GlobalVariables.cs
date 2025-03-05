namespace Logic
{
    public class GlobalVariables
    {
        // How many times to run the selection, default value is 7
        public int TimesToRun { get; set; } = 7;
        // List of probabilities
        public List<(int Priority, double Chance, int AmountOfItems)> ProbabilityList { get; set; }
        // List of available priorities for efficient priority selection
        public List<int> AvailablePriorities { get; private set; } = new();


        public GlobalVariables(List<(int Priority, double Chance, int AmountOfItems)>? probabilityList = null, int timesToRun = 7)
        {
            // If probabilityList is null, implement default values
            if (probabilityList == null)
            {
                probabilityList = new List<(int, double, int)>
                {
                    (1, 60, 5),
                    (2, 30, 5),
                    (3, 10, 5),
                };
                throw new ArgumentNullException(nameof(probabilityList));
            }
            ProbabilityList = probabilityList;
            TimesToRun = timesToRun;
            ResetAvailablePriorities();
        }

        public void ResetAvailablePriorities()
        {
            AvailablePriorities = ProbabilityList.Select(p => p.Priority).ToList();
        }

        public void ValidateGlobalVariables()
        {
            List<string> errors = new List<string>();

            ValidateTimesToRun(errors);
            ValidateTotalChance(errors);
            ValidateDuplicatePriorities(errors);
            ValidateProbabilityList(errors);

            // If any errors, throw exception with the number of errors
            if (errors.Any())
                throw new ArgumentException($"Validation failed:\n{string.Join("\n", errors)}");
        }

        // Validating TimesToRun
        private void ValidateTimesToRun(List<string> errors)
        {
            if (TimesToRun is < 1 or > 10_000)
                errors.Add("TimesToRun must be between 1 and 10,000.");
        }

        // Validating the total chance values add up to 100, with tolerance for floating-point precision error
        private void ValidateTotalChance(List<string> errors)
        {
            double totalChance = ProbabilityList.Sum(p => p.Chance);
            if (Math.Abs(totalChance - 100) > 0.0000001)
                errors.Add("Total Chance values must add up to 100.");
        }

        // Validating no duplicate priorities
        private void ValidateDuplicatePriorities(List<string> errors)
        {
            var duplicatePriorities = ProbabilityList.GroupBy(p => p.Priority).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            if (duplicatePriorities.Any())
                errors.Add($"Duplicate priority values found: {string.Join(", ", duplicatePriorities)}");
        }

        // Validating probability list
        private void ValidateProbabilityList(List<string> errors)
        {
            foreach (var (priority, chance, amount) in ProbabilityList)
            {
                if (priority is < 1 or > 10_000)
                    errors.Add($"Priority {priority} must be between 1 and 10,000.");
                if (chance is <= 0 or > 100)
                    errors.Add($"Chance {chance} must be between 0 and 100.");
                if (amount is < 1 or > 10_000)
                    errors.Add($"Amount of items {amount} must be between 1 and 10,000.");
            }
        }
    }

}
