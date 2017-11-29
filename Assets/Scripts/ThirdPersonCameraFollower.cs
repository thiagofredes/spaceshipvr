using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraFollower : MonoBehaviour
{
	public static Vector3 CameraForward {
		get {
			return _instance.transform.forward;
		}
	}

	public static Vector3 CameraRight {
		get {
			return _instance.transform.right;
		}
	}

	public GameObject followObject;

	public float followDistance;

	private Vector3 orbit;

	private static ThirdPersonCameraFollower _instance;

	void Awake ()
	{
		_instance = this;
		orbit = (this.transform.position - followObject.transform.position).normalized;
		this.transform.position = followObject.transform.position + orbit * followDistance;
	}

	void LateUpdate ()
	{
		Vector3 velocity = Vector3.zero;
		Vector3 newPosition = followObject.transform.position + orbit * followDistance;
		this.transform.position = newPosition;
	}
}
