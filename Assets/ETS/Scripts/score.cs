using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
	private Rigidbody CarRb;

	private IEnumerator invicCheck()
	{
		CarRb.detectCollisions = false;
		CarRb.isKinematic = true;
		yield return new WaitForSeconds(0f);
		Destroy(gameObject);
	}


	private void OnCollisionEnter(Collision collision)
	{
		Physics.IgnoreCollision(GetComponent<SphereCollider>(),GetComponent<Collider>());

		if (collision.gameObject.name == "destroyer")
		{
			GameManager.instance.score++;
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "EVehicle")
		{
			SoundManager.instance.CrashSFX();
			Debug.Log("test2");

			Destroy(gameObject);
		}
		if (collision.gameObject.tag == "AIVehicle")
		{
			SoundManager.instance.CrashSFX();

			Destroy(gameObject);
		}
	}
}
