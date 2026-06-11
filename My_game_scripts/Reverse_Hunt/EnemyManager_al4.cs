using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyManager_al4 : MonoBehaviour
{
    public GameObject enemy;

    public List<Enemy_al4> enemies = new List<Enemy_al4>();
    public Player_al4 player;
    public TimeCycle cycle;

    public Transform Place;
    public Transform[] EnemyPoints; // points where enemies will be spawned

    public float time;
    public bool allEnemyDeath; // whether all enemies are dead
    void CreateEnemy()
    {
        int point_number = Random.Range(0, 3); // choose a random number between 0 and 2 (3 is excluded) because EnemyPoints has 3 points

        GameObject newEnemy = 
            Instantiate(enemy, EnemyPoints[point_number].position, EnemyPoints[point_number].rotation); // instantiate enemy prefab at the randomly chosen point

        enemies.Add(newEnemy.GetComponent<Enemy_al4>()); // add the spawned enemy to the enemy list

        newEnemy.transform.SetParent(transform); // set the spawned enemy's parent to EnemyManager to keep hierarchy organized
    }

    public void Catch()
    {
        foreach(var e in enemies)
        {
            e.catchPlayer();
        }
    }

    public void RunAway()
    {
        foreach(var e in enemies)
        {
            e.runAway();
        }
    }

    public void DestroyEnemy(Collision col) // function to destroy the enemy that collided with the player
    {
        Enemy_al4 enemy = col.gameObject.GetComponent<Enemy_al4>(); // get the Enemy_al4 component from the collided object to identify the enemy
        enemies.Remove(enemy); // remove the collided enemy from the enemy list to update it
        Destroy(enemy.gameObject); 
    }
    public void enemySpeedFast()
    {
        foreach(var e in enemies)
        {
            e.agent.speed = 4f;
        }
    }

    public void enemySpeedSlow()
    {
        foreach (var e in enemies)
        {
            e.agent.speed = 2f;
        }
    }
    void Start()
    {
        allEnemyDeath = false;

        Debug.Log($"düşman sayısı: {enemies.Count}");
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count <= 8 && !allEnemyDeath && cycle.morning) // if enemy count is 8 or less, not all enemies are dead, and it's morning, create a new enemy
        {
            time += Time.deltaTime;

            if(time >= 14f)
            {
                Debug.Log("Düşman oluştu");
                CreateEnemy();
                time = 0;
            }
        }

        if (enemies.Count == 0) // if enemy count is zero, meaning all enemies are dead
            allEnemyDeath = true; // mark that all enemies are dead
    }
}
