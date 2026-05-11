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


    private void OnCollisionEnter(Collision collision) // fizik motoruna uygun düşman çarpışmasını algılar
    {
        if (collision.gameObject.CompareTag("dusman"))
        {
            gameObject.SetActive(false); // gameObject = 'GameObject' sınıfından nesne referansı
        }
    }

    private void OnTriggerEnter(Collider other) // fizik motorundan bağımsız çarpışmayı algılar
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
        // ileri - geri gitmek
        move = transform.forward * z; // yön bilgisini alır (+1 mi -1 mi)
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime); // mevcut pozisyona girilen yön bilgisi eklenir

        // sağ - sol bakmak
        float turn = h * rotationSpeed * Time.fixedDeltaTime; // derece sayısı elde edilir
        Quaternion rot = Quaternion.Euler(0f, turn, 0f); // derece sayısı, yön bilgisine aktarılır
        rb.MoveRotation(rb.rotation * rot); // objenin mevcut yönüne eklenir

        // zıpamak
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * 12f, ForceMode.Impulse);
        }

        // eğilmek
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

