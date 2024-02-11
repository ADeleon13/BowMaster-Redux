using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerTower playerTower;
    public float moveSpeed;
    public float stopDistance;

    public float attackTimer; // how long its been since the last attack
    public float attackInterval = 1; // how long it should be between attacks
    public float damage;

    public float maxHealth;
    public float currentHealth;

    public float PoisonDamage;
    public float PoisonInterval;
    public float PoisonTimer;
    public int TimesPoisoned;
    public bool IsPoisoned; 

    public void Poison()
    { 
        IsPoisoned = true;
        PoisonTimer = 0;
        TimesPoisoned = 0;
    }

    void Start()
    {
        currentHealth = maxHealth;    
    }

    void Update()
    {
        Vector3 offsetToTower = playerTower.transform.position - transform.position;

        if(offsetToTower.magnitude > stopDistance){
            Vector3 movement = offsetToTower.normalized * moveSpeed * Time.deltaTime;
            Vector3 newPosition = transform.position + movement;
            transform.position = newPosition;
        }else{
            TryAttack();
        }

        CheckPoison();
        
    }

    private void CheckPoison()
    {
        if(!IsPoisoned){
            return;
        }

        PoisonTimer += Time.deltaTime;
        if (PoisonTimer >= PoisonInterval)
        {
            TakeDamage(PoisonDamage);
            PoisonTimer = 0;
            TimesPoisoned++;
        }

        if(TimesPoisoned >= 5){
            IsPoisoned = false;
        }
    }

    private void TryAttack()
    {
        attackTimer += Time.deltaTime;

        if(attackTimer > attackInterval){
            Attack();
            attackTimer = 0;
        }
    }

    private void Attack(){
        playerTower.health -= damage;
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;

        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }
}
