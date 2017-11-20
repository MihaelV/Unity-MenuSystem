using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
    // we need public variable of Slider for manipulating slider
    public Slider volumeSlider;
    // we need public variable of LevelManager to load scenes
    public LevelManager levelManager;


    //because slider sets volume level ve ned music manager
    private MusicManager musicManager;

    // Use this for initialization
    void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>(); // because ve made musicManager private we have to find it through code
        volumeSlider.value = PlayerPrefsManager.getMasterVolume();  // we are setting value to slider from PlayerPrefsManager     
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.SetVolume(volumeSlider.value); // every update we are setting volume and we are reading it from slider, which means if we move volume slider it will immediately change sound volume
    }
    

    // connected to button back in Options scene 
    // when we go back from options to main menu we are setting value of sound to playerprefsmanager 
    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        levelManager.LoadLevel(1);
    }


    
    // connected to button defaults
    // every time defaults button is pressed slider is put to default state 0.5 and the volume automaticly sets it self to 0.5 (50%); 
    public void SetDefaults()
    {
        volumeSlider.value = 0.5f;
    }
}
