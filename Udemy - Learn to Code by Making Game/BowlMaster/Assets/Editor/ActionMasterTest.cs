using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest {

    private List<int> pinFalls;
	//private ActionMaster actionMaster;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

	[SetUp]
	public void Setup () {
        pinFalls = new List<int>();
    }

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}
  
	[Test]
	public void T01OneStrikeReturnsEndTurn () {
        pinFalls.Add(10);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(pinFalls));
	}

  [Test]
  public void T02Bowl8ReturnsTidy () {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T04Bowl28SpareReturnsEndTurn () {
        int[] rolls = { 2,8};
        Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T05CheckResetAtStrikeInLastFrame () {
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,10};
    
        Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T06CheckResetAtSpareInLastFrame () {
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,9};
        Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07YouTubeRollsEndInEndGame () {
    int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2,9};

    Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    /*
    [Test]
    public void T08GameEndsAtBowl20 () {
    int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1};
    foreach (int roll in rolls) {
    actionMaster.Bowl (roll);
    }
    Assert.AreEqual (endGame, actionMaster.Bowl (1));
    }

    [Test]
    public void T09DarylBowl20Test()
    {
    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
    foreach (int roll in rolls)
    {
    actionMaster.Bowl(roll);
    }
    Assert.AreEqual(tidy, actionMaster.Bowl(1));
    }

    [Test]
    public void T10BenslBowl20Test()
    {
    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
    foreach (int roll in rolls)
    {
    actionMaster.Bowl(roll);
    }
    Assert.AreEqual(tidy, actionMaster.Bowl(0));
    }


    [Test]
    public void T11NathanBowlIndexTest()
    {
    int[] rolls = { 0, 10, 5 };
    foreach (int roll in rolls)
    {
    actionMaster.Bowl(roll);
    }
    Assert.AreEqual(tidy, actionMaster.Bowl(1));
    }

    [Test]
    public void T12Dondi10thFrameTurkey()
    {
    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    foreach (int roll in rolls)
    actionMaster.Bowl(roll);
    Assert.AreEqual(reset, actionMaster.Bowl(10));
    Assert.AreEqual(reset, actionMaster.Bowl(10));
    Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }

    [Test]
    public void T13ZeroOneGivesEndTurn()
    {
    actionMaster.Bowl(1);
    Assert.AreEqual(endTurn, actionMaster.Bowl(1));
    }*/
    }