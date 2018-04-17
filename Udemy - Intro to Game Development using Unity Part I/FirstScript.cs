using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour {


    public float distance;
    public int count;
    public string message;
    public bool finished;
    public GameObject the_aliveworm;
    public GameObject the_deadworm;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("right"))
        {
            Flip("right");
            transform.Translate(0.2f, 0f, 0f);
        }

        if (Input.GetKey("left"))
        {
            Flip("left");
            transform.Translate(-0.2f, 0f, 0f);
        }

        if (Input.GetKey("up"))
        {
            transform.Translate(0f, 0.2f, 0f);
        }

        if (Input.GetKey("down"))
        {
            transform.Translate(0f, -0.2f, 0f);
        }
	}


    public void Flip(string direction)
    {
        var thescale = transform.localScale;

        if (direction == "right")
        {
            thescale.x = 1.0f;
        }
        else
        {
            thescale.x = -1.0f;
        }
        transform.localScale = thescale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name =="Worm")
        {
            the_aliveworm.SetActive(false);
            the_deadworm.SetActive(true);
        }

        if (collision.gameObject.name == "launchtree")
        {
            the_aliveworm.SetActive(true);
            the_deadworm.SetActive(false);
        }
    }
}
