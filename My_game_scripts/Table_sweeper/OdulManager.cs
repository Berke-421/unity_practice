using NUnit.Framework;
using UnityEngine;

// odul means reward
public class OdulManager : MonoBehaviour
{
    public silah silah_; // Reference to access the 'silah' (weapon) script.

    public enemyManager enemymanager; // Reference to access the enemyManager script.

    public GameObject[] rewards; // Array that will hold all rewards.


    public int rewardCollected, total; // rewardCollected = number of collected rewards, total = total number of rewards
    void Start()
    {
        rewardCollected = 0; // Initially, the number of collected rewards is 0.

        rewards = GameObject.FindGameObjectsWithTag("odul"); // Find all rewards in the scene and assign them to the rewards array. All GameObjects tagged "odul" will be added to this array.

        total = rewards.Length; // Assign the length of the rewards array to total. This represents the total number of rewards in the scene.


        if (silah_ == null) // If silah_ reference is not assigned, find a GameObject with the 'silah' script in the scene and assign it.
            silah_ = FindFirstObjectByType<silah>();

        if (enemymanager == null) // If enemymanager reference is not assigned, find a GameObject with the enemyManager script in the scene and assign it.
            enemymanager = FindFirstObjectByType<enemyManager>();
    }

    public void BringAllRewards()
    {
        foreach(var r in rewards) { r.SetActive(true); } // Activate each reward GameObject in the rewards array. This makes the rewards visible in the scene.
    }

    // Update is called once per frame
    void Update()
    {
        if(rewardCollected == total) // If rewardCollected equals total, the player has collected all rewards.
        {
            silah_.playerIsWin = true; // Set playerIsWin in the silah script to true to indicate the player has won. This can be used in the silah script to check the win state.
            enemymanager.destroyEnemies(); // Call destroyEnemies() on enemymanager to destroy all enemies in the scene. This ensures enemies are removed when the player wins.
        }
    }
}
