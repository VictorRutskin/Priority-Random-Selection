namespace Logic.Models
{
    public class Item
    {
        private string _name;
        private int _priority;

        public Item(string name, int priority)
        {
            _name = name;
            SetPriority(priority); // Priority is set by the function to include validation
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public int GetPriority()
        {
            return _priority;
        }

        public void SetPriority(int priority)
        {
            // Validate priority is between acceptable range
            if (priority < MainLogic.GetMinPriorityValue() || priority > MainLogic.GetMaxPriorityValue())
            {
                // Will need to handle this exception somehow
            }
            else
            {
                _priority = priority;
            }
        }

    }
}
