using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkPool : MonoBehaviour 
{
	public GlobalVariables Global;

	public GameObject Bark;
	[Range(0, 10)]
	public float BarkSpeed;

	public Transform AboveButtons;
	public Transform BarkBoundaryRight;
	public Transform BarkBoundaryLeft;

	public int PooledBarks;
	public bool canFire;
	public bool isCoroutineStarted;
	List<GameObject> ListOfBarks;

	public AudioSource source;

	void Start () 
	{
		source = GameObject.Find ("Sasha").GetComponent<AudioSource> ();
		source.clip = Resources.Load ("Bork") as AudioClip;
		canFire = true;
		Global = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		ListOfBarks = new List<GameObject> ();
		for (int i = 0; i < PooledBarks; i++) 
		{
			GameObject obj = (GameObject)Instantiate (Bark);
			obj.SetActive (false);
			ListOfBarks.Add (obj);
		}
	}

	void Update ()
	{
		if (Input.touchCount == 1 && Global.LaserEyesPurchased == false && canFire == true) 
		{
			var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

			if (pos.y < AboveButtons.position.y && pos.x > BarkBoundaryLeft.position.x && pos.x < BarkBoundaryRight.position.x) 
			{
				for (int i = 0; i < ListOfBarks.Count; i++) 
				{
					if (!ListOfBarks [i].activeInHierarchy) 
					{
						ListOfBarks [i].transform.position = transform.position;
						ListOfBarks [i].transform.rotation = transform.rotation;
						ListOfBarks [i].SetActive (true);
						source.Play ();
						canFire = false;
						break;
					}
				}
			}
		}

		if (Input.GetKey ("space") && Global.LaserEyesPurchased == false && canFire == true) 
		{
			for (int i = 0; i < ListOfBarks.Count; i++) 
			{
				if (!ListOfBarks [i].activeInHierarchy) 
				{
					ListOfBarks [i].transform.position = transform.position;
					ListOfBarks [i].transform.rotation = transform.rotation;
					ListOfBarks [i].SetActive (true);
					source.Play ();
					canFire = false;
					break;
				}
			}
		}

		if (canFire == false && isCoroutineStarted == false) 
		{
			StartCoroutine (ResetFire ());
			isCoroutineStarted = true;
		}
	}

	IEnumerator ResetFire()
	{
		yield return new WaitForSeconds (0.25f);
		canFire = true;
		isCoroutineStarted = false;
	}
}
