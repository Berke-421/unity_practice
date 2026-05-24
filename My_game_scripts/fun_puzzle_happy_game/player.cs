using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed, x, z;
    public Vector3 move;
    public GameDirector director;
    public quaternion q;
    public enemies dusmanlar;
    public pinpon pin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5f;
        if (rb == null)
            rb = GetComponent<Rigidbody>();
        if (director == null)
            director = GameObject.FindAnyObjectByType<GameDirector>();
        if (pin == null)
            pin = FindAnyObjectByType<pinpon>();

    }

    // Update is called once per frame
    void Update()
    {
        // read input axes each frame
        x = Input.GetAxis("Horizontal"); // a-d
        z = Input.GetAxis("Vertical"); // w-s
    }

    private void OnTriggerEnter(Collider other)
    {
        // trigger-based interactions: set director flags or call actions
        if (other.CompareTag("in"))
        {
            director.button2 = true;
            print("karakter mavi küreyi hissetti");
        }

        if (other.CompareTag("kalk"))
        {
            director.button2 = false;
            director.goUp();
        }

        if (other.CompareTag("cevir"))
        {
            director.button3 = true;
        }

        if (other.CompareTag("kazan"))
        {
            dusmanlar.Win();
        }

        if (other.CompareTag("calis"))
        {
            pin.calisirMi = true;
        }

        if (other.CompareTag("dur"))
        {
            pin.calisirMi = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        // collisions with enemies or level triggers
        if (collision.gameObject.CompareTag("enemy1") || collision.gameObject.CompareTag("enemy2") ||
            collision.gameObject.CompareTag("enemy3") || collision.gameObject.CompareTag("enemy4"))
        {
            director.spawnPoint();
        }

        if (collision.gameObject.CompareTag("level1"))
        {
            dusmanlar.startLevel1();
        }

        if (collision.gameObject.CompareTag("level2"))
        {
            dusmanlar.startlevel2();
        }

        if (collision.gameObject.CompareTag("level4"))
        {
            dusmanlar.startlevel4();
        }

        if (collision.gameObject.CompareTag("final"))
        {
            dusmanlar.startlevel4();
        }

        if (collision.gameObject.CompareTag("kayip"))
        {
            director.spawnPoint();
        }
    }

    void FixedUpdate() // rotate smoothly based on horizontal input (-1 or 1 expected)
    {
        switch (x)
        {
            case -1:
                rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.Euler(0,-90, 0), 10f * Time.fixedDeltaTime));
                break;


            case 1:
                rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.Euler(0, 90, 0), 10f * Time.fixedDeltaTime));                                               
                break;
        }

        // move
        move = new Vector3(x, 0, z);
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        // jump
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 8f, ForceMode.Impulse);
        }

        // crouch
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
        }

        else
            transform.localScale = new Vector3(1,1,1);
    }
}

