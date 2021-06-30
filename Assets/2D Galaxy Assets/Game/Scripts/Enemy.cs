using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private GameObject explosionAnimation;

	[SerializeField]
	private GameObject[] enginesFailure;

	[SerializeField]
	private float speed = 5.5f;

	[SerializeField]
	private int life = 100;

	private int hitCount = 0;
	private UIManager uiManager;

	void Start() {
		uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}

	void Update () {
		if (uiManager.isTitleScreenDisplayed())
			Destroy(this.gameObject);

		moviment();
	}

	private void moviment() {
		transform.Translate(Vector3.down * speed * Time.deltaTime);
		if (transform.position.y < -6.3) {
			float newXPosition = Random.Range(-8.0f, 8.0f);
			transform.position = new Vector3(newXPosition, 6.4f, 0);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
			Player player = collision.GetComponent<Player>();
			if (player != null) {
				player.Damage();
			}

			life = life - 100;
		}else if (collision.tag == "Shot") {
			Laser laser = collision.GetComponent<Laser>();
			if (laser != null)
				laser.destroyLaser();

			enginesFailure[hitCount++].SetActive(true);
			uiManager.updateScore();
			life = life - 20;
		}

		if (life <= 0) {
			Instantiate(explosionAnimation, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
	
}
