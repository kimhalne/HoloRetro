using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyGenerate : MonoBehaviour
{


    public GameObject kitty;

	// Use this for initialization
	void Start () {
		
	}

    private float counter = 0;
	// Update is called once per frame
	void Update ()
	{

	    counter += Time.deltaTime;

	    if (counter > 5)
	    {
	        GameObject.Instantiate(kitty);
	        kitty.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5f;
	        counter = 0;
	    }


	}
}
