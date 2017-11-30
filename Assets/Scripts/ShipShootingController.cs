using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingController : MonoBehaviour
{

	public GameObject shotingPrefab;

	public Transform shotOrigin;

	public float baseAimDistance = 20f;

	public AimTextureToggle aimSpriteToggle;

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
			aimSpriteToggle.gameObject.transform.position = hit.point + hit.normal * 0.15f;
			aimSpriteToggle.gameObject.transform.forward = -hit.normal;
			if (interactableObject != null) {				
				aimSpriteToggle.SetType (AimTextureToggle.AimType.ATTACK);
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
				aimSpriteToggle.SetType (AimTextureToggle.AimType.NORMAL);
			}
		} else {
			aimSpriteToggle.gameObject.transform.position = shotOrigin.transform.position + shotOrigin.transform.forward * baseAimDistance;
			aimSpriteToggle.gameObject.transform.forward = shotOrigin.transform.forward;
			currentObject = null;
			aimSpriteToggle.SetType (AimTextureToggle.AimType.NORMAL);
		}
	}
}
