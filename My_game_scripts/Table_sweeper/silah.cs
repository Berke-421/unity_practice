using UnityEngine;
using UnityEngine.InputSystem;

// silah means wapon
// weapon script: allows the weapon to fire at enemies when the player is within a certain distance.
// Also checks the player's win state and disables firing / handles enemy destruction when the player wins.
public class silah : MonoBehaviour
{
    public Player player_; // reference to the Player script
    public Transform sensor; // sensor is a Transform used to detect the player's position. It can be placed on a surface to measure distance to the player.

    public float distance, time; // distance stores the distance between sensor and player. time tracks firing intervals.
    public bool playerIsWin; // playerIsWin tracks whether the player has won. Initially false; set to true when the player collects all rewards. This can be used to prevent firing when the player has won.

    public GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerIsWin = false; // initially the player has not won

        if (player_ == null)
            player_ = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(sensor.position, player_.rb.position); // assign the distance between the sensor and the player. Vector3.Distance calculates the distance between two points.

        if (distance <= 35f && !playerIsWin) // if the player is within 35 units and has not won, the weapon will start firing at enemies.
        {
            Vector3 dir = player_.transform.position - transform.position; // direction vector from weapon to player

            transform.rotation = Quaternion.LookRotation(dir); // rotate the weapon to look at the player

            time += Time.deltaTime; // accumulate elapsed time since last shot

            if (time >= 3) // every 3 seconds
            {
                time = 0; // reset timer
                Instantiate(bullet, transform.position, transform.rotation); // spawn a bullet at the weapon's position and rotation
            }
        }
    }
}
