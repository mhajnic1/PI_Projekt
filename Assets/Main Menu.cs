using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour{
    public void PlayGame(){
        SceneManager.LoadScene("BeginningScene");
    }

    public void GoSettingsMenu(){
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void GoToAudioSettingsMenu(){
        SceneManager.LoadScene("AudioMenu");
    }

}
