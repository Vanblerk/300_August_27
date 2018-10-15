using System.Collections;
using System.Collections.Generic;
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
        Volume.value = mySource.volume;
    }

    public static class SaveStuff
    {
        public static float VolumeG;
    }
}