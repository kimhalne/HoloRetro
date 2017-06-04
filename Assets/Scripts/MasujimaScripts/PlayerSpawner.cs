using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public GameObject player;
    private GameObject playerOrigin;
    public float range =10;
	// Use this for initialization
	void Start () {
        playerOrigin = Resources.Load("TestAIPlayer") as GameObject;

        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!player) {
                player = GameObject.Find("Player");
                if (!player)
                    player = Instantiate(playerOrigin, Vector3.zero, Quaternion.identity);

            }

        }
	}
	
	// Update is called once per frame
	void Update () {

		if(!player)
        {
            print("プレイヤーが消えた");
            Vector2 pos=range *Random.insideUnitCircle;
            Vector3 spawnPoint = new Vector3(pos.x,10,pos.y);
            player = Instantiate(playerOrigin, spawnPoint, Quaternion.identity);
            print("プレイヤーがリスポーンした");

        }
	}
}
