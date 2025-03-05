using Logic.Models;
namespace Logic
{
    class Probability
    {
        private readonly Dictionary<PriorityLevel, double> _probabilities = new()
        {
            { PriorityLevel.High, 0.6 },
            { PriorityLevel.Medium, 0.3 },
            { PriorityLevel.Low, 0.1 }
        };

       
    }
}
