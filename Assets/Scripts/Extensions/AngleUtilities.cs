using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleUtilities : MonoBehaviour
{

	public static float ClampRangeSymDeg (float value, float limit)
	{
		if (value > limit) {
			return value - 360f;
		}
		return value;
	}
}
