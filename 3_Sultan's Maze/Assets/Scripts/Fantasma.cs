using UnityEngine;
using System.Collections;

public class Fantasma : MonoBehaviour {
    public int velocFantasma;

    // Use this for initialization
	void Start () {
        InvokeRepeating("MovementLogic", 1, velocFantasma);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    //Lógica de movimiento del fantasma
    void MovementLogic() {
        int i;
        RaycastHit hit;

        //Cada segundo, rotamos 180 grados y después comprobamos
        transform.Rotate(new Vector3(0, 180, 0));

        for (i = 0; i < 4; i++)
        {
            //Giramos 90 grados y comprobamos
            transform.Rotate(new Vector3(0, 90, 0));

            //Si no hay nada en el camino, andamos
            if (!(Physics.Raycast(transform.position, transform.forward, out hit, 1.0f)))
            {
                transform.position += transform.forward;
                i = 3;
            }

            //Si hay algún collider (por ejemplo, una joya), comprobamos que no tenga ni tag muro ni tag Finish, si es así, andamos
            else if ((hit.collider.tag != "Muro") && (hit.collider.tag != "Finish"))
            {
                //Además, si el collider es el player, termina la partida
                if (hit.collider.tag == "Player")
                {
                    GameManager.instance.Muerte();
                }
                //Si no es el jugador, avanzamos
                else
                {
                    transform.position += transform.forward;
                    i = 3;
                }
            }      
        }
    }
}
