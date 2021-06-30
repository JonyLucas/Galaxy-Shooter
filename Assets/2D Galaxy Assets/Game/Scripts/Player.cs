using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private GameObject 
		laserPrefab, 
		tripleShotPrefab,
		explosionPrefab,
		shieldGameObject;

	[SerializeField]
	private GameObject[] engines;

	private UIManager uiManager;

	private AudioSource audioSource;

	[SerializeField]
	private int lives = 3;

	[SerializeField]
	private float
		speed = 5.0f,
		fireRate = 0.25f;

	private float nextFire = 0.0f;

	[SerializeField]
	private bool
		tripleShotEnabled = false;

	// Use this for initialization
	void Start () {
		Debug.Log("The game is about to start");

		uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

		if (uiManager != null) {
			uiManager.updateLives(lives);
		}

		audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		Moviment();
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) 
			Shoot();
		
	}

	private void Shoot() {
		if (Time.time > nextFire) {
			audioSource.Play();
			if (tripleShotEnabled) {
				Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
			} else {
				Instantiate(laserPrefab, transform.position + new Vector3(0, 0.99f, 0), Quaternion.identity);
			}
			nextFire = Time.time + fireRate;
		}
	}

	public void StartPoweUp(string powerName) {
		switch (powerName) {
			case "TripleShot":
				tripleShotEnabled = true;
				break;
			case "SpeedBoost":
				speed = speed * 2.5f;
				break;
			case "Shield":
				shieldGameObject.SetActive(true);
				break;
		}

		StartCoroutine(PowerUpTimer(powerName));
	}
	
	private IEnumerator PowerUpTimer(string power) {
		yield return new WaitForSeconds(5.0f);

		switch (power) {
			case "TripleShot":
				tripleShotEnabled = false;
				break;
			case "SpeedBoost":
				speed = speed / 2.5f;
				break;
			case "Shield":
				shieldGameObject.SetActive(false);
				break;
		}

	}

	private void Moviment() {
		float xPosition = transform.position.x, yPosition = transform.position.y;

		transform.Translate(Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));

		if (xPosition > 9.5)
			transform.position = new Vector3(-9.5f, yPosition, 0);
		else if (xPosition < -9.5)
			transform.position = new Vector3(9.5f, yPosition, 0);

		transform.Translate(Vector3.up * speed * Time.deltaTime * Input.GetAxis("Vertical"));

		if (yPosition > 4.2)
			transform.position = new Vector3(xPosition, 4.2f, 0);
		else if (yPosition < -4.2)
			transform.position = new Vector3(xPosition, -4.2f, 0);
	}

	public void Damage() {
		if (shieldGameObject.active == false) {
			uiManager.updateLives(--lives);
		}

		if (lives == 2) {
			engines[0].SetActive(true);
		} else if (lives == 1) {
			engines[1].SetActive(true);
		}

		if (lives == 0) {
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			uiManager.showTitleScreen();
			Destroy(this.gameObject);
		}
	}

}
