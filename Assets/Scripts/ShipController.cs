using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
	public float speed;

	public float rotationSpeed;

	public float rotationMultiplier;

	// Update is called once per frame
	void Update ()
	{
		Quaternion newForward = Quaternion.LookRotation (ThirdPersonCameraFollower.CameraForward);
		Vector3 newForwardEulerAngles = newForward.eulerAngles;
		newForwardEulerAngles.x = AngleUtilities.ClampRangeSymDeg (newForwardEulerAngles.x, 180f);
		newForwardEulerAngles.y = AngleUtilities.ClampRangeSymDeg (newForwardEulerAngles.y, 180f);
		newForwardEulerAngles.x = Mathf.Clamp (newForwardEulerAngles.x * rotationMultiplier, -90f, 90f);
		newForwardEulerAngles.y = Mathf.Clamp (newForwardEulerAngles.y * rotationMultiplier, -90f, 90f);
		newForward.eulerAngles = newForwardEulerAngles;
		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, newForward, Time.deltaTime * rotationSpeed);
		this.transform.Translate (this.transform.forward * speed * Time.deltaTime, Space.World);
	}
}
