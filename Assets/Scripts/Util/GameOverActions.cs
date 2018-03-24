using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverActions : MonoBehaviour {

    public void UseGameOverYesButtonAction()
    {
        Closed_Basics_3.LoadScene.Load(1);
    }

    public void UseGameOverNoButtonAction()
    {
        Closed_Basics_3.LoadScene.Load(0);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
