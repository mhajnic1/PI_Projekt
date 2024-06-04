// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof (Slider))]
public class AudioSliderScript : MonoBehaviour
{
    Slider slider
    {
        get{ return GetComponent<Slider>(); }
    }
    public AudioMixer mixer;
    public string volumeName;
    public void UpdateValueOnChange(float value)
    {
        mixer.SetFloat(volumeName, Mathf.Log(value)*20f);  //formula koristena jer mixer koristi eksponencijalne vrijednosti, a slider linearne
    }
}
