using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ClownManager : MonoBehaviour
{

    public List<Clown> clowns = new List<Clown>(); 

    public void cry() // Not used but added anyway :)
    {
        foreach (var c in clowns)
        {
            c.agent.speed = 0;
            c.animator.SetTrigger("cry"); 
        }
    }

    public void destroyEnemies() // Function that destroys enemies
    {
        foreach (var c in clowns)
        {
            c.gameObject.SetActive(false);
        }
    }
}
