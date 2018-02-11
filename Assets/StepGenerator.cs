using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepGenerator : MonoBehaviour {
	Text stepDisplay;
	// Use this for initialization
	void Awake(){
		HealthKit.Instance ().Initialize ();
	}
	void Start () {
		int steps = HealthKit.Instance().GetYesterdaysSteps();

        stepDisplay = gameObject.GetComponent<Text>(); 
//		int stepCount = UnityEngine.Random.Range(1,20000);
		stepDisplay.text = steps.ToString();
		saveSteps (steps);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void saveSteps(int stepCount) { 
		PlayerPrefs.SetInt("Steps",stepCount); 
	} 

}
