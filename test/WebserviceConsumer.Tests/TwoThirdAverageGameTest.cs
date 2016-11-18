﻿using System;
using Xunit;
using WebserviceConsumer.Model;
using System.Collections.Generic;

namespace Tests
{
    public class TwoThirdAverageGameTest
    {
        

        [Fact]
        public void ResetWorks() 
        {
            TwoThirdAverageGame.Reset();
            Assert.Equal(0, TwoThirdAverageGame.GetNumberOfSubmissions());
            Assert.Equal(0, TwoThirdAverageGame.GetTwoThirdOfAverage());
            Assert.Equal("No one", TwoThirdAverageGame.GetWinner());

            TwoThirdAverageGame.Submit("Adrian", 25);

            Assert.Equal(1, TwoThirdAverageGame.GetNumberOfSubmissions());
            Assert.True(TwoThirdAverageGame.GetTwoThirdOfAverage() > 0);
            Assert.Equal("Adrian", TwoThirdAverageGame.GetWinner());

            TwoThirdAverageGame.Reset();
            Assert.Equal(0, TwoThirdAverageGame.GetNumberOfSubmissions());
            Assert.Equal(0, TwoThirdAverageGame.GetTwoThirdOfAverage());
            Assert.Equal("No one", TwoThirdAverageGame.GetWinner());
        }

        [Fact]
        public void SamePlayerSubmittingShouldHaveHisValueUpdated()
        {
            double expected = 21;
            TwoThirdAverageGame.Reset();

            TwoThirdAverageGame.Submit("Adrian", 25);
            TwoThirdAverageGame.Submit("Adrian", expected);
            double actual = TwoThirdAverageGame.GetValueThisPersonSubmitted("Adrian");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SamePlayerSubmittingShouldNotIncreaseTotalCount()
        {
            double expected = 1;
            TwoThirdAverageGame.Reset();

            TwoThirdAverageGame.Submit("Adrian", 25);
            TwoThirdAverageGame.Submit("Adrian", 21);
            double actual = TwoThirdAverageGame.GetNumberOfSubmissions();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Adrian")]
        [InlineData(" Adrian")]
        [InlineData("Adrian ")]
        [InlineData(" Adrian ")]
        [InlineData("   Adrian")]
        [InlineData("Adrian   ")]
        [InlineData("   Adrian   ")]
        public void PlayerNamesShouldBeTrimmedOnSubmission(string name)
        {
            string expected = "Adrian";
            TwoThirdAverageGame.Reset();

            TwoThirdAverageGame.Submit(name, 25);
            List<string> players = TwoThirdAverageGame.GetPlayerList();
            var actual = players[0];

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Adrian Cheong")]
        [InlineData(" Adrian Cheong")]
        [InlineData("Adrian Cheong ")]
        [InlineData(" Adrian Cheong ")]
        [InlineData("Adrian  Cheong")]
        [InlineData(" Adrian  Cheong ")]
        [InlineData("   Adrian Cheong")]
        [InlineData("Adrian Cheong   ")]
        [InlineData("   Adrian   Cheong   ")]
        public void PlayerNamesShouldBeTrimmedOnSubmission2(string name)
        {
            string expected = "Adrian Cheong";
            TwoThirdAverageGame.Reset();

            TwoThirdAverageGame.Submit(name, 25);
            List<string> players = TwoThirdAverageGame.GetPlayerList();
            var actual = players[0];

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Adrian", -1)]
        [InlineData("Adrian", 101)]
        [InlineData("Adrian", -0.00000001)]
        [InlineData("Adrian", 100.00000001)]
        [InlineData("Adrian", double.MaxValue)]
        [InlineData("Adrian", double.MinValue)]
        [InlineData("Adrian", double.NaN)]
        [InlineData("Adrian", double.NegativeInfinity)]
        [InlineData(null, 25)]
        [InlineData("", 25)]
        [InlineData(" ", 25)]
        public void PlayersDoingStupidThingsShouldBeIgnored(string name, double number)
        {
            TwoThirdAverageGame.Reset();

            TwoThirdAverageGame.Submit(name, number);

            Assert.Equal(0, TwoThirdAverageGame.GetNumberOfSubmissions());
            Assert.Equal(0, TwoThirdAverageGame.GetTwoThirdOfAverage());
            Assert.Equal("No one", TwoThirdAverageGame.GetWinner());
        }

        [Theory]
        [InlineData("Adrian", -1)]
        [InlineData("Adrian", 101)]
        [InlineData("Adrian", -0.00000001)]
        [InlineData("Adrian", 100.00000001)]
        [InlineData("Adrian", double.MaxValue)]
        [InlineData("Adrian", double.MinValue)]
        [InlineData("Adrian", double.NaN)]
        [InlineData("Adrian", double.NegativeInfinity)]
        [InlineData(null, 25)]
        [InlineData("", 25)]
        [InlineData(" ", 25)]
        public void PlayersDoingStupidThingsShouldBeIgnoredWhenTheGameHasAlreadyBegun(string stupidName, double stupidNumber)
        {
            TwoThirdAverageGame.Reset();
            TwoThirdAverageGame.Submit("Proper Person", 24);

            TwoThirdAverageGame.Submit(stupidName, stupidNumber);

            Assert.Equal(1, TwoThirdAverageGame.GetNumberOfSubmissions());
            Assert.Equal(16, TwoThirdAverageGame.GetTwoThirdOfAverage());
            Assert.Equal("Proper Person", TwoThirdAverageGame.GetWinner());
        }
    }
}
