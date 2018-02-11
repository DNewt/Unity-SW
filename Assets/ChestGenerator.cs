using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class ChestGenerator : MonoBehaviour {
	
	private const string URL = "https://frisp-game-api.herokuapp.com/chests";

	private string API_KEY;
	Text chestDisplay;

	public Text responseText;

	void Start () {
		chestDisplay = gameObject.GetComponent<Text>(); 
		WWW www;
		API_KEY = PlayerPrefs.GetString("userToken", "Failed");

		Dictionary<string,string> headers = new Dictionary<string,string> ();
		headers.Add("Content-Type", "application/json");
		headers.Add ("Authorization", API_KEY);

		var jsonStr = "{\"steps\": 10000}";
		var formData = System.Text.Encoding.UTF8.GetBytes(jsonStr);

		www = new WWW(URL, formData, headers);
		StartCoroutine(OnResponse(www));
	}

	private IEnumerator OnResponse(WWW data){

		yield return data; // Wait until the download is done
		if (data.error != null)
		{
			Debug.Log("There was an error sending request: " + data.error);
		}
		else
		{
			
			var chesty = JsonUtility.FromJson<Chest>(data.text);
			chestDisplay.text = chesty.chestCount.ToString();
			Debug.Log (chesty.chestCount);
			Debug.Log (chesty.lastFetchedChestsAt);
			Debug.Log("WWW Request: " + data.text);
		}
	}


	void Update () {
	}
}

[Serializable]
public class Chest {

	public int chestCount;
	public DateTime lastFetchedChestsAt; 

}
