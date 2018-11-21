using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    private GameManager gameManager;
    public Text standingDisplay;
    private bool ballOutOfPlay = false;
    private int lastSettledCounnt = 10;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private Ball ball;

    // Use this for initialization
    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    void UpdateStandingCountAndSettle()
    {
        // Update the lastStandingCount
        // Call PinsHaveSettled() when they have
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; // How long to wait to consider pins settled
        if ((Time.time - lastChangeTime) > settleTime) // If last change > 3s ago
        {
            PinsHaveSettled();
        }

    }

    int CountStanding()
    {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;

    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            ballOutOfPlay = true;
        }
    }

    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCounnt - standing;
        lastSettledCounnt = CountStanding();


        gameManager.Bowl(pinFall);
       

        lastStandingCount = -1; // Indicates pins have settled, and ball not back in box
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;

    }

    public void Reset()
    {
        lastSettledCounnt = 10;
    }
}
