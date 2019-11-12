using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	public string tagC;
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == tagC) {
			Destroy (other.gameObject);
			GameManager.instance.QuitaVidas ();
		} 
	}
}
