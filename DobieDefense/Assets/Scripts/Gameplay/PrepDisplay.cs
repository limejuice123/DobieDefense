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

	void Start () 
	{
		globalvariables = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		prepimagecycle = GameObject.Find ("ThingToBuy").GetComponent<PrepImageCycle> ();
		TreatsAmount = GameObject.Find ("TreatsText").GetComponent<Text> ();
		HealthAmount = GameObject.Find ("HealthText").GetComponent<Text> ();
		Description = GameObject.Find ("Description").GetComponent<Text> ();
	}

	void Update () 
	{
		TreatsAmount.text = "= " + globalvariables.Treats.ToString ();
		HealthAmount.text = "= " + globalvariables.Health.ToString ();

		switch (prepimagecycle.CycleNumber) 
		{
		case 0:
			Description.text = "A fart with a stink equivalent to a chemical weapon. Single-use, destroys all enemies on screen";
			break;
		case 1:
			Description.text = "Projectile vomit, can be launched over a large area to wipe out multiple foes";
			break;
		case 2:
			Description.text = "I'MA FIRING MY LAZAR! Upgrades Sasha's barking to LASER EYES for increased range and fire rate";
			break;
		case 3:
			Description.text = "Refills your health";
			break;
		}
	}
}
