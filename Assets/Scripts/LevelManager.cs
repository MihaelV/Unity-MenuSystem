using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    // Gets current scene build index adds 1 and loads next scene in build index order
    public void LoadNextLevel()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    
    // Loads scene by its build index which ever we set to load
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
	

    // Quits game on Android or Standalone projects when they are already build for that platform
    // Game will not exit if you are play testing in editor (Unity)
    public void Exit()
    {
        Application.Quit();
        // To be sure if function is called
        Debug.Log("Function Exit Called ! ");
    }
    

    // if Level 1 was loaded then return true else return false
    public bool NoStartOver()
    {
        if (SceneManager.GetActiveScene().buildIndex > 2)
        {
            return true;
        }
        else return false;
    }

}
