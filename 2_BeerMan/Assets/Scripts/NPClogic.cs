using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HorizMove))]

public class NPClogic : MonoBehaviour {
	//bool esperandoCerveza = true;
	public GameObject jarraVacía;
    HorizMove movHoriz;
	float velXorig; //Variable que almacena la veloc inic/Variable que almacena la veloc actual
	public string tagC;
	bool waitBeer = true;

    void Start()
    {
		movHoriz = GetComponent <HorizMove> ();
		velXorig = movHoriz.velX;

    }
    

	void OnTriggerEnter2D (Collider2D other){
		Debug.Log ("Colision");
		if ((other.gameObject.tag == tagC) && (waitBeer == true)) {
			Destroy (other.gameObject);
			EmpiezaABeber ();
			GameManager.instance.DaPuntos ();
			waitBeer = false;
		}

	}

	public void EmpiezaABeber(){
		movHoriz.velX = -velXorig; //El NPC se mueve durante un tiempo hacia atrás

		Invoke ("NPCBebiendo", 3.0f); 
	}

	//Para el movimiento del NPC para simular que bebe
	public void NPCBebiendo(){
		movHoriz.velX = 0.0f;

		//GameManager.instance.Bebiendo();

		Invoke ("TerminaBeber", 1.0f);
	}

	//Reinicia el movimiento del NPC para que vuelva a la puerta del "Bar" y dispara jarra vacía
	void TerminaBeber() { 
		movHoriz.velX = velXorig;

		jarraVacía.transform.position = transform.position; //Situamos la jarravacía en la pos del NPC
		Instantiate (jarraVacía); //Creamos la Jarra Vacía
		waitBeer = true;
	}
}

