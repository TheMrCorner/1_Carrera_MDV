using UnityEngine;
using System.Collections;

public class Transparenta : MonoBehaviour {
	
	public float nivelTransparencia;
	public Renderer transparent;
	Color c;  //We will use this variable for the change of color
	Color original;  //This variable will be used for saving the original color in order to return the objects color

	void Start (){
		original = transparent.material.color;
	}

	void Update (){
		SinTransparencia ();
	}

	//This method makes the gameobject transparent
	public void Transparencia ()
	{
		c = transparent.material.color;
		c.a = nivelTransparencia;
		transparent.material.color = c;
	}

	//This method returns the object's original color
	public void SinTransparencia ()
	{
		transparent.material.color = original;
	}
}
