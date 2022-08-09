using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
	public GameObject red, yellow, green;
	public GameObject collider;
    // Start is called before the first frame update
    void Start()
    {
		red.SetActive(true);
		yellow.SetActive(false);
		green.SetActive(false);
		collider.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	public void buttonClicked()
	{
		SoundManager.instance.UIClickSFX();
		if (red.activeInHierarchy == true)
		{
			red.SetActive(false);
			yellow.SetActive(false);
			green.SetActive(true);
			collider.SetActive(false);
		}
		else
		{
			red.SetActive(true);
			yellow.SetActive(false);
			green.SetActive(false);
			collider.SetActive(true);
		}
	}
}
