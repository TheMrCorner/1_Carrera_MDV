using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	int movcont = 1;   //Cuenta la posicion en la que nos encontramos
	float camareroposy;
	public GameObject posicion1;
	public GameObject posicion2;
	public GameObject posicion3;
	public GameObject posicion4;
	public GameObject beerDis;
	public GameObject mano;

	//Start is called
	void Start(){
		transform.position = posicion1.transform.position;
	}

	// Update is called once per frame
	void Update () {
		//Movimiento del jugador
		if (Input.GetKeyDown (KeyCode.UpArrow) && movcont >= 1 && movcont < 4) { //Movimiento normal
			movcont++;
			Debug.Log (movcont);
		} 
		else if (Input.GetKeyDown (KeyCode.DownArrow) && movcont > 1 && movcont <= 4) {
			movcont--;
			Debug.Log (movcont);
		} 
		else if (movcont == 4 && Input.GetKeyDown (KeyCode.UpArrow)) {//movimiento para pasar de pos4 a pos1
			movcont = 1;
		}
		else if (movcont == 1 && Input.GetKeyDown (KeyCode.DownArrow)) {//movimiento para pasar de pos1 a pos4
			movcont = 4;
		}
		if (movcont == 1)
			transform.position = posicion1.transform.position;
		else if (movcont == 2)
			transform.position = posicion2.transform.position;
		else if (movcont == 3)
			transform.position = posicion3.transform.position;
		else if (movcont == 4)
			transform.position = posicion4.transform.position;

		//Disparo
		if (Input.GetKeyDown (KeyCode.Space)){
			Debug.Log ("Espacio Pulsado");
			Disparador ();
		}
	}

	//Disparo
	void Disparador ()
	{
		GameObject disparador = Instantiate (beerDis);
		disparador.transform.position = mano.transform.position;
		beerDis.transform.position = disparador.transform.position;
	}
}