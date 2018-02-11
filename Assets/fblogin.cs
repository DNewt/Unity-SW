using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //This allows the IComparable Interface
// Include Facebook namespace
using Facebook.Unity;
using UnityEngine.SceneManagement;
public class fblogin : MonoBehaviour {
	string userID;
	List<string> perms = new List<string>(){"email"};

	public void buttonClick(){
		FB.LogInWithReadPermissions(perms, AuthCallback);
	}
		
	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			PlayerPrefs.SetString("userID",aToken.UserId); 
			PlayerPrefs.SetString ("userToken", aToken.TokenString);
			Debug.Log (aToken.TokenString);
			SceneManager.LoadScene("Main");
		} else {
			Debug.Log("User cancelled login");
		}
	}
		
}
	
