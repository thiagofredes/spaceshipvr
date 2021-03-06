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

	private static ThirdPersonCameraFollower _instance;

	void Awake ()
	{
		_instance = this;
		this.transform.position = followObject.transform.position - followObject.transform.forward * followDistance;
	}

	void LateUpdate ()
	{
		this.transform.position = followObject.transform.position - followObject.transform.forward * followDistance;
	}
}
