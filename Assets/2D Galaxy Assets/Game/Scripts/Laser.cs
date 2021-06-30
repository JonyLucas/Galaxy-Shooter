using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	[SerializeField]
	private float speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * speed * Time.deltaTime);

		if (transform.position.y > 5.5) {
			destroyLaser();
		}

	}

	public void destroyLaser() {
		if (transform.parent != null) {
			Debug.Log(transform.parent.childCount);
			if(transform.parent.childCount == 1)
				Destroy(transform.parent.gameObject);
		}

		Destroy(this.gameObject);
	}

}
