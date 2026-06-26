using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;

    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("chest"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Sphere"))
        {
            gameDirector.restartGame();
        }
    }
}
