namespace Logic
{
    public static class MainLogic
    {
        public static List<Item> items = new();

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

    }

}
