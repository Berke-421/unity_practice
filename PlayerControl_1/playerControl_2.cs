/* READ HERE
"I developed a 2.5D character controller featuring movement along a fixed axis, grounded-only jumping, and a physics-compliant crouching system.
*/

using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class control : MonoBehaviour
{
    public Rigidbody _rb; // Rigidbody bileşenine erişim sağlamak için bir değişken tanımlar. ama şu an boştur.
    public Vector3 moveZ;
    public float speed = 3f;
    public float z;
    bool isground;


    void Start()
    {
        transform.position = new Vector3(0, 2, 0); // başlangıç pozisyonunu start transform'undan alır.
        isground = true;
        /*
           _rb = GetComponent<Rigidbody>(); 
           
        */
        if (_rb == null) // Eğer rigibody atanmadıysa
            // Rigidbody bileşenine erişim sağlar ve _rb değişkenine atar. Bu sayede objenin fiziksel hareketlerini kontrol edebiliriz.
            _rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        z = Input.GetAxis("Horizontal"); // a tuşuna basılırsa -1, d tuşuna basılırsa +1, onun dışında hepsinde 0 döner
        // buradan vasılan tuş ile float sayısı alınır
    }

    void FixedUpdate()
    {   // alınan float sayısı yeni vektöre yön olarak aktarılır
        moveZ = new Vector3(0, 0, -z);

        bool isGrounded = Physics.SphereCast(transform.position, 0.3f, Vector3.down, out RaycastHit hit, 0.2f);

        // aktarılan yeni vektörün bilgisi hareket içerisinde kullanılır
        _rb.MovePosition(_rb.position + moveZ * speed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rb.AddForce(Vector3.up * 12f, ForceMode.Impulse);
            isground = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
        }

        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        /*
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
