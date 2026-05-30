using UnityEngine;

public class bullet_player : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("player")) // player bullet, if it hits something other than the player
        {
            Destroy(transform.root.gameObject); // destroy the bullet
        }
    }
    void Update()
    {
        transform.position += transform.forward * 30f * Time.deltaTime; // let the bullet travel forward as is
    }
}
