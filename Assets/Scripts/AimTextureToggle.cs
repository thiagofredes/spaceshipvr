using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AimTextureToggle : MonoBehaviour
{

	public enum AimType
	{
		NORMAL,
		ATTACK
	}

	[Serializable]
	public class AimTexture
	{
		public AimType type;
		public Texture texture;
	}

	public AimTexture[] textures;

	private Material aimTexture;


	void Awake ()
	{
		aimTexture = GetComponent<Renderer> ().material;
	}

	public void SetType (AimType type)
	{
		int index = GetIndexOf (type);
		if (index != -1) {
			aimTexture.mainTexture = textures [index].texture;
		}
	}

	private int GetIndexOf (AimType type)
	{
		for (int i = 0; i < textures.Length; i++) {
			if (textures [i].type == type) {
				return i;
			}
		}
		return -1;
	}
}
