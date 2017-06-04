using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private bool isHit = false;
	// Update is called once per frame
    void Update()
    {
        
        gameObject.transform.LookAt(Camera.main.transform);
        if (!isHit)
        {
            var heading = Camera.main.transform.position - gameObject.transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance; // This is now the normalized direction.
            gameObject.transform.position += direction * Time.deltaTime * 0.5f;
        }
    }

    // 衝突している間呼ばれ続ける  
    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Hole"))
        {
            //isHit = true;
            if (transform.localScale.z < 0)
            {
                Destroy(gameObject);
            }
            transform.localScale -= Vector3.one * Time.deltaTime * 0.6f;
        }
    }
}
