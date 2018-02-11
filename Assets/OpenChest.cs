using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class OpenChest : MonoBehaviour {

	private const string URL = "https://frisp-game-api.herokuapp.com/chest_items";
	private string API_KEY;
	public Text equipmentDisplay;
	public Text materialDisplay;
	public Text planDisplay;
	public Text chestDisplay;

	void Start () {
		
	}

	public void OpenChestMethodHehe(){
		WWW www;
		API_KEY = PlayerPrefs.GetString("userToken", "Failed");

		Dictionary<string,string> headers = new Dictionary<string,string> ();
		headers.Add("Content-Type", "application/json");
		headers.Add ("Authorization", API_KEY);

		var jsonStr = "{}";
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
			Debug.Log("WWW Request: " + data.text);
			int chestCount = Int32.Parse(chestDisplay.text);
			Debug.Log (chestCount);
			chestDisplay.text = chestCount.ToString ();

			var itemList = JsonUtility.FromJson<Inventory>(data.text);
			Debug.Log (itemList.chestCount);

			string equipmentString = "";
			string materialString = "";
			string planString = "";
			for (int i = 0; i < itemList.equipment.Length; i++) {
				if (itemList.equipment [i].rarity.ToString () == "rare") {
					equipmentString = equipmentString + " " + "<color=green>" + itemList.equipment [i].name.ToString() + "</color>" + "\n";
				}
				if (itemList.equipment [i].rarity.ToString () == "common") {
					equipmentString = equipmentString + " " + "<color=white>" + itemList.equipment [i].name.ToString () + "</color>" + "\n";
				}
				if (itemList.equipment [i].rarity.ToString () == "super") {
					equipmentString = equipmentString + " " + "<color=blue>" + itemList.equipment [i].name.ToString () + "</color>" + "\n";
				}
				if (itemList.equipment [i].rarity.ToString () == "ultra") {
					equipmentString = equipmentString + " " + "<color=pink>" + itemList.equipment [i].name.ToString () + "</color>" + "\n";
				}
				if (itemList.equipment [i].rarity.ToString () == "ancient") {
					equipmentString = equipmentString + " " + "<color=yellow>" + itemList.equipment [i].name.ToString () + "</color>" + "\n";
				}

			}

			for (int i = 0; i < itemList.materials.Length; i++) {
				if (itemList.materials [i].rarity.ToString () == "rare") {
					materialString = materialString + " " + "<color=green>" + itemList.materials [i].name.ToString() + "</color>" + "\n";
				}
				if (itemList.materials [i].rarity.ToString () == "common") {
					materialString = materialString + " " + "<color=white>" + itemList.materials [i].name.ToString () + "</color>" + "\n";
				}
				if (itemList.materials [i].rarity.ToString () == "super") {
					materialString = materialString + " " + "<color=blue>" + itemList.materials [i].name.ToString () + "</color>" + "\n";
				}
				if (itemList.materials [i].rarity.ToString () == "ultra") {
					materialString = materialString + " " + "<color=pink>" + itemList.materials [i].name.ToString () + "</color>" + "\n";
				}
				if (itemList.materials [i].rarity.ToString () == "ancient") {
					materialString = materialString + " " + "<color=yellow>" + itemList.materials [i].name.ToString () + "</color>" + "\n";
				}
			}

			for (int i = 0; i < itemList.plans.Length; i++) {
				planString = planString + " " + itemList.plans [i].name.ToString();
			}
				
			equipmentDisplay.text = equipmentString;
			materialDisplay.text = materialString;
			planDisplay.text = planString;

		}
	}
		

	void Update () {
	}
}

[Serializable]
public class Inventory {

	public long chestCount;
	public UserEquipment[] equipment;
	public UserMaterial[] materials;
	public UserPlan[] plans;

}

[Serializable]
public class UserEquipment {
	public string name;
	public string rarity;
	public UserEquipmentAttribute[] attributes;
}

[Serializable]
public class UserMaterial {
	public string name;
	public string rarity;
}

[Serializable]
public class UserPlan {
	public string name;
	public string rarity;
}

[Serializable]
public class UserEquipmentAttribute {
	public string type;
	public int value;
}