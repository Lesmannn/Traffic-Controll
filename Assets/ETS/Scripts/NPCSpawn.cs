using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
	public GameObject spawnObject1;
	public GameObject spawnObject2;
	public float spawnTime;
	public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void Spawn()
	{
		Instantiate(spawnObject1, transform.position, transform.rotation);
	}
}
