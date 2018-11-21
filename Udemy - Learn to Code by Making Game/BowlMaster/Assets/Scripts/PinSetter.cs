using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public GameObject pinSet;
   
    private Animator animator;
    private PinCounter pinCounter;
    ActionMaster actionMaster = new ActionMaster(); // We need it here as we want only 1 instance
    

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}

    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }

    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        // Make new pins
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position += new Vector3(0, 30, 0);
    }

   

    // Update is called once per frame
    void Update () {
       
    }

    public void PerfomAction (ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle end game yet");
        }
    }

   

    

    /*private void OnTriggerEnter(Collider collider)
    {
        GameObject thingHit = collider.gameObject;

        // Ball enters play box
        if (thingHit.GetComponent<Ball>())
        {
            ballOutOfPlay = true;
            standingDisplay.color = Color.red;
        }
    }*/
}
