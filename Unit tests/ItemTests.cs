using Logic.Models;

namespace Unit_tests
{
    [Collection("Sequential")]
    public class ItemTests
    {
        [Fact]
        // Checks if an item is created with the correct name and priority.
        public void Item_Creation_SetsCorrectProperties()
        {
            Item item = new Item("TestItem", 5);
            Assert.Equal("TestItem", item.GetName());
            Assert.Equal(5, item.GetPriority());
        }
    }
}
