using UnityEngine;

public class enemy_ : MonoBehaviour
{
    [Header("Components & Prefabs")]
    public Rigidbody rb;
    public GameObject bulletEnemy;

    [Header("Player & Stats")]
    public oyuncu o;
    public int health;

    [Header("Movement & Timers")]
    public float speed;
    public float time; // Instead of declaring on the same line, writing on separate lines makes tracking easier

    void Start()
    {
        health = 3;
        speed = 3f;
        if (rb == null)
            rb = GetComponent<Rigidbody>();
        if (o == null)
            o = FindFirstObjectByType<oyuncu>();
        if (bulletEnemy == null)
            bulletEnemy = GameObject.Find("Mermi");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet_player"))
        {
            health -= 1;
            if(health <= 0)
            {
                Destroy(gameObject);
            }            
        }
    }

    public void FixedUpdate()
    {
        transform.LookAt(o.rb.position); // make the enemy look at the player

        float dist = Vector3.Distance(rb.position, o.rb.position); // calculate the distance between enemy and player

        if (dist > 5f) // if distance is greater than 5
        {
            rb.position = Vector3.MoveTowards( // move enemy position towards player position

                rb.position, // enemy position
                o.rb.position, // player position
                speed * Time.fixedDeltaTime // movement speed (3 units per second) and time factor (compatible with FixedUpdate)
            );
        }

        time += Time.fixedDeltaTime; // time counter

        if (time >= 2f) // if time is two or more
        {
            time = 0; // reset time
            Instantiate(bulletEnemy, transform.position, transform.rotation); // spawn bullet at enemy position and rotation
        }
    }
}
