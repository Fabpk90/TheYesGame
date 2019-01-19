using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollower : Enemy
{   
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player)
            this.player = player;
    }

    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player)
            this.player = null;
    }

    private void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        
        if(player)
            player.TakeDamage(atk);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 dir = transform.position - player.transform.position;

            agent.SetDestination(transform.position + (-dir.normalized));
        }
    }
}
