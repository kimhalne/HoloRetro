using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateNavMeshLink : MonoBehaviour
{
    Vector3 oldPosition, currentPosition;
    NavMeshAgent m_Agent;
    // Use this for initialization
    void Start()
    {
        currentPosition = transform.position;
        oldPosition = currentPosition;
        m_Agent = GetComponent<NavMeshAgent>();
        //m_Agent.Move(new Vector3(100, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        // 止まってる時
        //if (m_Agent.)
          //  print("stop");
            // 目的地にいなかったら
            if (m_Agent.destination == currentPosition-new Vector3(0,1,0))
            {
                //print("到着");
                //print("目的地に着けなかった(´；ω；｀)");
            }
        //print(m_Agent.destination);
        //print(currentPosition);
        Ray ray = new Ray(transform.position+transform.forward, new Vector3(0, -7.0f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10))
        {
            //print(hit.collider.name);
        }
        Debug.DrawRay(ray.origin, ray.direction*7.0f, Color.red, .1f);
        oldPosition = currentPosition;
    }
}