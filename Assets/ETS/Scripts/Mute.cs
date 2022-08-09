using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
	private int i = 0;

	private AudioSource audio;

	private void Awake()
	{
		audio = GetComponent<AudioSource>();
	}
	public void MuteBGM()
	{
		i += 1;
		audio.mute = true;
		if (i % 2 == 0)
		{
			audio.mute = false;
		}
	}
}
