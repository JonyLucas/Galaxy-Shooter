using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[SerializeField]
	private GameObject enemyShip;

	[SerializeField]
	private GameObject[] powerups;

	private UIManager uiManager;

	// Use this for initialization
	void Start () {
		uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
		StartCoroutine(spawnEnemy());
		StartCoroutine(spawnPowerup());
	}

	private IEnumerator spawnEnemy() {
		while (true) {
			if (uiManager.isTitleScreenDisplayed() == false) {
				float xPosition = Random.Range(-8.0f, 8.0f);
				Instantiate(enemyShip, new Vector3(xPosition, 6.4f, 0), Quaternion.identity);
			}
			yield return new WaitForSeconds(3);
		}	
	}

	private IEnumerator spawnPowerup() {

		while (true) {
			if (uiManager.isTitleScreenDisplayed() == false) {
				float xPosition = Random.Range(-8.0f, 8.0f);
				int powerupType = Random.Range(0, 3);
				Instantiate(powerups[powerupType], new Vector3(xPosition, 6.4f, 0), Quaternion.identity);
			}
			yield return new WaitForSeconds(10);
		}
	}

}
