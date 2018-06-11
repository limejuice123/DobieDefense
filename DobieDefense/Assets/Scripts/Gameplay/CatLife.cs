using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLife : MonoBehaviour 
{
	public Transform Barricade;
	public int CatHealth;
	public GlobalVariables Global;

	public AudioSource source;

	void Start () 
	{
		Global = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		Barricade = GameObject.Find ("barricade").GetComponent<Transform> ();
		source = Camera.main.GetComponent<AudioSource> ();
		source.clip = Resources.Load ("Hit") as AudioClip;
		source.volume = 0.3f;
		CatHealth = 5;
	}

	void Update () 
	{
		if (this.transform.position.y <= Barricade.position.y) 
		{
			Global.Health = Global.Health - 5;
			Destroy (this.gameObject);
		}

		if (CatHealth <= 0) 
		{
			Global.Treats = Global.Treats + 3;
			source.Play ();
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.rigidbody.tag == "Bark") 
		{
			CatHealth--;
		}

		if (other.rigidbody.tag == "Laser") 
		{
			Global.Treats = Global.Treats + 3;
			Destroy (this.gameObject);
		}
	}
}
