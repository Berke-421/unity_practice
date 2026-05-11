using Unity.Mathematics;
using UnityEngine;

public class control : MonoBehaviour
{
    public Rigidbody rb;
    public quaternion q;
    public Vector3 move;
    public float rotationSpeed = 50f, speed, h, z;
    public int puan;
    public bool isAppleCollected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5f;
        puan = 0;
        isAppleCollected = false;
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        z = Input.GetAxis("Vertical"); // W - S
        h = Input.GetAxis("Horizontal"); // A - D
    }


    private void OnCollisionEnter(Collision collision) // Detects enemy collisions compatible with the physics engine.
    {
        if (collision.gameObject.CompareTag("dusman"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) // Detects collisions independently of the physics engine.
    {
        if (other.CompareTag("odul"))
        {
            isAppleCollected = true;
            puan += 1;
            other.gameObject.SetActive(false); // tetiklenen obje yok olur
        }
    }


    void FixedUpdate()
    {
        // forward - back
        move = transform.forward * z; // yön bilgisini alır (+1 mi -1 mi)
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime); // mevcut pozisyona girilen yön bilgisi eklenir

        // right - left
        float turn = h * rotationSpeed * Time.fixedDeltaTime; // derece sayısı elde edilir
        Quaternion rot = Quaternion.Euler(0f, turn, 0f); // derece sayısı, yön bilgisine aktarılır
        rb.MoveRotation(rb.rotation * rot); // objenin mevcut yönüne eklenir

        // jump
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * 12f, ForceMode.Impulse);
        }

        // Crouch
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.isKinematic = true;
            transform.localScale = new Vector3(1, 0.5f, 1);
            rb.isKinematic = false;
        }
        else
            transform.localScale = new Vector3(1, 1, 1);
    }
}

