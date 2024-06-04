// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
   public void Awake(){
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
        if(obj.Length > 1){
                Destroy(this.gameObject);
        }
        else{
            DontDestroyOnLoad(this.gameObject);
        }
   }
}
