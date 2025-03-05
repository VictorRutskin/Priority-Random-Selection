using Logic;

namespace Unit_tests
{
    [Collection("Sequential")] 
    public class ProbabilityTests
    {

        [Fact]
        // Ensures DeterminePriority() only returns valid available priorities.
        public void DeterminePriority_ValidPriorities_ReturnsValidPriority()
        {
            List<int> availablePriorities = new() { 1, 2, 3 };
            Random random = new Random();
            int priority = Probability.DeterminePriority(availablePriorities, random);
            Assert.Contains(priority, availablePriorities);
        }


        // This test is probably useless because it can sometimes fail and sometimes succeed, i will keep it here for possible future re-usage
        //[Fact] // NOTE THAT THIS CAN FAIL BUT RARELY
        //public void DeterminePriority_Probabilities_AreWithinExpectedRange()
        //{
        //    List<int> availablePriorities = new() { 1, 2, 3 };
        //    Random random = new Random();
        //    Dictionary<int, int> priorityCounts = new() { { 1, 0 }, { 2, 0 }, { 3, 0 } };
        //    int totalRuns = 1000;

        //    for (int i = 0; i < totalRuns; i++)
        //    {
        //        int priority = Probability.DeterminePriority(availablePriorities, random);
        //        priorityCounts[priority]++;
        //    }

        //    double probability1 = (priorityCounts[1] / (double)totalRuns) * 100;
        //    double probability2 = (priorityCounts[2] / (double)totalRuns) * 100;
        //    double probability3 = (priorityCounts[3] / (double)totalRuns) * 100;

        //    Assert.InRange(probability1, 45, 75); // Expect around 60%
        //    Assert.InRange(probability2, 15, 45); // Expect around 30%
        //    Assert.InRange(probability3, 0, 20);  // Expect around 10%
        //}
    }

}
