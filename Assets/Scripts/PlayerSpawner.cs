using System.Diagnostics;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // Reference to the player GameObject
    public GameObject player;
    public GameObject otherGameObject;
    static PlayerSpawner instance;

    // The new spawn position
    public Vector3 spawnPosition;

    // Optional: spawn rotation
    public Quaternion spawnRotation = Quaternion.identity;
    void awake()
    {
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

    }
  
void start()
    {
        UnityEngine.Debug.Log("Startalo");
        SceneController tmpValue = otherGameObject.GetComponent<SceneController>();
        // Method to spawn the player at the new location
        int value = tmpValue.nonstaticSceneOpened;
        if (value > 2)
        {
            UnityEngine.Debug.Log("Proslo u prvi if");
            SpawnPlayer();
        }
    }
    void SpawnPlayer()
    {        
            if (player != null)
            {
            UnityEngine.Debug.Log("Proslo");
            player.transform.position = spawnPosition;
                player.transform.rotation = spawnRotation;
            }
    }
}