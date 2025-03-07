﻿using Logic;
using Xunit;
using System;
using System.Collections.Generic;

namespace Unit_tests
{
    [Collection("Sequential")]
    public class GlobalVariablesTests
    {
        private readonly GlobalVariables _globalVariables;

        public GlobalVariablesTests()
        {
            _globalVariables = new GlobalVariables();
        }

        [Fact]
        // Checks if ValidateGlobalVariables runs without errors when given valid data.
        public void ValidateGlobalVariables_ValidData_ShouldNotThrowException()
        {
            _globalVariables.ProbabilityList = new List<(int, double, int)> { (1, 60, 5), (2, 30, 5), (3, 10, 5) };
            Exception? ex = Record.Exception(() => _globalVariables.ValidateGlobalVariables());
            Assert.Null(ex);
        }

        [Fact]
        // Throws an exception if the total chance percentage isn't 100.
        public void ValidateGlobalVariables_InvalidTotalChance_ShouldThrowException()
        {
            _globalVariables.ProbabilityList = new List<(int, double, int)> { (1, 50, 5), (2, 30, 5), (3, 10, 5) };
            Assert.Throws<ArgumentException>(() => _globalVariables.ValidateGlobalVariables());
        }

        [Fact]
        // Throws an exception if there are duplicate priorities in the probability list.
        public void ValidateGlobalVariables_DuplicatePriorities_ShouldThrowException()
        {
            _globalVariables.ProbabilityList = new List<(int, double, int)> { (1, 50, 5), (1, 50, 5) };
            Assert.Throws<ArgumentException>(() => _globalVariables.ValidateGlobalVariables());
        }

        [Fact]
        // Throws an exception if any probability value is negative.
        public void ValidateGlobalVariables_NegativeChance_ShouldThrowException()
        {
            _globalVariables.ProbabilityList = new List<(int, double, int)> { (1, -10, 5), (2, 110, 5) };
            Assert.Throws<ArgumentException>(() => _globalVariables.ValidateGlobalVariables());
        }

        [Fact]
        // Ensures TimesToRun is within the allowed range (1 - 10,000).
        public void ValidateGlobalVariables_TimesToRunOutOfBounds_ShouldThrowException()
        {
            _globalVariables.TimesToRun = 10001;
            Assert.Throws<ArgumentException>(() => _globalVariables.ValidateGlobalVariables());

            _globalVariables.TimesToRun = 0;
            Assert.Throws<ArgumentException>(() => _globalVariables.ValidateGlobalVariables());
        }
    }
}
