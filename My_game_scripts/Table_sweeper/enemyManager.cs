using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemyManager : MonoBehaviour
{
    public enemies_[] enemies2; // Reference to access the enemies_ script. enemies2 = enemies

    public Transform[] enemiesSpawnPoint; // enemiesSpawnPoint array holds spawn points for enemies. Each Transform represents a spawn point in the scene.
    
    public bool playerIsDead; // playerIsDead tracks whether the player is dead. Initially false; set to true when player dies.

    public GameDirector gamedirector; // gamedirector is a reference to the GameDirector script. GameDirector likely handles overall game management (e.g., enemy spawning).

    void Start()
    {
        playerIsDead = false; // Set playerIsDead to false to indicate the player is alive at start.
        i = 0;
    }

    public void destroyEnemies() // destroyEnemies() method disables all enemies in the scene by calling SetActive(false) on each enemy GameObject.
    {
        foreach(var e in enemies2)
        {
            e.gameObject.SetActive(false); // Disable each enemy GameObject so they become invisible in the scene.
        }
    }

    public void EnemySpawn() // EnemySpawn() moves enemies to their spawn points using NavMeshAgent.Warp(), which instantly teleports agents to the target position.
    {
        for (int i = 0; i < enemies2.Length; i++)
        {
            enemies2[i].agent.Warp(enemiesSpawnPoint[i].position); // Warp each enemy's NavMeshAgent to the corresponding spawn point. Each Transform in enemiesSpawnPoint represents a spawn location.
        }
    }
}
