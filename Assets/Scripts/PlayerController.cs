using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public LayerMask isGround;
    public NavMeshAgent agent;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(mouseRay, out RaycastHit hit, isGround);

            Vector3 can = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
            if (hit.transform.gameObject.tag != "Player")
            {
                transform.position = can;
                agent.SetDestination(can);
            }
        }

    }
}
