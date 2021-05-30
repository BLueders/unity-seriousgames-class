using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController2D : MonoBehaviour
{
    public float speed;
    public float jumpforce;

    [Header("Grounding")]
    public LayerMask groundMask;
    public float groundRayLength = 0.1f;
    public float groundRaySpread = 0.1f;

    private Rigidbody2D rb2d;
    public bool grounded = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 vel = rb2d.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;

        UpdateGrounding();

        bool inputJump = Input.GetKeyDown(KeyCode.Space);
        if (inputJump && grounded) {
            vel.y = jumpforce;
        }

        rb2d.velocity = vel;
    }

    void UpdateGrounding()
    {
        Vector3 rayStart = transform.position + Vector3.up * groundRayLength;
        Vector3 rayStartLeft = transform.position + Vector3.up * groundRayLength + Vector3.left * groundRaySpread;
        Vector3 rayStartRight = transform.position + Vector3.up * groundRayLength + Vector3.right * groundRaySpread;

        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector3.down, groundRayLength * 2, groundMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(rayStartLeft, Vector3.down, groundRayLength * 2, groundMask);
        RaycastHit2D hitRight = Physics2D.Raycast(rayStartRight, Vector3.down, groundRayLength * 2, groundMask);

        Debug.DrawLine(rayStart, rayStart + Vector3.down * groundRayLength * 2, Color.red);
        Debug.DrawLine(rayStartLeft, rayStartLeft + Vector3.down * groundRayLength * 2, Color.red);
        Debug.DrawLine(rayStartRight, rayStartRight + Vector3.down * groundRayLength * 2, Color.red);

        if (hit.collider != null || hitLeft.collider != null || hitRight.collider != null) {
            grounded = true;
        } else {
            grounded = false;
        }
    }
}
