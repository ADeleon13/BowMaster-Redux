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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "arrow"){
            currentHealth -= 50;

            Destroy(collision.gameObject);

            if(currentHealth <= 0){
                Destroy(gameObject);
            }
        }
    }
}
