using UnityEngine;

public class bullet_ : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("dusman")) // If it collides with anything except the enemy
        { 
            Destroy(transform.root.gameObject); // destroy bullet
        }
    }

    void Update()
    {
        transform.position += transform.forward * 5f * Time.fixedDeltaTime; // Move straight forward 
    }
}
