using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepDisplay : MonoBehaviour 
{
	public Text TreatsAmount;
	public Text HealthAmount;
	public Text Description;
	public GlobalVariables globalvariables;
	public PrepImageCycle prepimagecycle;

	public Transform RightTag;
	public Transform LeftTag;
	public Transform UpTag;
	public Transform DownTag;

	void Start () 
	{
		globalvariables = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		prepimagecycle = GameObject.Find ("ThingToBuy").GetComponent<PrepImageCycle> ();
		TreatsAmount = GameObject.Find ("TreatsText").GetComponent<Text> ();
		HealthAmount = GameObject.Find ("HealthText").GetComponent<Text> ();
		Description = GameObject.Find ("Description").GetComponent<Text> ();
		RightTag = GameObject.Find ("LeftTag").GetComponent<Transform> ();
		LeftTag = GameObject.Find ("RightTag").GetComponent<Transform> ();
		UpTag = GameObject.Find ("UpTag").GetComponent<Transform> ();
		DownTag = GameObject.Find ("DownTag").GetComponent<Transform> ();
	}

	void Update () 
	{
		TreatsAmount.text = "= " + globalvariables.Treats.ToString ();
		HealthAmount.text = "= " + globalvariables.Health.ToString ();

		switch (prepimagecycle.CycleNumber) 
		{
		case 0:
			Description.text = "A fart with a stink equivalent to a chemical weapon. Single-use, destroys all enemies on screen.";
			break;
		case 1:
			Description.text = "Projectile vomit, can be launched over a large area to wipe out multiple foes.";
			break;
		case 2:
			Description.text = "I'MA FIRING MY LAZAR! Upgrades Sasha's barking to LASER EYES for increased damage.";
			break;
		case 3:
			Description.text = "Refills your health";
			break;
		}

		if (Input.touchCount == 1) 
		{
			var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

			if (pos.x > LeftTag.position.x && pos.x < RightTag.position.x && pos.y > DownTag.position.y && pos.y < UpTag.position.y) 
			{
				if (prepimagecycle.CycleNumber == 0 && globalvariables.Treats > 100) 
				{
					globalvariables.FartPurchased = true;
					globalvariables.Treats = globalvariables.Treats - 100;
				}

				if (prepimagecycle.CycleNumber == 1 && globalvariables.Treats > 250) 
				{
					globalvariables.VomitPurchased = true;
					globalvariables.Treats = globalvariables.Treats - 250;
				}

				if (prepimagecycle.CycleNumber == 2 && globalvariables.Treats > 500) 
				{
					globalvariables.LaserEyesPurchased = true;
					globalvariables.Treats = globalvariables.Treats - 500;
				}

				if (prepimagecycle.CycleNumber == 3 && globalvariables.Treats > 50) 
				{
					globalvariables.Health = 100;
					globalvariables.Treats = globalvariables.Treats - 50;
				}
			}
		}
	}
}
