using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray; // array of audio clips see how it's used in OnLevelWasLoaded function

    private AudioSource audioSource;
    private LevelManager levelManager;

    bool firsttime = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
      
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.getMasterVolume();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level]; // when scene is loaded from the function we get build index and index at array is the index of song thath we want to play. So we set it to  thisLevelMusic  and later on we play it
        Debug.Log("Playing clip: " + thisLevelMusic + ","+level);
        if (levelManager.NoStartOver()) // if we went to level 1 after going to options and then at some point we came to main menu again we want to play main menu music again and interupt game music
        {
            firsttime = true;
        }
        
            if (thisLevelMusic && firsttime) // If there's some music attached, if it's not then music will not be interupterd or start over from beginning it will just continue to play only when getting back from options scene
            {                   
                audioSource.clip = thisLevelMusic;
                audioSource.loop = true;
                audioSource.Play();
                
            }
        if (levelManager.NoStartOver()) // if we went from menu direct to level 1 then we set firsttime true because if we return to main menu on some point of the game we want that music to play again and interupt game music
        {
            firsttime = true;
        }
        else // if we went to options and back we set firsttime to false because we don't want to start new music 
        {
            firsttime = false;
        }

        
    }
    


    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
