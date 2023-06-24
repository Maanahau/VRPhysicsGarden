using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMovement : MonoBehaviour
{

    [SerializeField] Transform player;

    public bool followPlayer { get; set; }
    public bool lookAtPlayer { get; set; }

    private NavMeshAgent navAgent;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(followPlayer)
            navAgent.SetDestination(player.position);

        if (lookAtPlayer)
        {
            LookAtOverTime(player);
        }
    }

    private void LookAtOverTime(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);
    }

    public void MoveToTarget(Transform target)
    {
        followPlayer = false;
        navAgent.SetDestination(target.position);
    }

}
