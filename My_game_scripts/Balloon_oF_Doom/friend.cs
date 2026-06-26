using UnityEngine;
using UnityEngine.AI;

public class friend : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public Transform playerTransform;

    public bool onceDone;

    void Start()
    {
        if(agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (animator == null)
            animator = GetComponent<Animator>();

        onceDone = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance > 6f) // if distance is greater than 6
        {
            agent.speed = 5f; // set agent speed to 5   
            animator.SetInteger("speed", 5); // set animator parameter to 5
            agent.SetDestination(playerTransform.position); // set agent's destination to the player's position
        }
        else if (distance > 2f) // if distance is between 2 and 6
        {
            agent.speed = 2f; // set agent speed to 2
            animator.SetInteger("speed", 2); // set animator parameter to 2
            agent.SetDestination(playerTransform.position); // set agent's destination to the player's position
        }
        else // if distance is less than or equal to 2
        {
            animator.SetInteger("speed", 0); // set animator parameter to 0
            agent.speed = 0f; // set agent speed to 0

            if (!onceDone) // code to run only once
            {
                animator.SetTrigger("anotherJob"); // trigger the side job
                onceDone = true; // set to true so it doesn't run again after executing once
            }
        }
    }
}
