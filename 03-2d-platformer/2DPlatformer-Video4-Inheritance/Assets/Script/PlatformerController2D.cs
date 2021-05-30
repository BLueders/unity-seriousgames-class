using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController2D : Controller2D
{
    public float jumpforce;
    private float inputX;

    void Update()
    {
        inputX = Input.GetAxis("Horizontal") * speed;
        Vector2 vel = rb2d.velocity;
        vel.x = inputX;

        UpdateGrounding();

        bool inputJump = Input.GetKeyDown(KeyCode.Space);
        if (inputJump && grounded) {
            vel.y = jumpforce;
        }

        rb2d.velocity = vel;
    }
}
