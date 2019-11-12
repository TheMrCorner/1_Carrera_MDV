using UnityEngine;
using System.Collections;

public class JewelsMov : MonoBehaviour {
	public int velocGiro;
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, velocGiro, 0));
	}
}
