﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovableOtherForceAgent : MonoBehaviour
{
    NavMeshAgent m_Agent;
    Rigidbody rb;
    Collider c;
    bool isGround;
   [SerializeField] bool isAI;
    Vector3 destemp;
    [SerializeField] private GameObject targetPlayer;
    // Use this for initialization
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        c = GetComponent<Collider>();
        isGround = true;
        destemp = m_Agent.destination;

        if (isAI)
        {

            print("Stop component of ClickToMove.cs");
            GetComponent<ClickToMove>().enabled = false;
            print("Start Auto Jump");
            StartCoroutine(GetComponent<RegularJump>().Jump());

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            OnGround();
            if (!isAI)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (!m_Agent)
                    {
                        return;
                    }
                    OnTakeOffFromGround();
                    rb.AddForce(Vector3.up * 1000);
                }
            }

        }
        else
        {
            //m_Agent.destination = destemp;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Kill();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stage")
        {
            OnLanding();
        }
        else
        {

            //InAirEvent();
        }

        if (other.gameObject.tag == "Player")
            Attack(other.gameObject);

        if (other.gameObject.tag == "Hole")
        {
            print("Hit hole");
            Kill(other.gameObject);
        }
    }

    public void Kill(GameObject hole = null)
    {
        print("kill me baby");
        isGround = false;
        c.enabled = false;
        rb.useGravity = false;
        m_Agent.enabled = false;
        StartCoroutine(DeathAnimation(hole));
    }
    public IEnumerator DeathAnimation(GameObject hole)
    {
        var moveHash = new Hashtable();
        moveHash.Add("x", hole.transform.position.x);
        moveHash.Add("z", hole.transform.position.z);

        moveHash.Add("time", 1.5f);
        iTween.MoveTo(gameObject, moveHash);

        iTween.RotateTo(gameObject, iTween.Hash("y", 5000, "time", 8f));

        while (true)
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }

    private void OnLanding()
    {
        isGround = true;
        m_Agent.enabled = true;
        m_Agent.destination = destemp;

    }
    private void OnGround()
    {
        SearchTarget();

    }
    private void InAir()
    {
        //isGround = false;
        //m_Agent.enabled = false;

    } 
    private void OnTakeOffFromGround()
    {
        destemp = m_Agent.destination;

        isGround = false;
        m_Agent.enabled = false;
    }

    public void Jump(float jumpPower)
    {
        OnTakeOffFromGround();
        rb.AddForce(Vector3.up * jumpPower);
    }

    public bool IsGround()
    {
        return isGround;
    }
    private void SearchTarget()
    {
        if (targetPlayer)
            m_Agent.destination = targetPlayer.transform.position;
        else if (!targetPlayer)
        {
            targetPlayer = GameObject.FindGameObjectWithTag("Player");
            if (!targetPlayer)
                targetPlayer = GameObject.Find("Player");
        }
    }

    private void Attack(GameObject target)
    {
        Destroy(target);
    }
}
