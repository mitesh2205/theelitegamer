using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LevelOverScreenScript : MonoBehaviour
{
   public Button RestartButton;

	void Start () {
		Button btn = RestartButton.GetComponent<Button>();
		btn.onClick.AddListener(RestartLevel);
	}

	void RestartLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
