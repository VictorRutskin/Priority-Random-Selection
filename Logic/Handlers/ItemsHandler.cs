using Logic.Models;
using System;

namespace Logic.Handlers
{
    public class ItemsHandler
    {
        private readonly List<Item> _items = new();
        private readonly ProbabilityHandler _probabilityhandler;
        private readonly Random _random = new Random();

        public ItemsHandler(ProbabilityHandler probabilityHandler)
        {
            _probabilityhandler = probabilityHandler;
        }

        // Public getter to expose _items for testing
        public IReadOnlyList<Item> Items => _items;


        // Add initial items based on the probability list, the values are handles from the probability list so values can be modified easily and keep same original logic
        public void PopulateInitialItems(List<(int Priority, double Chance, int AmountOfItems)> probabilityList)
        {
            foreach (var (priority, _, amount) in probabilityList)
            {
                for (int i = 0; i < amount; i++)
                {
                    _items.Add(new Item($"Item_{_items.Count + 1}", priority));
                }
            }
        }

        public Item? SelectItem(List<int> availablePriorities, List<(int Priority, double Chance, int AmountOfItems)> probabilityList)
        {
            if (!_items.Any()) return null;

            // If any priority is still available, continue - else stop
            while (availablePriorities.Any())
            {
                int selectedPriority = _probabilityhandler.DeterminePriority(availablePriorities, probabilityList);
                var filteredItems = _items.Where(item => item.GetPriority() == selectedPriority).ToList();

                if (filteredItems.Count > 0)
                {
                    Item selectedItem = filteredItems[_random.Next(filteredItems.Count)];
                    _items.Remove(selectedItem);
                    return selectedItem;
                }

                // Remove priority from available list if no items found
                availablePriorities.Remove(selectedPriority);
            }
            return null;
        }
    }


}
