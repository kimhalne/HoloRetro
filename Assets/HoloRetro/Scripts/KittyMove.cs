using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt(Camera.main.transform);
        var heading = Camera.main.transform.position - gameObject.transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance; // This is now the normalized direction.
        gameObject.transform.position += new Vector3(direction.x, 0, direction.z) * Time.deltaTime * 0.5f;
	    }
}
