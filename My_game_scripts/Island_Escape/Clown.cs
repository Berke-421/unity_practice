using UnityEngine;
using UnityEngine.AI;

public class Clown : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public Rigidbody rb;

    public Player player;

    public float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.SetBool("laugh", true);
    }

    public void Update()
    {
        transform.LookAt(player.transform.position);
        Debug.DrawRay(transform.position, transform.forward * 3f, Color.red); // Debug ray to show where the clown is looking
        agent.speed = 4f;
    }

    public void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= 40) // Clown starts chasing the player after 40 seconds
        {
            animator.SetBool("run", true); // Trigger the clown's running animation
            /*
           Vector3 move = Vector3.MoveTowards(

               rb.position,
               playerT.position,
               speed * Time.fixedDeltaTime
           );

           rb.MovePosition(move);
            */
            if (!player.isGameEnd) agent.SetDestination(player.transform.position); // Set the clown's destination to the player's position, making it chase the player
        }
    }
}
