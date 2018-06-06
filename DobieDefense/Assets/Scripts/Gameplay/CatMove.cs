using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour 
{
	[Range(0, 10)]
	public float MoveSpeed;

	void Update () 
	{
		this.transform.Translate (0, -MoveSpeed * Time.deltaTime, 0);
	}
}
