using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepDisplay : MonoBehaviour 
{
	public Text TreatsAmount;
	public Text HealthAmount;
	public Text Description;
	public Text Cost;
	public GlobalVariables globalvariables;
	public PrepImageCycle prepimagecycle;
	public Button BuyButton;

	void Start () 
	{
		globalvariables = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		prepimagecycle = GameObject.Find ("ThingToBuy").GetComponent<PrepImageCycle> ();
		TreatsAmount = GameObject.Find ("TreatsText").GetComponent<Text> ();
		HealthAmount = GameObject.Find ("HealthText").GetComponent<Text> ();
		Description = GameObject.Find ("Description").GetComponent<Text> ();
		Cost = GameObject.Find ("Cost").GetComponent<Text> ();
		BuyButton = GameObject.Find ("BuyButton").GetComponent<Button> ();

		BuyButton.onClick.AddListener (TaskOnClick);
	}

	void Update () 
	{
		TreatsAmount.text = "= " + globalvariables.Treats.ToString ();
		HealthAmount.text = "= " + globalvariables.Health.ToString ();

		switch (prepimagecycle.CycleNumber) 
		{
		case 0:
			Description.text = "A fart with a stink equivalent to a chemical weapon. Single-use, destroys all enemies on screen.";
			Cost.text = "Cost = 100";
			break;
		case 1:
			Description.text = "I'MA FIRING MY LAZAR! Upgrades Sasha's barking to LASER EYES for increased damage.";
			Cost.text = "Cost = 500";
			break;
		case 2:
			Description.text = "Refills your health";
			Cost.text = "Cost = 50";
			break;
		}
	}

	void TaskOnClick()
	{
		Debug.Log ("Buying a thing");

		if (prepimagecycle.CycleNumber == 0 && globalvariables.Treats > 100) 
		{
			globalvariables.FartPurchased = true;
			globalvariables.Treats = globalvariables.Treats - 100;
		}
			
		if (prepimagecycle.CycleNumber == 1 && globalvariables.Treats > 500) 
		{
			globalvariables.LaserEyesPurchased = true;
			globalvariables.Treats = globalvariables.Treats - 500;
		}

		if (prepimagecycle.CycleNumber == 2 && globalvariables.Treats > 50) 
		{
			globalvariables.Health = 100;
			globalvariables.Treats = globalvariables.Treats - 50;
		}
	}
}
