using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 落とし穴のエフェクト用
/// 最初に0.3近くまでスケールを拡張し、５秒後に閉じる。
/// </summary>
public class HoleEffect : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    transform.localScale = Vector3.one*0.01f;
	}

    private float timer = 0;
	// Update is called once per frame
	void Update () {
        if (transform.localScale.z < 0)
        {
            Destroy(gameObject);
        }
        else if (timer > 5)
        {
            transform.localScale -= Vector3.one * Time.deltaTime * 0.6f;
        }
        else if (transform.localScale.z < 0.30f)
        { 
		transform.localScale += Vector3.one*Time.deltaTime*0.6f;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }
}
