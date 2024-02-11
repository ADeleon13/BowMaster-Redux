using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
