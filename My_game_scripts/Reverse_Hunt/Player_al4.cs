using UnityEngine;

public class Player_al4 : MonoBehaviour
{
    public Rigidbody rb; // for movement and physics operations
    public Vector3 move; // movement vector
    public Quaternion rot; // for rotation operations
    public director director_; // access to the director manager class

    public float speed, z, h; // movement speed, forward/back and left/right inputs
    public int can; // player's life count (health)

    // spawn point, camera points, losing area and winning area:
    public Transform SpawnPoint, camera, defaultCameraPoint, backCameraPoint, losePoint, winPoint; 

    void Start()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody>();

        speed = 4.5f;
        can = 3;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("kayip")) // if colliding with the "kayip" (losing) area, teleport to spawn
            transform.position = SpawnPoint.position;

        if (collision.gameObject.CompareTag("enemy1")) // if player collides with an enemy
        {
            Debug.Log("Düşmana çarptı");
            if (director_.cycle.morning) // if it's morning
            {
                director_.enemyManager.DestroyEnemy(collision); // destroy the enemy via the director's enemy manager
            }

            else // if it's night
            {
                can -= 1; 
                transform.position = SpawnPoint.position; // respawn player to spawn point
            }


            if (can == 0) // if health reaches zero
            {
                transform.position = losePoint.position; // teleport to losing area
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        z = Input.GetAxis("Vertical"); // w - s
        h = Input.GetAxis("Horizontal"); // a - d

        // Look backwards
        if (Input.GetKey(KeyCode.LeftShift)) // while holding shift key
        {
            camera.position = backCameraPoint.position; // move camera to the back view point
            camera.rotation = backCameraPoint.rotation; // set camera rotation to back view rotation
        }

        else
        {
            camera.position = defaultCameraPoint.position; // move camera to default view point
            camera.rotation = defaultCameraPoint.rotation; // set camera rotation to default view rotation
        }

    }

    void FixedUpdate()
    {
        // forward-backward movement
        move = transform.forward * z * speed * Time.fixedDeltaTime; 
        rb.MovePosition(rb.position + move);

        // left-right turning (rotation)
        float turn = h * 50f * Time.fixedDeltaTime; 
        Quaternion rot = Quaternion.Euler(0f, turn, 0f); 
        rb.MoveRotation(rb.rotation * rot); 
    }
}
