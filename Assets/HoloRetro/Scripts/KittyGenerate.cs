using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyGenerate : MonoBehaviour
{
    private int _totalTime;
    private int _totalNum;
    private bool _isStarted;

    [SerializeField]
    public GameObject kitty;
    public int interval;
    public int enemyRadius;
    public int enemyNumLimit;
    public int startTime;

    // Use this for initialization
    void Start () {
        _totalTime = 0;
        _totalNum = 0;
        _isStarted = false;
    }

    private float counter = 0;
	// Update is called once per frame
	void Update ()
	{
        _totalTime += (int)(Time.deltaTime * 1000);

        if (!_isStarted)
        {
            if (_totalTime < startTime)
                return;
            _isStarted = true;
            _totalTime = 0;
        }

        if (_totalTime < interval)
            return;

        if (_totalNum >= enemyNumLimit)
            return;
        
        SpawnBox();
        _totalTime -= interval;
        _totalNum += 1;
	    //if (counter > 5)
	    //{
	    //    GameObject.Instantiate(kitty);
	    //    kitty.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5f;
	    //    counter = 0;
	    //}


	}

    void SpawnBox()
    {
        if (null != kitty)
        {
            GameObject newObject;

            //_originBoxと同じ構成のオブジェクトを生成.
            newObject = Instantiate(kitty);
            newObject.transform.position = GeneratePos();

            //元にしたオブジェクトの非アクティブ状態を引き継いでいるので、アクティブにする.
            newObject.SetActive(true);
            
        }

        return;
    }

    Vector3 GeneratePos()
    {
        Vector3 cameraPos = GameObject.Find("HoloLensCamera").transform.position;
        //Vector3 cameraPos = GameObject.Find("Main Camera (1)").transform.position;
        float rad = Mathf.Deg2Rad * Random.Range(0, 360);
        float x = Mathf.Sin(rad) * enemyRadius;
        float y = 1.75f;
        float z = Mathf.Cos(rad) * enemyRadius;

        return new Vector3(x - cameraPos.x, y, z - cameraPos.z);
    }

}
