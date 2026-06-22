using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Stores the player's systems and states
    public Rigidbody rb;
    public Animator animator;

    // Variables that hold movement and state information
    public float z, h, speed;
    public bool isMoving, isGameEnd;
    public int allGold;

    // Variables that hold coordinates and camera points
    Vector3 move;
    public Transform Camera, BackCameraPoint, DefaultCameraPoint, spawn;
    quaternion qua;

    // Holds references to the game director and gold objects
    public GameDirector director;
    public GameObject golds;
    public Camera cameraSetting;

    void Start()
    {
        speed = 2f;
        isGameEnd = false; // Game is not ended at start

        allGold = golds.transform.childCount; // Find and assign the number of golds
    }

    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("ship") && allGold == 0) // When colliding with the ship and all gold has been collected
        {
            isGameEnd = true;
            director.win();  // Trigger win state        
        }

        if (other.CompareTag("gold")) // If colliding with a gold
        {
            other.gameObject.SetActive(false); // altın yok olur
            allGold--; // altın sayısı azalır
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("sea")) // When colliding with the sea
        {
            isGameEnd = true;

            director.lose2(); // Trigger fall-into-sea lose state
        }

        if (collision.gameObject.CompareTag("clown")) // If colliding with a clown
        {
            isGameEnd = true;

            director.lose(); // Trigger lose state
        }

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("test");

        z = Input.GetAxisRaw("Vertical");
        h = Input.GetAxis("Horizontal");

        isMoving = (z != 0);

        if (isMoving) // If moving
            animator.SetBool("walk", true); // Enable walking animation

        else // If not moving
            animator.SetBool("walk", false); // Disable walking animation

        //

        if (Input.GetKey(KeyCode.LeftShift) && isMoving) // If left shift is held and moving
        {
            speed = 5f;
            animator.SetBool("walk", false); // Disable walk animation while running
            animator.SetBool("run", true); // Enable run animation
        }

        else if (isMoving) // If only moving
        {
            speed = 2f;
            animator.SetBool("walk", true); // Enable walk animation when walking
            animator.SetBool("run", false); // Disable run animation when walking
        }

        else // If not moving
        {
            animator.SetBool("walk", false); // Walking stops
            animator.SetBool("run", false); // Running stops
        }

        //

        if (Input.GetMouseButton(0)) // If left mouse button is pressed
        {
            Camera.position = BackCameraPoint.position; // kamerayı arka kamera noktasına taşıyoruz
            Camera.rotation = BackCameraPoint.rotation; // kamerayı arka kamera noktasının rotasyonuna ayarlıyoruz
        }

        else
        {
            Camera.position = DefaultCameraPoint.position; // kamerayı varsayılan kamera noktasına taşıyoruz
            Camera.rotation = DefaultCameraPoint.rotation; // kamerayı varsayılan kamera noktasının rotasyonuna ayarlıyoruz
        }

    }

    private void FixedUpdate()
    {
        if (!isGameEnd)
        {
            move = transform.forward * z * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);

            qua = quaternion.Euler(0, 3f * h * Time.fixedDeltaTime, 0);
            rb.MoveRotation(rb.rotation * qua);
        }

        bool isGround = Physics.Raycast(

          rb.position,
          Vector3.down,
          0.3f
        );


        if (Input.GetKeyDown(KeyCode.Space) && isGround && !isMoving)
        {
            animator.SetBool("jump_idle", true);
            rb.AddForce(Vector3.up * 3f, ForceMode.Impulse);
            isGround = false;
        }

        else if (isGround)
        {
            animator.SetBool("jump_idle", false);
        }


        if(Input.GetKeyDown(KeyCode.Space) && isGround && isMoving)
        {
            animator.SetBool("jump_move", true); // Use movement jump
            rb.AddForce(Vector3.up * 3f, ForceMode.Impulse); // Jump
            isGround = false;
        }

        else if (isGround)
        {
            animator.SetBool("jump_move", false);
        }
    }
}
