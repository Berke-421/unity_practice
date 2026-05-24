using Unity.Mathematics;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    // level transforms (assign specific level objects in the Inspector)
    public Transform level2, level3, player;

    // button flags to control movement/rotation
    public bool button2, button3;

    void Start()
    {
        if (level2 == null)
            level2 = GetComponent<Transform>();
        if (level3 == null)
            level3 = GetComponent<Transform>();
        if (player == null)
            player = GetComponent<Transform>();

        button2 = button3 = false;
    }


    public void getDown() // Move level2 down while button2 is true and above lower bound
    {
        if (button2 && level2.transform.position.y >= 25.4f)
            level2.transform.position += Vector3.down * 2f * Time.deltaTime;
    }

    public void goUp() // Move level2 up when button2 is false and below upper bound
    {
        if (!button2 && level2.transform.position.y <= 32.75f)
            level2.transform.position += Vector3.up * 2f * Time.deltaTime;
    }

    public void rotate() // Rotate level3 towards a target rotation while button3 is true
    {
        if (button3)
        {
            Quaternion targetRot = Quaternion.Euler(0, 90, -180);

            level3.rotation = Quaternion.RotateTowards(
                level3.rotation,
                targetRot,
                60f * Time.deltaTime
            );
        }
    }

    public void spawnPoint() // Teleport player to a spawn point
    {
        player.transform.position = new Vector3(10f, 28.76f, -140.49f);
    }

    public void Update() // Called every frame: apply movement/rotation logic
    {
        getDown(); goUp(); rotate();
    }
}
