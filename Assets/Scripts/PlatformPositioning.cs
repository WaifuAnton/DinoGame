using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPositioning : MonoBehaviour
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
            transform.position = new Vector3(transform.position.x + 150, transform.position.y, transform.position.z);
    }
}
