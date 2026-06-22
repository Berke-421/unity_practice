using UnityEngine;

public class GameDirector : MonoBehaviour
{
    // Holds references to the objects we want to access
    public ClownManager clowManager;
    public Player player;
    public Ship ship;
    public Clown clown;

    public Transform playerWinPoint, shipWinPoint; // Points where player and ship will go when winning

    public GameObject cameraScare, cameraLose; // Cameras that will be active when losing

    public bool jumpScare, loseScreen; // Booleans to track whether the scare and lose cameras are active when losing
    public float time; // Float storing time passed after the jump scare becomes active
    public void Start()
    {       
        cameraScare.SetActive(false); // Disable the jump scare camera at game start
        cameraLose.SetActive(false); // Disable the lose camera at game start

        jumpScare = false; // Jump scare not active at game start
        loseScreen = false; // Lose screen not active at game start

        time = 0f;
    }

    public void win() // Actions to perform when winning
    {
        ship.transform.position = shipWinPoint.position; // Move the ship to its win position

        player.rb.isKinematic = true; // Stop the player's physics movement
        player.transform.position = playerWinPoint.position; // Move the player to its win position
        player.animator.SetTrigger("dance"); // Trigger the player's dance animation

        clown.agent.enabled = false;
        clown.rb.useGravity = false;
        clown.rb.isKinematic = true;
    }

    public void lose() // Actions to perform when losing
    {
        clowManager.destroyEnemies(); // Destroy enemies when losing
        player.rb.isKinematic = true; // Stop the player's physics movement

        jumpScare = true; // Activates jump scare when losing; Update will handle behavior based on this bool
    }

    public void lose2() // Actions to perform when falling into the sea
    {
        player.rb.isKinematic = true;
        clowManager.destroyEnemies();
        player.cameraSetting.gameObject.SetActive(false); // Disable the player's camera

        cameraLose.SetActive(true); // Enable the lose camera; Update will handle behavior based on this bool
    }

    public void Update()
    {
        if (jumpScare) // Actions to perform when jump scare is active
        {
            time += Time.deltaTime;
            player.cameraSetting.gameObject.SetActive(false); // Disable the player's camera

            cameraScare.SetActive(true); // Enable the jump scare camera

            if (time >= 1f) // When 1 second has passed
            {
                jumpScare = false; // Disable the jump scare
                loseScreen = true; // Activate the lose screen
            }
        }

        if (loseScreen) // Actions to perform when the lose screen is active
        {
            cameraScare.SetActive(false); // Disable the jump scare camera
            cameraLose.SetActive(true); // Enable the lose camera
        }
    }
}
