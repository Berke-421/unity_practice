using UnityEngine;

public class pinpon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // target positions and speed
    public Vector3 target1, target2;
    public float speed;

    // ulastiMi: whether it has reached the target and should switch direction
    // calisirMi: whether the movement is enabled (e.g., controlled by a button)
    public bool ulastiMi, calisirMi;
    void Start()
    {
        speed = 10f;

        // hedef ile başladığı nokta arasında gidip geleceği nokta
        target1 = new Vector3(-20f, transform.position.y, transform.position.z); // hedef
        target2 = new Vector3(18f, transform.position.y, transform.position.z); // başladığı nokta
        ulastiMi = false;
        calisirMi = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (calisirMi) // run only when enabled
        {
            if (!ulastiMi)
            {
                // move toward target1
                transform.position = Vector3.MoveTowards(

                    transform.position,
                    target1,
                    speed * Time.deltaTime
                );

                // Note: exact Vector3 equality can be brittle due to floating point precision,
                // but acceptable here for simple endpoints.
                if (transform.position == target1)
                    ulastiMi = true;
            }

            if (ulastiMi)
            {
                // move back toward target2
                transform.position = Vector3.MoveTowards(

                     transform.position,
                     target2,
                     speed * Time.deltaTime
                );

                if (transform.position == target2)
                    ulastiMi = false;
            }
        }
    }
}
