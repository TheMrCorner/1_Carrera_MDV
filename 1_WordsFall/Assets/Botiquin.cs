using UnityEngine;
using System.Collections;

public class Botiquin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pala botiquín")
            GameManager.instance.Cura();
        else if (other.gameObject.name == "Botiquín deadzone")
            GameManager.instance.Cura();
    }
}
