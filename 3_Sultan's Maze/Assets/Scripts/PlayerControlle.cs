using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControlle : MonoBehaviour {

	public int energia = 100;
	public int joyasMano = 0;
	public GameObject joya;
	public GameObject reset;
    private object other;

	
	// Update is called once per frame
	void Update () {
		MovementLogic ();
		CogeJoya ();
		SueltaJoya ();
	}

	//Controles del jugador
	void MovementLogic () {
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
	    RaycastHit hit;
        

		//Si no hay ningún objeto en nuestro camino podemos avanzar y si hay un muro nop
		if ((Input.GetKeyDown (KeyCode.W)) && (!(Physics.Raycast (transform.position, fwd, out hit, 1.0f)) || !(hit.collider.CompareTag("Muro")))) {
			    Movimiento ();
		} 

		//Al pulsar estas teclas rotamos al personaje hacia la derecha o la izquierda respectivamente
		if (Input.GetKeyDown (KeyCode.D)) {
			transform.Rotate (new Vector3 (0, 90, 0));
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			transform.Rotate (new Vector3 (0, -90, 0));
		}
	}

	void Movimiento (){
		transform.position += transform.forward;
		energia -= (joyasMano + 1);
	}

	//Método que controla la lógica de coger las joyas
	void CogeJoya ()
	{
		//Generamos una esfera invisible que detecta los colliders en un radio de 0.5
		Collider[] cogeJoya = Physics.OverlapSphere (transform.position, 0.5f);

		//Variable que controla El recorrido del Array
		int i = 0;

		//Si el jugador pulsa la C estando sobre una joya y tiene más de 20 puntos de energía..
		if ((Input.GetKeyDown (KeyCode.C)) && (energia > 20)) {
			//..recorremos el array de Colliders para detectar que una joya está en nuestro rango
			while (i < cogeJoya.Length) {
				//Si hay una joya la añadimos a nuestro "Inventario" y salimos del bucle
				if (cogeJoya [i].CompareTag("Joya")) {
					Destroy (cogeJoya [i].gameObject);
					joyasMano++;
					break;
				}
				//Si no, seguimos buscando
				else
					i++;
			}
		}
		
	}

	//Método que controla la lógica de soltar las joyas
	void SueltaJoya ()
	{
		//Si el jugador pulsa la tecla Z y el numero de joyas en su mano es distinto de 0 instancia el prefab asignado
        //Además, si la energia del jugador es menor de 20, soltamos la(s) joya(s)
		if (((Input.GetKeyDown (KeyCode.Z)) || (energia < 20)) && (joyasMano > 0)) {
			joya.transform.position = transform.position + new Vector3( 0f, 0.5f, 0f);
			Instantiate (joya);
			//Reducimos el numero de joyas en mano para que no se puedan crear infinitas joyas
			joyasMano--;
		}
        
	}

	//Colisión con los objetos del escenario
	void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Fantasma"))
            GameManager.instance.Muerte();
        else if (other.CompareTag("Finish"))
            GameManager.instance.Salida();
    }

    //Método que nos resitúa en la entrada del laberinto
    public void Reset ()
	{
        energia = 100;
        joyasMano = 0;
		transform.position = reset.transform.position + new Vector3 (0f, 0f, 1f);
        transform.rotation = reset.transform.rotation;
        GameManager.instance.panelReset.SetActive(false);
        GameManager.instance.ActivaJugador();
	}
}