using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepDisplay : MonoBehaviour 
{
	public Text TreatsAmount;
	public Text HealthAmount;
	public GlobalVariables globalvariables;

	void Start () 
	{
		globalvariables = GameObject.Find ("GlobalVariables").GetComponent<GlobalVariables> ();
		TreatsAmount = GameObject.Find ("TreatsText").GetComponent<Text> ();
		HealthAmount = GameObject.Find ("HealthText").GetComponent<Text> ();
	}

	void Update () 
	{
		TreatsAmount.text = "= " + globalvariables.Treats.ToString ();
		HealthAmount.text = "= " + globalvariables.Health.ToString ();
	}
}
