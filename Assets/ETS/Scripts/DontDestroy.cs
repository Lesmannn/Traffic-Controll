using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	private static DontDestroy backgroundMusic;

	void Awake()
	{
		if (backgroundMusic == null)
		{
			backgroundMusic = this;
			DontDestroyOnLoad(backgroundMusic);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
