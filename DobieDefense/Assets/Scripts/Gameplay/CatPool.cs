using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPool : MonoBehaviour 
{
	public GlobalVariables Global;
	public GameObject Cat;
	public Transform AboveButtons;

	public int PooledCats;
	List<GameObject> ListOfCats;

	void Start () 
	{
		Global = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		ListOfCats = new List<GameObject> ();
		for (int i = 0; i < PooledCats; i++) 
		{
			GameObject obj = (GameObject)Instantiate (Cat);
			obj.SetActive (false);
			ListOfCats.Add (obj);
		}
	}

	void Update ()
	{
		for (int i = 0; i < ListOfCats.Count; i++) 
		{
			if (!ListOfCats [i].activeInHierarchy) 
			{
				ListOfCats [i].transform.position = transform.position;
				ListOfCats [i].transform.rotation = transform.rotation;
				ListOfCats [i].SetActive (true);
				break;
			}
		}
	}
}
