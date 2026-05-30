using UnityEngine;

public class door : MonoBehaviour
{
    public oyuncu p;
    public enemy_ e;
    public float speed;
    public bool yaklastiMi; // // Is the player close?

    void Start()
    {
        speed = 4f;
        if (p == null)
            p = GetComponent<oyuncu>();
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(p.transform.position, transform.position);
        float dist2 = Vector3.Distance(e.transform.position, transform.position);

        if (dist < 7f || dist2 < 7f) yaklastiMi = true; // Approached if distance is less than 7f
        else yaklastiMi = false; // Away if distance is greater than 7f

        if (yaklastiMi)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(transform.position.x, -2.65f, transform.position.z), // Upper limit for the door: -2.65f
                speed * Time.deltaTime
            );
        }

        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(transform.position.x, -6.16f, transform.position.z), // Lower limit for the door to reset: -6.16f
                speed * Time.deltaTime
            );
        }
    }
}
