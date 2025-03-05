namespace Logic
{
    class Item
    {
        private string _name;
        private int _priority;

        private const int _minPriorityValue = 1;
        private const int _maxriorityValue = 3;

        public Item(string name, int priority)
        {
            SetName(name);
            SetPriority(priority);
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
            // validate priority is between acceptable range
            if (priority < _minPriorityValue || priority > _maxriorityValue)
            {
                // will need to handle this exception somehow
            }
            else
            {
                _priority = priority;
            }
        }
    }
}
