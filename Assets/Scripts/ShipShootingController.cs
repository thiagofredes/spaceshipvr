using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingController : MonoBehaviour
{

	public GameObject shotingPrefab;

	public Transform shotOrigin;

	public GameObject aimSprite;

	public float baseAimDistance = 20f;

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

		if (Physics.Raycast (shotOrigin.transform.position, shotOrigin.transform.forward, out hit, baseAimDistance, ~LayerMask.GetMask ("Player", "PlayerBullet"))) {
			ISightInteraction interactableObject = hit.collider.GetComponent<ISightInteraction> ();
			aimSprite.transform.position = hit.point + hit.normal * 0.15f;
			aimSprite.transform.forward = hit.normal;
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
			aimSprite.transform.position = shotOrigin.transform.position + shotOrigin.transform.forward * baseAimDistance;
			aimSprite.transform.forward = -shotOrigin.transform.forward;
			currentObject = null;
		}
	}
}
