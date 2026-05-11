using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody rb;
    public control player;
    public Vector3 takip;

    void Start()
    {
        if(player == null)
            player = FindFirstObjectByType<control>();
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if(player.isAppleCollected) // Starts enemy movement when the object is picked up.
        {
            takip = Vector3.MoveTowards( 
                rb.position, 
                player.transform.position,
                speed * Time.fixedDeltaTime
            );

            rb.MovePosition(takip);
        }  
    }
}

