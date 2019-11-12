using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	int puntosJugador = 0;
	public int vidas = 4;

	public GameObject vidas1;
	public GameObject vidas2;
	public GameObject vidas3;
	public GameObject vidas4;
	bool bebiendo = false;  //Para cambiar el sprite del camarero
	public Text textoPuntos;
	public GameObject panelFin;

	// Use this for initialization
	void Start () {
		instance = this;
		vidas1.SetActive (vidas >= 1);
		vidas2.SetActive (vidas >= 2);
		vidas3.SetActive (vidas >= 3);
		vidas4.SetActive (vidas >= 4);
		panelFin.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () { 
		textoPuntos.text = "Puntos del Jugador: " + puntosJugador;
		if (GameObject.FindGameObjectWithTag("npc") == null)
			panelFin.SetActive(true);
	}

	public void DaPuntos(){ //Aumenta el número de puntos del jugador
		if (vidas > 0) {
			puntosJugador++;
			Debug.Log (puntosJugador);
		}

	}

	public void QuitaVidas(){ //Resta vidas al jugador
		vidas--;
		TextoVidas ();
		Debug.Log (vidas);

		//Debug.Log (vidas);
	}

	void TextoVidas(){
		vidas1.SetActive (vidas >= 1);
		vidas2.SetActive (vidas >= 2);
		vidas3.SetActive (vidas >= 3);
		vidas4.SetActive (vidas >= 4);
		Debug.Log (vidas);

		panelFin.SetActive (vidas < 1);
	}

	//Se llama cuando la cerveza colisiona con el NPC
	public void Bebiendo(){
		bebiendo = true;
	}
	public void reset(){
		SceneManager.LoadScene ("Proyecto final");
	}
}
