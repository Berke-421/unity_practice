using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb; // player's physics body for control

    public OdulManager odulmanager_; // reference to OdulManager (reward manager)
    public GameDirector_al3 gamedirector; // reference to GameDirector; handles level restart on player loss

    public float x, z, speed; // x and z represent movement input; speed is movement speed
    public int health; // player's health; starts at 3 and decreases when hit by enemies. If <= 0, player loses and level restarts via gamedirector.RestartLevel()

    public Vector3 vector; // movement vector used in FixedUpdate to update player position
    public Transform spawnPoint; // spawnPoint is the transform where the player will respawn when needed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (odulmanager_ == null)
            odulmanager_ = FindFirstObjectByType<OdulManager>();

        speed = 8f; // player speed
        health = 3; // player health
    }

    private void OnTriggerEnter(Collider other) // called when player enters a trigger collider
    {
        if (other.CompareTag("odul")) // if it collides with a 'odul' (reward)
        {
            odulmanager_.rewardCollected += 1; // increment collected rewards
            other.gameObject.SetActive(false); // deactivate the collected object
        }

        if (other.CompareTag("bullet")) // if it collides with a 'bullet'
        {
            health -= 1; // decrease health by 1
        }
    }

    private void OnCollisionEnter(Collision collision) // called when player collides with a collider
    {
        if (collision.gameObject.CompareTag("enemy")) // if it collides with an 'enemy'
        {
            gamedirector.RestartLevel(); // player loses and level restarts
        }

        if (collision.gameObject.CompareTag("kayip")) // if it collides with a 'kayip' (fall area)
        {
            transform.position = spawnPoint.position; // move player to spawn point
        }
    }

    public void spawnPlayer() // method to teleport player to the spawn point
    {
        transform.position = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal"); // a - d
        z = Input.GetAxisRaw("Vertical"); // w - s

        if (health <= 0) // if health is zero or less
        {
            gamedirector.RestartLevel(); // player loses and level restarts
            health = 3; // reset health
        }
    }

    public void FixedUpdate()
    {
        vector = new Vector3(x, 0, z) * speed * Time.fixedDeltaTime; // build the movement vector using x and z inputs and speed; use fixedDeltaTime for consistent physics
        rb.MovePosition(rb.position + vector); // update Rigidbody position according to the movement vector
    }
}
