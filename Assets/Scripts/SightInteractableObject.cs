using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SightInteractableObject : MonoBehaviour, ISightInteraction
{
	public float interactionSightTime;

	public UnityEvent OnInteraction;

	public bool onlyOneActivationPerSight = true;

	private float sightTime = 0f;

	private bool activated;

	void Awake ()
	{
		sightTime = 0f;
		activated = false;
	}

	public void OnSightStart ()
	{
		sightTime = 0f;
	}

	public void OnSightStay ()
	{
		sightTime += Time.deltaTime;
		if (sightTime > interactionSightTime) {
			if ((onlyOneActivationPerSight && !activated) || !onlyOneActivationPerSight) {
				sightTime = 0f;
				activated = true;
				if (OnInteraction != null)
					OnInteraction.Invoke ();
			}
		}
	}

	public void OnSightEnd ()
	{
		sightTime = 0f;
	}


}
