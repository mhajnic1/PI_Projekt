// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
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
