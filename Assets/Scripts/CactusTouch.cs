using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DinoMovement dino = collision.GetComponent<DinoMovement>();
        if (dino != null)
        {
            dino.enabled = false;
            Rigidbody2D rb2d = dino.GetComponent<Rigidbody2D>();
            rb2d.Sleep();
        }
    }
}
