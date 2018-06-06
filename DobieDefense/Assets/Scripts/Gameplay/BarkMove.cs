using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkMove : MonoBehaviour 
{
	[Range(-10, 10)]
	public float BarkSpeed;

	void Update () 
	{
		this.transform.Translate (BarkSpeed * Time.deltaTime, 0, 0);
	}
}
