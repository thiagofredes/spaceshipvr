using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingController : MonoBehaviour
{

	public GameObject shotingPrefab;

	public Transform shotOrigin;

	private ISightInteraction currentObject;


	void Awake ()
	{
		currentObject = null;
	}

	public void Shoot ()
	{
		GameObject.Instantiate (shotingPrefab, shotOrigin.position, shotOrigin.rotation);
	}

	void Update ()
	{
		RaycastHit hit;

		if (Physics.Raycast (shotOrigin.transform.position, shotOrigin.transform.forward, out hit, Mathf.Infinity, ~LayerMask.GetMask ("Player", "PlayerBullet"))) {
			ISightInteraction interactableObject = hit.collider.GetComponent<ISightInteraction> ();
			if (interactableObject != null) {				
				if (currentObject == null) {
					currentObject = interactableObject;
					currentObject.OnSightStart ();
				} else if (currentObject != null) {
					if (currentObject.Equals (interactableObject)) {
						currentObject.OnSightStay ();
					} else {
						currentObject.OnSightEnd ();
						currentObject = interactableObject;
						currentObject.OnSightStart ();
					}
				}				
			} else {
				currentObject = null;
			}
		} else {
			currentObject = null;
		}
	}
}
