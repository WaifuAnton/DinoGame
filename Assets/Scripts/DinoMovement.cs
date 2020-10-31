using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    public float jumpForce = 10;
    public float speed = 10;
    public float maxSpeed = 30;
    Rigidbody2D rb2d;
    Vector2 move, jump;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        move = new Vector2(speed, 0);
        jump = new Vector2(0, jumpForce);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.IsTouchingLayers(LayerMask.GetMask("Platform")) && Input.GetKeyDown(KeyCode.UpArrow))
            rb2d.AddForce(jump, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        if (rb2d.velocity.x < maxSpeed && rb2d.IsTouchingLayers(LayerMask.GetMask("Platform")))
            rb2d.AddForce(move, ForceMode2D.Force);
    }
}
