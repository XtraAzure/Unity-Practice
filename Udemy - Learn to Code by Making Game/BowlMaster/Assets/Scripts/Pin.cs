﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingTreshold = 3f;
    public float distanceToRaise = 40f;
    // Use this for initialization

    private Rigidbody rigidbody;

    void Start () {
        IsStanding();
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(270-rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (tiltInX < standingTreshold && tiltInZ < standingTreshold)
        {
            return true;
        }
        else
            return false;
    }

    public void RaiseIfStanding()
    {
        if (IsStanding())
        {
            rigidbody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f, 0f, 0f);
        }
    }

    public void Lower()
    {
        transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
        rigidbody.useGravity = true;
    }
}
