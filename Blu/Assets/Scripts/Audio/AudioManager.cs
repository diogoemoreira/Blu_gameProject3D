using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;
	String currentBackground;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}
		else
		{
			instance = this;
			//DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
		currentBackground = "MainTheme";
		Play("MainTheme");
	}

	public void Play(string sound, bool changeBackground=false, bool repeatable = false)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		if (changeBackground){
			Sound current = Array.Find(sounds, item => item.name == currentBackground);
			current.source.Stop();
			currentBackground = sound;
		}

		if (repeatable)
        {
			s.source.Play();
		}

		else if (!s.source.isPlaying)
		{
			s.source.Play();
		}
	}

	public void Play(AudioSource sound)
	{
		if (!sound.isPlaying)
		{
			Debug.Log("playing: " + sound);
			sound.Play();

        }
        else
        {
			Debug.Log("already playing" + sound);
        }
	}

	public void ChangeMainSong(){
		
	}

}
