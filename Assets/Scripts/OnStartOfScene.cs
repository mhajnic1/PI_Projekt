using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartOfScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
        GameObject obj = GameObject.FindGameObjectWithTag("Music");
        if(obj){
            Destroy(obj);
        }
            
    }

   
}
