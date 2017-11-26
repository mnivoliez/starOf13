using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;



public class AudioManager : MonoBehaviour, IPhaseDriven {
	[SerializeField]
	public Sound[] sounds;

	// Use this for initialization
	void Awake () {
		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}

	}

	void Start () {
		Play ("Music_Normal");
	}


	public void Play (string name) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning ("!!!!!!!!!!!!!! Fichier " + name + " non trouvé !!!!!!!!!!!!");
			return;
		}
		s.source.Play ();
	}

	public void Stop (string name) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning ("!!!!!!!!!!!!!! Fichier " + name + " non trouvé !!!!!!!!!!!!");
			return;
		}
		s.source.Stop ();
	}

	// Switch music

	#region IPhaseDriven implementation

	public void EnterPhase (Phase phase) {
		switch (phase) {
		case Phase.BISOUNOURS:
			Stop ("Music_V13");
			Play ("Music_Normal");
			break;
		case Phase.FRIDAY_13:
			Stop ("Music_Normal");
			Play ("Music_V13");
			break;
		}
	}

	#endregion
}
