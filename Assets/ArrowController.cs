using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Rigidbody2D MyRigidbody2D;
    public float OffsetMultiplier;

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
}
