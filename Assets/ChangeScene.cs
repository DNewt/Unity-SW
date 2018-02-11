using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	public void toChests() {
			SceneManager.LoadScene("Chests");
	}
	public void toInventory() {
		SceneManager.LoadScene("Inventory");
	}
	public void toQuests() {
		SceneManager.LoadScene("Quests");
	}
	public void toMain() {
		SceneManager.LoadScene("Main");
	}
}

