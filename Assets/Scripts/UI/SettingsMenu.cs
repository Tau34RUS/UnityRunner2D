using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	public float stored_volume;

	void Start () {

		if(PlayerPrefs.HasKey("MainVolume")){

			stored_volume = PlayerPrefs.GetFloat ("MainVolume");
			audioMixer.SetFloat ("SFXVolume", stored_volume);
		}
	}

	public void SetVolume (float volume) {

		audioMixer.SetFloat ("SFXVolume", volume);
		PlayerPrefs.SetFloat ("MainVolume", volume);

	}

}
