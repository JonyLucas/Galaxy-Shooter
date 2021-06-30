using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	[SerializeField]
	private float speed = 3.0f;

	[SerializeField]
	private string powerType;

	[SerializeField]
	private GameObject explosionAnimation;

	[SerializeField]
	private AudioClip audioClip;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * Time.deltaTime * speed);
		if (transform.position.y < -5.3f) {
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Player") {
			Player player = collision.GetComponent<Player>();
			if(player != null) {
				player.StartPoweUp(powerType);
				AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
			}
		}else if (collision.tag == "Shot") {
			Debug.Log("Destroy Laser");
			Destroy(collision.gameObject);
			Instantiate(explosionAnimation, transform.position, Quaternion.identity);
		}

		Destroy(this.gameObject);
	}
}
