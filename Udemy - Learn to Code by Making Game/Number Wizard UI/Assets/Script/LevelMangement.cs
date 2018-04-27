using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMangement : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Debug.Log("Change scene" + name);
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
