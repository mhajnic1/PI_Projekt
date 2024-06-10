// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static int sceneOpened = 0;
    public int nonstaticSceneOpened;
    public static SceneController instance;
  
    private void Awake()
    {
        
        sceneOpened++;
        nonstaticSceneOpened = sceneOpened;
        Debug.Log(sceneOpened + "  ");
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }/*
        else
        {
            Destroy(gameObject);
        }*/
        //****************************************\\
        else if (instance != this)
        {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //******************************************\\
        if (sceneOpened > 2)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("CriticalPath"))
            {
                Destroy(g);
            }
            sceneOpened = 1;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

}
