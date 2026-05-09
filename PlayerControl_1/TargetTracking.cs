using UnityEngine;
// Triggering enemy follow behavior when an object is collected.

public class enemy : MonoBehaviour
{
    public float speed = 3f;
    public control player;

    void Start()
    {
        if(player == null)
            player = FindFirstObjectByType<control>();
    }

    public void Update()
    {
        if (player.isAppleCollected)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.transform.position,
                speed * Time.deltaTime
            );
        }
    }
}
