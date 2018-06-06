using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawn : MonoBehaviour 
{
	public GameObject CatToSpawn;
	public GlobalVariables Global;
	public float SpawnTime;

	void Start () 
	{
		CatToSpawn = Resources.Load ("Cat") as GameObject;
		Global = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();

		if (Global.CurrentLevel < 3)
			SpawnTime = 0.6f;

		if (Global.CurrentLevel >= 3 && Global.CurrentLevel < 6)
			SpawnTime = 0.5f;

		if (Global.CurrentLevel >= 6 && Global.CurrentLevel < 9)
			SpawnTime = 0.4f;

		if (Global.CurrentLevel >= 9 && Global.CurrentLevel < 12)
			SpawnTime = 0.3f;

		if (Global.CurrentLevel >= 12 && Global.CurrentLevel < 15)
			SpawnTime = 0.2f;

		if (Global.CurrentLevel >= 15)
			SpawnTime = 0.1f;

		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn()
	{
		while (true) 
		{
			yield return new WaitForSeconds (SpawnTime);
			Instantiate(CatToSpawn, new Vector2 (Random.Range (-1.7f, 2.3f), 4.7f), Quaternion.Euler(0, 0, 0));
		}

	}
}
