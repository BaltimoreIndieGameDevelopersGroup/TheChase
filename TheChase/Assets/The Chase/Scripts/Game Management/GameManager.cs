using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject gameOverObject;
	
	private static GameManager instance;
	
	void Awake() {
		instance = this;
		if (gameOverObject != null) gameOverObject.SetActive(false);
	}
	
	void InstanceGameOver() {
		if (gameOverObject != null) gameOverObject.SetActive(true);
		Time.timeScale = 0;
	}
	
	public static void GameOver() {
		instance.InstanceGameOver();
	}
	
}
