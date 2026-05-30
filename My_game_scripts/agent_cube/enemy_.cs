using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class oyuncu : MonoBehaviour
{
    [Header("Physics Components")]
    public Rigidbody rb;

    [Space(10)]
    [Header("Positions & Landmarks")]
    public Transform spawn, area, flag;

    [Space(10)]
    [Header("Character Control & Values")]
    public float speed, z, h, yon;
    public int health;
    public Vector3 v;
    public Quaternion q;

    [Space(10)]
    [Header("Objects & Managers")]
    public GameObject bulletPlayer, cube;
    public enemyManagers em;

    [Space(10)]
    [Header("Status Controls (Booleans)")]
    public bool[] isComplate;
    public bool gotFlag;

    void Start()
    {
        isComplate = new bool[3] {false, false, false}; // start with all 3 sections incomplete
        gotFlag = false; // start with flag not taken

        speed = 5f;
        health = 15;
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet_enemy")) // if hit by enemy bullet
        {
            health -= 1; // reduce one health
            if(health <= 0) // if health is less than or equal to zero
            {
                Vector3 playerSpawnPosition = spawn.position; // assign spawn position to a new vector
                playerSpawnPosition.y += 2; // move spawn position up
                transform.position = playerSpawnPosition; // apply spawn position to the player's position

                health = 15; // reset health
            }
        }

        if (other.CompareTag("player_area") && gotFlag) // if it's the player area and the flag has been taken
        {
            flag.transform.SetParent(null); // detach flag from player
            area.transform.SetParent(flag); // attach flag to the area

            foreach(var e in em.enemies) // all enemies
            {
                Destroy(e); // destroy enemies
            }
        }

        if (other.CompareTag("flag") && !gotFlag) // if flag not taken and it collides with the flag
        {
            gotFlag = true; // flag taken
            flag.transform.SetParent(transform); // attach flag to the player
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("level1") && !isComplate[0]) // if it collides with level1 and it's not completed
        {
            isComplate[0] = true; // mark level 1 as completed
            em.enemyCount = 1; // set 1 enemy for level 1
            em.createEnemy(0); // create enemies for level 1
        }

        if (collision.gameObject.CompareTag("level2") && !isComplate[1]) // if it collides with level2 and it's not completed
        {
            isComplate[1] = true; // mark level 2 as completed
            em.enemyCount = 3; // set 3 enemies for level 2
            em.createEnemy(1); // create enemies for level 2
        }

        if (collision.gameObject.CompareTag("level3") && !isComplate[2]) // if it collides with level3 and it's not completed
        {
            isComplate[2] = true; // mark level 3 as completed
            em.enemyCount = 5; // set 5 enemies for level 3
            em.createEnemy(2); // create enemies for level 3
        }
    }


    void Update() // control and input handling is done inside Update
    {
        z = Input.GetAxis("Vertical"); // w-s
        h = Input.GetAxis("Horizontal"); // a-d
    }

    public void FixedUpdate() // physics operations are done in FixedUpdate
    {
        // move forward/back
        v = transform.forward * z * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + v);

        // rotate left/right
        yon = h * 60f * Time.deltaTime;
        q = Quaternion.Euler(0, yon, 0);
        rb.MoveRotation(rb.rotation * q);

        // fire
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            Instantiate(bulletPlayer, transform.position, transform.rotation);
        }
    }
}
