using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 10;
    Rigidbody2D rb2d;
    Vector2 move, jump;
    RaycastHit2D[] hitBuffer = new RaycastHit2D[1];
    //Collider2D collider;
    const float minMoveDistance = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        move = new Vector2(speed, 0);
        jump = new Vector2(0, jumpForce);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.Cast(Vector2.down, hitBuffer);
        float distance = hitBuffer[0].distance;
        if (distance < minMoveDistance)
        {
            rb2d.gravityScale = 0;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb2d.gravityScale = 1;
                rb2d.AddForce(jump, ForceMode2D.Impulse);
            }
            rb2d.AddForce(move, ForceMode2D.Force);
        }
        else
            rb2d.gravityScale = 1;
    }
}
