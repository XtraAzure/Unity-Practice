﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

    // Returns a list of cumulative scores, like a normal score card.
    public static List<int> ScoreCumulative (List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach(int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }
        return cumulativeScores;
    }

    // Return a list of individual frame scores.
	public static List<int> ScoreFrames (List<int> rolls)
    {
        List<int> frameList = new List<int>();

        // Index i points to 2nd bowl of frame
        for (int i = 1; i < rolls.Count; i+=2) 
        {
            if(frameList.Count == 10) // Prevent's 11th frame score
            {
                break;
            }

            if (rolls[i-1] + rolls[i] < 10) // Normal "open" frame
            {
                frameList.Add(rolls[i - 1] + rolls[i]);
            }

            if (rolls.Count -i <=1 ) // Ensure at least 1 looked-ahead available
            {
                break;
            }

            if (rolls[i-1] == 10) // STRIKE
            {
                i--; // Strike frame has just one bowl
                frameList.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            else if (rolls[i-1] + rolls[i] == 10) // SPARE bonus
            {
                frameList.Add(10 + rolls[i + 1]);
            }
        }
        // Your code here


        return frameList;
    }
}
