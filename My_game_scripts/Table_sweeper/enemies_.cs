using UnityEngine;
using UnityEngine.AI;

public class enemies_ : MonoBehaviour
{
    public NavMeshAgent agent; // NavMeshAgent component enables enemy movement in the scene


    public Player player; // reference to access the player
    public enemyManager enemymanager; // reference to access the enemyManager script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (player == null)
            player = FindFirstObjectByType<Player>();

        if (enemymanager == null)
            enemymanager = FindFirstObjectByType<enemyManager>();

        agent.speed = 4; // enemy speed 4
        agent.autoBraking = false; // prevents agents from stopping at the destination, so they keep moving
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position); // enemies follow the player.
    }
}
