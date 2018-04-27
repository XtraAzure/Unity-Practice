using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NumberWizards : MonoBehaviour {
	// Use this for initialization
	int max;
	int min;
	int guess;

    public int MaxGuessesAllowed = 7;

    public Text text;

	void Start () {
		StartGame();
	}
	
	void StartGame () {
		max = 1000;
		min = 1;
        NextGuess();
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }

	void NextGuess () {
        guess = Random.Range(min, max);
        text.text = guess.ToString();
        MaxGuessesAllowed = MaxGuessesAllowed - 1;
        if (MaxGuessesAllowed <=0)
        {
            Application.LoadLevel("Win");
        }
	}
}
