using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent agent;

    [SerializeField] private GameObject destiny;
    [SerializeField] private GameObject[] locations;

    private GameObject player;

    private float normalSpeed = 6f;
    private float runSpeed = 12f;

    private RaycastHit hit;
    private Vector3 dir;
    private float fovAngle = 120f;
    private float range = 8f;

    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        destiny = locations[0];
    }

    // Update is called once per frame
    void Update()
    {
        DestinationLogic();
        RayCastLogic();
    }

    public void RayCastLogic()
    {
        dir = player.transform.position - transform.position;
        float angle = Vector3.Angle(dir, transform.forward);

        Ray ray = new Ray(transform.position, dir);
        bool rayHit = Physics.Raycast(ray, out hit, range);

        if (angle < fovAngle / 2 && rayHit == true & hit.collider != null && hit.collider.CompareTag("Player"))
        {
            agent.speed = runSpeed;
            destiny = player;
            Debug.DrawRay(transform.position, dir, Color.red);
        }
        else if (locations[rand].transform.position == transform.position)
        {
            rand = Random.Range(0, 5);
        }
        else
        {
            agent.speed = normalSpeed;
            destiny = locations[rand];
        }
    }

    public void DestinationLogic()
    {
        agent.SetDestination(destiny.transform.position);
    }

}
