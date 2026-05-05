using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vector3 a;
    public float speed;
    public Transform karakater;
    public bool ac;
    void Start()
    {
        ac = false;
        speed = 5f;
    }

    void acil()
    {       
        if (transform.position.x < 15)
            transform.position += Vector3.right * Time.deltaTime * speed;      
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, karakater.position) < 2f)
            ac = true;

        if (ac)
            acil();
    }
}
