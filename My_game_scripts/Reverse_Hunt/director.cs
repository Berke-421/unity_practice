using UnityEngine;

public class director : MonoBehaviour
{
    public EnemyManager_al4 enemyManager; // to manage enemies
    public Player_al4 player; // to change player and enemy speeds based on time cycle
    public TimeCycle cycle; // to track the time cycle
    void Start()
    {
        if (player == null)
            player = FindFirstObjectByType<Player_al4>();

        if (enemyManager == null)
            enemyManager = FindFirstObjectByType<EnemyManager_al4>();

        if (cycle == null)
            cycle = FindFirstObjectByType<TimeCycle>();

    }

    void Update()
    {
        if (cycle.morning) // if it's morning
        {
            player.speed = 4.5f;
            enemyManager.enemySpeedSlow(); // set slower enemy speed
            enemyManager.RunAway(); // enemies start running away
        }

        else // if it's night
        {
            player.speed = 5f;
            enemyManager.enemySpeedFast(); // set faster enemy speed
            enemyManager.Catch(); // enemies start chasing the player
        }

        if(enemyManager.enemies.Count == 0) // if all enemies have been destroyed
        {
            enemyManager.allEnemyDeath = true; // mark that all enemies are dead
            player.transform.position = player.winPoint.position; // teleport player to win point
        }
    }
}
