using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficButton : MonoBehaviour
{
	public GameObject RedLight;
	public GameObject Greenlight;
	public GameObject YellowLight;
	public GameObject collider;
	public bool simulate = false;
	public float slowdowntime;
	public Transform LastVeh;
	public float DistApartLastVeh = 50f;
	//[HideInInspector]
	public bool red, yellow,green;
	[SerializeField]private float Timer;
	public bool addtoarray = false;
	// Start is called before the first frame update
	private void Start()
	{
		Timer = 0.0f;
	}
	//
	private void LateUpdate()
	{
		CheckForLastVehicle();
	}
	//
	private void Update()
	{
		
		
		Timer = 0.0f;
		red = true;
		yellow = false;
		green = false;
		//
		Greenlight.SetActive(green);
		YellowLight.SetActive(yellow);
		RedLight.SetActive(red);
		collider.SetActive(true);

		if (Input.GetKey(KeyCode.Mouse0))
		{
			if (gameObject.name == "ht_right_and_straightght")
			{
				green = true;
				yellow = false;
				red = false;
				collider.SetActive(false);

				Greenlight.SetActive(green);
				YellowLight.SetActive(yellow);
				RedLight.SetActive(red);
			}
//			else if (gameObject.name == "light_left")
//			{
//				green = true;
//				yellow = false;
//				red = false;
//				collider.SetActive(false);
//
//				Greenlight.SetActive(green);
//				YellowLight.SetActive(yellow);
//				RedLight.SetActive(red);
//			}

		}

	}
	//
	private void ESController()
	{
		Timer += Time.deltaTime;
		if (slowdowntime > Timer)
		{
			green = true;
			yellow = false;
			red = false;
		}
		else
		{
			green = false;
			yellow = true;
			red = false;
		}
		//
		Greenlight.SetActive(green);
		YellowLight.SetActive(yellow);
		RedLight.SetActive(red);
	}

	private float CalculateDistance(Vector3 currentposition, Vector3 targetposition)
	{
		Vector3 offset = targetposition - currentposition;
		float sqrlen = offset.sqrMagnitude;
		return sqrlen;
	}
	//
	private void CheckForLastVehicle()
	{
		if (LastVeh == null) return;
		if (CalculateDistance(this.transform.position, LastVeh.transform.position) > DistApartLastVeh * DistApartLastVeh)
		{
			addtoarray = false;
			LastVeh = null;
		}
	}
}
