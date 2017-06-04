using UnityEngine;
using UnityEngine.AI;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{

    NavMeshAgent m_Agent;
    RaycastHit m_HitInfo = new RaycastHit();

    NavMeshPath path = null;
    Vector3[] positions = new Vector3[9];
    public LineRenderer lr;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (m_Agent.enabled)
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                    m_Agent.destination = m_HitInfo.point;
            }

        path = new NavMeshPath();
        if (m_Agent.enabled)
            NavMesh.CalculatePath(m_Agent.transform.position, m_Agent.destination, NavMesh.AllAreas, path);
        positions = path.corners;

        lr.widthMultiplier = 0.2f;
        lr.positionCount = positions.Length;

        for (int i = 0; i < positions.Length; i++)
        {
            //print("point" + i + "+" + positions[i]);
            lr.SetPosition(i, positions[i]);

        }

    }
}