using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{

	public float speed;

	void Update ()
	{
		this.transform.Translate (this.transform.forward * Time.deltaTime * speed, Space.World);
	}

	void OnTriggerEnter (Collider other)
	{
		Destroy (this.gameObject);
	}
}
