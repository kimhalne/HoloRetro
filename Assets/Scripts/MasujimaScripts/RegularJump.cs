using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RegularJump : MonoBehaviour {
    private NavMeshAgent a;
    private Rigidbody rb;
    MovableOtherForceAgent ma;

    private bool isGround;
   [SerializeField] private float jumpPower = 1500;
    [SerializeField] private float jumpPeriod = 2;
    [SerializeField] private bool isRandomPeriod = false;

    // Use this for initialization
    void Start () {
        //StartCoroutine(Jump());
        a = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        ma = GetComponent<MovableOtherForceAgent>();

    }

    // Update is called once per frame
    void Update () {
        if(ma)
        isGround = ma.IsGround();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(!ma)
            if (other.gameObject.tag == "Stage")
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }
    }

    public IEnumerator Jump()
    {
        while (true)
        {
            if (isRandomPeriod)
                yield return new WaitForSeconds(Random.Range(2, 10));
            else
                yield return new WaitForSeconds(jumpPeriod);

            if (isGround)
            {
            print(gameObject.name+" is Jumpping");
                if (ma)
                    ma.Jump(jumpPower);
                else
                    rb.AddForce(Vector3.up * jumpPower);
            }
            
        }
    }
}
