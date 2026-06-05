using UnityEngine;

public class GameDirector_al3 : MonoBehaviour
{
    public silah silah_;
    public enemyManager enemymanager_;
    public Player player_;
    public OdulManager odulmanager_;

    public void RestartLevel() // Method to run when the player loses
    {
        enemymanager_.EnemySpawn(); // spawn enemies
        player_.spawnPlayer(); // spawn the player
        odulmanager_.BringAllRewards(); // make all rewards visible in the scene
        silah_.playerIsWin = true; // set playerIsWin in the silah script to true
    }
}
