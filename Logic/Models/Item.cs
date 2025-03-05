namespace Logic.Models
{
    public class Item
    {
        private string _name;
        private int _priority;

        public Item(string name, int priority)
        {
            _name = name;
            _priority = priority;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetPriority()
        {
            return _priority;
        }
    }
}
