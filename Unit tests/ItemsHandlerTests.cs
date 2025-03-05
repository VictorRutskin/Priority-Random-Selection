using Logic;
using Logic.Handlers;
using Logic.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit_tests
{
    [Collection("Sequential")]
    public class ItemsHandlerTests
    {
        private readonly ItemsHandler _itemsHandler;
        private readonly GlobalVariables _globalVariables;

        public ItemsHandlerTests()
        {
            _globalVariables = new GlobalVariables();
            var probabilityHandler = new ProbabilityHandler();
            _itemsHandler = new ItemsHandler(probabilityHandler);
        }

        [Fact]
        // Ensures items are populated correctly when PopulateInitialItems() is called.
        public void PopulateInitialItems_ShouldFillItemsList()
        {
            _itemsHandler.PopulateInitialItems(_globalVariables.ProbabilityList);
            Assert.NotEmpty(_itemsHandler.Items);
        }

        [Fact]
        // Ensures SelectItem() returns a valid item when items are available.
        public void SelectItem_WithItems_ReturnsItem()
        {
            _itemsHandler.PopulateInitialItems(_globalVariables.ProbabilityList);
            Item? item = _itemsHandler.SelectItem(_globalVariables.AvailablePriorities, _globalVariables.ProbabilityList);
            Assert.NotNull(item);
            Assert.IsType<Item>(item);
        }

        [Fact]
        // Ensures SelectItem() returns null when all items have been selected.
        public void SelectItem_AllItemsSelected_ReturnsNull()
        {
            _globalVariables.ProbabilityList = new List<(int, double, int)> { (1, 60, 5), (2, 30, 5), (3, 10, 5) };

            _itemsHandler.PopulateInitialItems(_globalVariables.ProbabilityList);
            while (_itemsHandler.Items.Any())
            {
                _itemsHandler.SelectItem(_globalVariables.AvailablePriorities, _globalVariables.ProbabilityList);
            }
            Assert.Null(_itemsHandler.SelectItem(_globalVariables.AvailablePriorities, _globalVariables.ProbabilityList));
        }
    }
}
