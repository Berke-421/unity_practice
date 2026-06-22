using UnityEngine;

public class Ship : MonoBehaviour
{
    // Stores the ship's target and the player reference
    public Transform target;
    public Player player;

    public float speed;

    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isGameEnd) // If the game has not ended, move the ship toward the target
        {
            transform.position = Vector3.MoveTowards( 

                transform.position,
                target.position,
                speed * Time.deltaTime
            );
        }

    }
}
