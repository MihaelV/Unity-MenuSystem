using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTime : MonoBehaviour {

	
	// Update is called once per frame
    // Inside Update method we are checking if time from the point since level loaded is greater than 10 if it is we are loading next scene 
    // Basicly this is kind of a intro into game that is on screen for 10 seconds
	void Update () {
		if(Time.timeSinceLevelLoad >= 10f)
        {
            LevelManager l = new LevelManager();
            l.LoadNextLevel();            
        }
	}
}
