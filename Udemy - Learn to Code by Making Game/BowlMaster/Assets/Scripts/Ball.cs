using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public bool inPlay = false;
    public Vector3 launchVelocity;

    private Vector3 ballStartPos;
    private Rigidbody rigidbody;
    private AudioSource audioSource;


	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        //Launch(launchVelocity);
        ballStartPos = transform.position;
    }
	
    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        rigidbody.useGravity = true;
        rigidbody.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void Reset()
    {
        inPlay = false;

        transform.position = ballStartPos;
        transform.rotation = Quaternion.identity;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.useGravity = false;
    }
}
