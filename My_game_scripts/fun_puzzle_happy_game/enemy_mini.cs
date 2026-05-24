using UnityEditor.Build;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class enemy_mini : MonoBehaviour
{
    public Rigidbody rb;
    public player p;

    // Movement speed (units per second)
    public float speed;

    // Calculated next position used with MovePosition
    public Vector3 follow_;

    // Whether this mini enemy is active and should follow the player
    public bool active_; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
        if (p == null)
            p = FindAnyObjectByType<player>();
        speed = 2.5f;
    }

    public void FixedUpdate()
    {
        if (active_)
        {
            // Compute the next position towards the player's current position.
            // Use rb.position (physics position) and Time.fixedDeltaTime for consistent physics updates.
            follow_ = Vector3.MoveTowards(
                rb.position,
                p.transform.position,
                speed * Time.fixedDeltaTime
            );

            // Move the Rigidbody to the calculated position (physics-friendly movement).
            rb.MovePosition(follow_);
        }

    }
}
