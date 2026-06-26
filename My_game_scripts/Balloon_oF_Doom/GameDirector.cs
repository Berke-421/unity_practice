using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public Player player; // player reference

    public Transform allCoin, allChest, friend1, friend2, sphere; // parent objects for all coins and chests, and references to friends and the sphere
    public Transform friendSpawnPoint1, friendSpawnPoint2; // spawn points for friends

    public void restartGame()
    {
        friend1.position = friendSpawnPoint1.position; // move friend 1 to spawn point
        friend2.position = friendSpawnPoint2.position; // move friend 2 to spawn point
        player.transform.position = player.spawnPoint.position; // move player to spawn point

        sphere.localScale = new Vector3(1, 1, 1); // reset sphere to default size

        for (int i = 0; i < allCoin.childCount; i++) // activate all coins
        {
            allCoin.GetChild(i).gameObject.SetActive(true);
        }

        for(int j = 0; j < allChest.childCount; j++) // activate all chests
        {
            allChest.GetChild(j).gameObject.SetActive(true);
        }
    }
}

