using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArrowController : MonoBehaviour
{
    public Rigidbody2D MyRigidbody2D;
    public SpriteRenderer myspriteRenderer;
    public float OffsetMultiplier;
    private ArrowType myArrowType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch (Vector3 offset)
    {
        MyRigidbody2D.AddForce (-offset * OffsetMultiplier,ForceMode2D.Impulse);
    }
    public void Setup(ArrowType arrowType)
    {
        myArrowType = arrowType;
        if (arrowType == ArrowType.normal)
        { 
        myspriteRenderer.color = Color.black;
        }
        if (arrowType == ArrowType.explosive)
        {
            myspriteRenderer.color = Color.red;
        }
        if (arrowType == ArrowType.poison)
        {
            myspriteRenderer.color = Color.green;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            var enemy = collision.gameObject.GetComponent<EnemyController>();
            DoSpecialEffects(enemy);
            Destroy(gameObject);
        }
    }

    private void DoSpecialEffects(EnemyController enemy )
    {
        if (myArrowType == ArrowType.normal)
        {
            enemy.TakeDamage(50); 
        }
        if (myArrowType == ArrowType.explosive)
        {
            var Enemys = FindObjectsOfType<EnemyController>();
            var EnemysInRange = Enemys.Where(e => Vector3.Distance(e.transform.position, transform.position) < 5);
            foreach (var Enemy in EnemysInRange) 
            {
                Enemy.TakeDamage(50); 
            } 
        }
        if (myArrowType == ArrowType.poison)
        {
            enemy.Poison();
        }
    }
}
