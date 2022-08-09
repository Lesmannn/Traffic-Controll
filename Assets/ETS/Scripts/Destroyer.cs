using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float duration;
    
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    private void deactivateRB()
    {
       rb.detectCollisions = false;
       //rb.isKinematic = true;
    }

    private void activateCollider()
    {
        GetComponent<Collider>().enabled = true;
    }



    void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "destroyer")
		{
			destroy();
		}

        if (col.gameObject.tag == "AIVehicle")
        {

            Debug.Log("test");
            
            StartCoroutine(invicCheck());

        }
		if (col.gameObject.tag == "EVehicle")
		{
			destroy();
		}
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
    }


    void destroy()
	{
		Destroy(this.gameObject);
	}

    private IEnumerator invicCheck()
    {
        deactivateRB();
        GameManager.instance.life--;
        yield return new WaitForSeconds(0f);
        destroy();
        
        
       
    }

}
