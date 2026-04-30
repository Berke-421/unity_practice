/* READ HERE
I developed a basic character controller with 4-way movement (WASD) and jump logic, created as a practice project to understand
custom movement logic before diving into Rigidbody physics.
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class kutukontrol : MonoBehaviour
{
    // oluşturulma tarihi / creation date: 10.03.2026
    public float hiz = 3f; // speed
    public bool zipla = false; // jump
    public bool havadami = false; // in the air

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("Merhaba Berke"); // prints "Hello Berke" to the console
        transform.position = new Vector3(0, 0.8f, -4); // sets the initial position of the object to (0, 0.8, -4)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            hiz = 10f; // increases speed when Left Shift is held down
        }

        else
        {
            hiz = 3f; // resets speed to normal when Left Shift is released
        }

        // “Havada zıplama yok” kuralını koyuyor
        // tek bir tuşa basıldığında havaya kalkmasını sağlar havadayken tekrar basınca çalışmaz
        // allows the object to jump when the space key is pressed, but only if it is not already in the air
        if (transform.position.y <= 0.8f) // eğer y ekseninde 0.8'in altındaysa (yani yerdeyse)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                zipla = true;
            }
        }

        if (zipla)
        {
            transform.position += new Vector3(0, 3, 0) * hiz * Time.deltaTime;
            // havaya gelene kadar y ekseninde 3 birim yukarı hareket eder çünkü Time.deltaTime ile çarparak hareketi frame rate bağımsız hale getirir
            // moves the object upwards by 3 units per second until it reaches the air, making the movement frame rate independent by multiplying with Time.deltaTime
            if (transform.position.y >= 3) // eğer y ekseninde 3'ün üstüne çıkarsa (yani havadayken)
            {
                zipla = false; // jump
                havadami = true; // in the air
            }       
        }

        if (havadami)
        {           
            transform.position += new Vector3(0, -1, 0) * hiz * Time.deltaTime;
            if(transform.position.y <= 0)
            {
                // Y ekseninde 0'ın altına düşmesini engeller ve x z konumunu korur
                transform.position = new Vector3(transform.position.x, 0, transform.position.z); 
                havadami = false;            
            }
        }

        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, 0, 1) * hiz * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, 0, -1) * hiz * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0) * hiz * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-1, 0, 0) * hiz * Time.deltaTime;
            }
        }
    }
}
