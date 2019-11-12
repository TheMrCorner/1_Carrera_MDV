using UnityEngine;
using System.Collections;

public class HorizMove : MonoBehaviour {
	
	public float velX = 0.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(velX, 0.0f, 0.0f));
    }
}
