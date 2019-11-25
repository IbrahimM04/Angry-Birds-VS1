using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenScript : MonoBehaviour {
    public GameObject pauseScreen;
    public GameObject pauseButton;
    public Transform canvas;
    public AudioListener audioListener;
    public List<AudioSource> audioSources;
    bool opened = false;

    private void Start() {
        //When script is started, the pauseScreen closes (for bug fix reasons).
        ClosePauseScreen();
    }

    private void Update() {
        //Opens the pause screen when the ESC key is pressed. 
        //TO DO: Also make it able to close by pressing ESC.
        if (Input.GetKeyDown(KeyCode.Escape) && opened == false) {
            OpenPauseScreen();
            opened = true;
        } else if (Input.GetKeyDown(KeyCode.Escape) && opened == true) {
            ClosePauseScreen();
            opened = false;
        }
    }
    
    //Function for opening the pause screen.
    public void OpenPauseScreen() {
        pauseScreen.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    //Function for closing the pause screen.
    public void ClosePauseScreen() {
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1.0f;
    }

    //Function for resetting the game (Resetting score and the game whole).
    public void ResetGame() {
        SceneManager.LoadScene("SampleScene");
        pauseButton.SetActive(true);
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    //Function, if it's correct, should mute all sounds (including music and SFX).
    public void MuteSounds() {
        foreach (AudioSource audioSorce in audioSources) {
            audioSorce.Stop();
        }
    }
}



