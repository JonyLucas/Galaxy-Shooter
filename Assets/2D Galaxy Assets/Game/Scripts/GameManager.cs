using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	private UIManager uiManager;
	private SpawnManager spawnManager;

	[SerializeField]
	private GameObject player;

	// Use this for initialization
	void Start () {
		uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
		spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (uiManager.isTitleScreenDisplayed()) {
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
				uiManager.hideTitleScreen();
				Instantiate(player, Vector3.zero, Quaternion.identity);
			}
		}
	}
}
