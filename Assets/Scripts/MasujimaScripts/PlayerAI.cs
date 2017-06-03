using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerAI : MonoBehaviour
{
    [SerializeField]
    private bool isAuto;
    [SerializeField]
    private float range = 25.0f;
    NavMeshAgent a;
    // Use this for initialization
    void Start()
    {
        a = GetComponent<NavMeshAgent>();
        if (isAuto)
            StartCoroutine(SetNextDestination());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SetNextDestination()
    {
        while (true)
        {
            if (a.pathPending || a.remainingDistance > 0.1f)
                yield return null;

            a.destination = range * Random.insideUnitCircle;
        }
    }
}