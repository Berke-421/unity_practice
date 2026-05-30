using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class enemyManagers : MonoBehaviour
{
    public oyuncu o;
    public GameObject enemy; // enemy prefabs should be assigned to this variable. this object already contains enemy_ component
    public Transform[] levels; // for all levels
    public List<enemy_> enemies; // to collect enemies into a single list
    public int enemyCount;

    void Start()
    {
        if (o == null)
            o = FindFirstObjectByType<oyuncu>();

        enemy.transform.position = new Vector3(0, 0, 0);

        enemies = new List<enemy_>();
    }

    public void createEnemy(int a)
    {
        for(int i = 0; i < enemyCount; i++)
        {
            // 1. Get the room's world center position
            Vector3 spawnPosition = levels[a].transform.position;

            // 2. Calculate a random offset left/right and forward/back equal to half the room's size
            // (If scale is 10, pick between -5 and +5 so it stays inside the room)
            float xOffset = Random.Range(-levels[a].transform.localScale.x / 2f, levels[a].transform.localScale.x / 2f);
            float zOffset = Random.Range(-levels[a].transform.localScale.z / 2f, levels[a].transform.localScale.z / 2f);

            // 3. Add the calculated random offsets to the room's actual position
            spawnPosition.x += xOffset;
            spawnPosition.y += 1.0f; // spawn 1 unit above the room floor
            spawnPosition.z += zOffset;

            // 4. Use temporary 'newEnemy' variable to avoid modifying the prefab reference
            GameObject newEnemy = Instantiate(enemy, spawnPosition, levels[a].transform.rotation);

            // 5. Add to list and set parent
            enemies.Add(newEnemy.GetComponent<enemy_>());
            newEnemy.transform.SetParent(transform);
        }
    }
}
