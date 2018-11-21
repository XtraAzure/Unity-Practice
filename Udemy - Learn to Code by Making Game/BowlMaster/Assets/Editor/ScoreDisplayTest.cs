using System;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl1()
    {
        int[] rolls = { 1 };
        string rollsString = "1";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T02X()
    {
        int[] rolls = { 10 };
        string rollsString = "X ";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T03BowlSpareInLastFrame()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1,9,3 };
        string rollsString = "1111111111111111X93";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
}
