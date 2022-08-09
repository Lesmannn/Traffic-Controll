using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance;

	public AudioClip uiButton;
	public AudioClip win;
	public AudioClip gameOver;
	public AudioClip crash;
	public AudioClip text1;
	public AudioClip[] Voice;
	private int i = 0;

	private AudioSource audio;

	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}
		audio = GetComponent<AudioSource>();
	}

	public void UIClickSFX()
	{
		audio.PlayOneShot(uiButton);
	}
	public void WinSFX()
	{
		audio.PlayOneShot(win);
	}
	public void GameOverSFX()
	{
		audio.PlayOneShot(gameOver);
	}
	public void CrashSFX()
	{
		audio.PlayOneShot(crash);
	}
	public void Mute()
	{
		i += 1;
		audio.mute = true;
		if (i % 2 == 0)
		{
			audio.mute = false;
		}
	}
	public void Suara1()
	{
		audio.PlayOneShot(text1);
	}
	public void VoiceText(int i)
	{
		audio.PlayOneShot(Voice[i]);
	}
}
