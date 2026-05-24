using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class enemies : MonoBehaviour
{
    public List<enemy_mini> enemy; // list of mini-enemy instances (assign in Inspector)
    public player p; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void startLevel1() // Activate the first enemy for level 
    {
        enemy[0].active_ = true;
    }
    public void startlevel2() // Configure enemies for level 2
    {
        enemy[0].active_ = false;
        enemy[1].active_ = true;
        enemy[2].active_ = true;
    }
    public void startlevel4()  // Configure enemies for level 4
    {
        enemy[1].active_ = false;
        enemy[2].active_ = false;
        enemy[3].active_ = true;
    }

    public void startFinal() // Final wave activation
    {
        enemy[3].active_ = false;
        enemy[4].active_ = true;
    }

    public void Win() // Disable all enemy GameObjects (used when player wins)
    {
        foreach(var e in enemy) { e.gameObject.SetActive(false); }
    }

    void Start()
    {
        foreach(var e in enemy) { e.active_ = false; }
        if (p == null)
            p = FindAnyObjectByType<player>();
    }
}
