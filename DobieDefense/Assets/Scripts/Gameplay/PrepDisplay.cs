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
	public Image AlreadyPurchased;

	public AudioSource source;
	public AudioClip clip;

	void Start () 
	{
		globalvariables = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		prepimagecycle = GameObject.Find ("ThingToBuy").GetComponent<PrepImageCycle> ();
		TreatsAmount = GameObject.Find ("TreatsText").GetComponent<Text> ();
		HealthAmount = GameObject.Find ("HealthText").GetComponent<Text> ();
		Description = GameObject.Find ("Description").GetComponent<Text> ();
		Cost = GameObject.Find ("Cost").GetComponent<Text> ();
		BuyButton = GameObject.Find ("BuyButton").GetComponent<Button> ();
		AlreadyPurchased = GameObject.Find ("AlreadyPurchased").GetComponent<Image> ();
		source = Camera.main.GetComponent<AudioSource> ();
		source.clip = clip;

		BuyButton.onClick.AddListener (TaskOnClick);
		AlreadyPurchased.enabled = false;
	}

	void Update () 
	{
		TreatsAmount.text = "= " + globalvariables.Treats.ToString ();
		HealthAmount.text = "= " + globalvariables.Health.ToString ();

		switch (prepimagecycle.CycleNumber) 
		{
		case 0:
			if (globalvariables.FartPurchased == true)
				AlreadyPurchased.enabled = true;
			else
				AlreadyPurchased.enabled = false;

			Description.text = "A fart with a stink equivalent to a chemical weapon. Single-use, destroys all enemies on screen.";
			Cost.text = "Cost = 100";
			break;
		case 1:
			if (globalvariables.LaserEyesPurchased == true)
				AlreadyPurchased.enabled = true;
			else
				AlreadyPurchased.enabled = false;

			Description.text = "I'MA FIRING MY LAZAR! Upgrades Sasha's barking to LASER EYES for increased damage.";
			Cost.text = "Cost = 500";
			break;
		case 2:
			if (globalvariables.Health < 100)
				AlreadyPurchased.enabled = true;
			else
				AlreadyPurchased.enabled = false;

			Description.text = "Refills your health";
			Cost.text = "Cost = 50";
			break;
		}
	}

	void TaskOnClick()
	{
		Debug.Log ("Buying a thing");

		if (prepimagecycle.CycleNumber == 0 && globalvariables.Treats >= 100 && globalvariables.FartPurchased == false) 
		{
			source.Play ();
			globalvariables.FartPurchased = true;
			globalvariables.Treats = globalvariables.Treats - 100;
		}
			
		if (prepimagecycle.CycleNumber == 1 && globalvariables.Treats >= 500 && globalvariables.LaserEyesPurchased == false) 
		{
			source.Play ();
			globalvariables.LaserEyesPurchased = true;
			globalvariables.Treats = globalvariables.Treats - 500;
		}

		if (prepimagecycle.CycleNumber == 2 && globalvariables.Treats >= 50 && globalvariables.Health < 100) 
		{
			source.Play ();
			globalvariables.Health = 100;
			globalvariables.Treats = globalvariables.Treats - 50;
		}
	}
}
