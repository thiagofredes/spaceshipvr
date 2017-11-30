
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	private GameObject playerObject;

	public GameObject turretHead;

	public GameObject turretBase;

	public Transform[] shotOrigin;

	public float timeBeweenShots = 1f;

	public GameObject bulletPrefab;

	public Vector3 rotationAdjust;

	public float rotationSpeed = 10f;

	private Vector3 playerVector;

	private float nextShot;

	void Awake ()
	{
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		nextShot = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerVector = playerObject.transform.position - this.transform.position;
		Point ();
		if (playerVector.magnitude < 50f && Time.time >= nextShot) {
			Shoot ();
			nextShot = Time.time + timeBeweenShots;
		}
	}

	private void Point ()
	{
		Vector3 baseForward = playerVector;
		baseForward.y = 0;
		turretBase.transform.rotation = Quaternion.Slerp (turretBase.transform.rotation, Quaternion.LookRotation (baseForward.normalized) * Quaternion.Euler (rotationAdjust.x, rotationAdjust.y, rotationAdjust.z), Time.deltaTime * rotationSpeed);
		turretHead.transform.localRotation = Quaternion.Euler (Vector3.Angle (baseForward, playerVector), 0f, 0f);
	}

	private void Shoot ()
	{
		for (int s = 0; s < shotOrigin.Length; s++)
			Instantiate (bulletPrefab, shotOrigin [s].position, shotOrigin [s].rotation);
	}
}
