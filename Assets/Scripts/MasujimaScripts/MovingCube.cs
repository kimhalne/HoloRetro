using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{

    Vector3 startPosition;
    public float amplitude;  //←移動させる幅値を各Cubeごとにインスペクタからセットする
    public float speed;      //←移動スピードを各Cubeごとにインスペクタからセットする
    public float delayTime=0;
    // Use this for initialization
    void Start()
    {
        startPosition = transform.localPosition;
        StartCoroutine(DelayStartUpdate());

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    IEnumerator DelayStartUpdate()
    {
        yield return new WaitForSeconds(delayTime);
        while(true)
        {
            float z = amplitude * Mathf.Sin(Time.time * speed);
            transform.localPosition = startPosition + transform.forward * z;

            yield return null;
        }
    }
}