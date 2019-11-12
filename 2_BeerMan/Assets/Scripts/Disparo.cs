using UnityEngine;
using System.Collections;

public class Disparo : MonoBehaviour {
	public GameObject cerveza;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)){
			Debug.Log ("Espacio Pulsado");
			GameObject Disparador = Instantiate (cerveza);
			cerveza.transform.position = transform.position;
		}
	}
}
