using UnityEngine;

public class control : MonoBehaviour
{
    public Rigidbody _rb; // Rigidbody bileşenine erişim sağlamak için bir değişken tanımlar. ama şu an boştur.
    public Vector3 moveZ;
    public float speed = 3f;
    public float z;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, 2, 0); // başlangıç pozisyonunu start transform'undan alır.
        /*
           _rb = GetComponent<Rigidbody>(); 
           
        */
        if (_rb == null) // Eğer rigibody atanmadıysa
            // Rigidbody bileşenine erişim sağlar ve _rb değişkenine atar. Bu sayede objenin fiziksel hareketlerini kontrol edebiliriz.
            _rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        z = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveZ = new Vector3(0, 0, -z);
        _rb.MovePosition(_rb.position + moveZ * speed * Time.fixedDeltaTime);

        /*
        old method
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * 1f, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            move = Vector3.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move = Vector3.back;
        }

        _rb.MovePosition(_rb.position + move * speed * Time.fixedDeltaTime);
        */
    }
}
