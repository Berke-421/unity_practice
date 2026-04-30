/* READ HERE
I practiced my Unity skills by implementing a character controller that features smooth mouse look, direction-based movement, 
grounded-only jumping, and a physics-based crouching system designed to prevent collision conflicts.
*/

using Unity.Mathematics;
using UnityEngine;
public class player : MonoBehaviour
{
    public Rigidbody rb;
    public quaternion q;
    public float rotationSpeed = 50f;
    public Vector3 move;
    public float speed;
    public float h;
    public float z;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5f;
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        
        z = Input.GetAxis("Vertical"); // W - S
        h = Input.GetAxis("Horizontal"); // A - D
    }

    void FixedUpdate()
    {
        // ileri - geri gitmek | forward - back
        move = transform.forward * z; // yön bilgisini alır (+1 mi -1 mi)
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime); // mevcut pozisyona girilen yön bilgisi eklenir

        // sağ - sol bakmak | right - left
        float turn = h * rotationSpeed * Time.fixedDeltaTime; // derece sayısı elde edilir
        Quaternion rot = Quaternion.Euler(0f, turn, 0f); // derece sayısı, yön bilgisine aktarılır
        rb.MoveRotation(rb.rotation * rot); // objenin mevcut yönüne eklenir

        // zıplamak | jump
        bool isGrounded = Physics.SphereCast(transform.position, 0.3f, Vector3.down, out RaycastHit hit, 0.2f);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * 6f, ForceMode.Impulse);
        }

        // eğilmek | crouch
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
