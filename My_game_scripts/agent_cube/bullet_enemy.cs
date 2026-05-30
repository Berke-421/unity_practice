using UnityEngine;

public class bullet_enemy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("enemy1")) // enemy bullet; if it hits something other than enemy1
        {
            Destroy(transform.root.gameObject); // destroy the bullet
        }
    }

    void Update()
    {
        transform.position += transform.forward * 10f * Time.deltaTime; // let the bullet travel forward as is
    }
}
