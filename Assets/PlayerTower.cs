using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;

    void Start()
    {
        health = maxHealth;
    }
}
