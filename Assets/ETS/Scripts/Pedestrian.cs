using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pedestrian : MonoBehaviour
{
	public NavMeshAgent agent;
	public Animator anim;

	public GameObject Path;
	public Transform[] PathPoints;
	public int index = 0;
	public float minDistance = 10;
    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();

		PathPoints = new Transform[Path.transform.childCount];
		for (int i = 0; i < PathPoints.Length; i++)
		{
			PathPoints[i] = Path.transform.GetChild(i);
		}
    }

    // Update is called once per frame
    void Update()
    {
		Roam();
    }

	void Roam()
	{
		if (Vector3.Distance(transform.position, PathPoints[index].position) < minDistance)
		{
			if (index > 0 && index < PathPoints.Length)
			{
				index += 1;
			}
			else
			{
				index = 0;
			}
		}
			
		agent.SetDestination(PathPoints[index].position);
		anim.SetFloat("vertical", !agent.isStopped ? 1 : 0);
	}
}
