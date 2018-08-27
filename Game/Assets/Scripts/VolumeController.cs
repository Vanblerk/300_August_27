﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour {
    public Slider Volume;
	// public AudioListener sound;
	public AudioSource mySource;

    void Start(){
        mySource = GetComponent<AudioSource>();
		mySource.Play();
    }

    void Update() {
        mySource.volume = Volume.value;
        SaveStuff.VolumeG = Volume.value;
    }

    public static class SaveStuff
    {
        public static float VolumeG;
    }
}



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class VolumeController : MonoBehaviour {

//     // Reference to Audio Source component
//     private AudioSource audioSrc;

//     // Music volume variable that will be modified
//     // by dragging slider knob
//     private float musicVolume = 0.1f;

// 	// Use this for initialization
// 	void Start () {

//         // Assign Audio Source component to control it
//         audioSrc = GetComponent<AudioSource>();
// 	}
	
// 	// Update is called once per frame
// 	void Update () {

//         // Setting volume option of Audio Source to be equal to musicVolume
//         audioSrc.volume = musicVolume;
// 	}

//     // Method that is called by slider game object
//     // This method takes vol value passed by slider
//     // and sets it as musicValue
//     public void SetVolume(float vol)
//     {
//         musicVolume = vol;
//     }
// }
