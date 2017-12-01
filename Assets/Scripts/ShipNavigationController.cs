using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipNavigationController : MonoBehaviour
{
	public float speed;

	public float lookDamp = 0.1f;

	// Update is called once per frame
	void Update ()
	{
		Vector3 dampSpeed = Vector3.zero;
		Quaternion newForward = Quaternion.LookRotation (Vector3.SmoothDamp (this.transform.forward, ThirdPersonCameraFollower.CameraForward, ref dampSpeed, lookDamp));
		this.transform.rotation = newForward;
		this.transform.Translate (this.transform.forward * speed * Time.deltaTime, Space.World);
	}
}
