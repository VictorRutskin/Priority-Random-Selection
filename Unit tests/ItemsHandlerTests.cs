using Logic;
using Logic.Models;

namespace Unit_tests
{
    [Collection("Sequential")] 
    public class ItemsHandlerTests
    {
        [Fact]
        // Ensures items are populated correctly when PopulateInitialItems() is called.
        public void PopulateInitialItems_ShouldFillItemsList()
        {
            ItemsHandler.PopulateInitialItems();
            Assert.NotEmpty(ItemsHandler.items);
        }

        [Fact]
        // Ensures SelectItem() returns a valid item when items are available.
        public void SelectItem_WithItems_ReturnsItem()
        {
            ItemsHandler.PopulateInitialItems();
            Item item = ItemsHandler.SelectItem();
            Assert.NotNull(item);
            Assert.IsType<Item>(item);
        }

        [Fact]
        // Ensures SelectItem() returns null when all items have been selected.
        public void SelectItem_AllItemsSelected_ReturnsNull()
        {
            GlobalVariables.ProbabilityList = new List<(int, double, int)> { (1, 60, 5), (2, 30, 5), (3, 10, 5) };

            ItemsHandler.PopulateInitialItems();
            while (ItemsHandler.items.Any())
            {
                ItemsHandler.SelectItem();
            }
            Assert.Null(ItemsHandler.SelectItem());
        }

        [Fact]
        // Tries to select 16 items when only 15 exist and ensures the last attempt returns null.
        public void SelectItem_AfterExhaustingAllItems_ThrowsExpectedError()
        {
            // Set up 15 items in total
            GlobalVariables.ProbabilityList = new List<(int, double, int)> { (1, 50, 5), (2, 30, 5), (3, 20, 5) };
            GlobalVariables.ResetAvailablePriorities();
            GlobalVariables.TimesToRun = 15;

            ItemsHandler.PopulateInitialItems();

            // Select 15 items (exhausting the list)
            for (int i = 0; i < 15; i++)
            {
                Assert.NotNull(ItemsHandler.SelectItem());
            }

            // Try selecting the 16th item, expecting null
            var extraItem = ItemsHandler.SelectItem();
            Assert.Null(extraItem);
        }
    }
  
}
