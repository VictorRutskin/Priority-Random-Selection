namespace Logic
{
    public static class MainLogic
    {
        public static List<Item> items = new();

        private const int _minPriorityValue = 1;
        private const int _maxPriorityValue = 3;
        private const int _itemsPerPriority = 5;

        public static void PopulateInitialItems()
        {

            for (int priority = _minPriorityValue; priority <= _maxPriorityValue; priority++)
            {
                for (int i = 0; i < _itemsPerPriority; i++)
                {
                    int itemNumber = ((priority - 1) * _itemsPerPriority) + i + 1;
                    items.Add(new Item($"Item_{itemNumber}", priority));
                }
            }
        }

        public static int GetMinPriorityValue()
        {
            return _minPriorityValue;
        }
        public static int GetMaxPriorityValue()
        {
            return _maxPriorityValue;
        }
    }

}
