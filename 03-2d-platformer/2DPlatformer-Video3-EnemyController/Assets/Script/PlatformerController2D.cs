using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController2D : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public bool grounded;
    public LayerMask groundLayers;
    public float groundRayLength = 0.1f;
    public float groundRaySpread = 0.1f;

    private Rigidbody2D rb2d;
    private float inputX;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

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

    bool UpdateGrounding()
    {
        Vector3 rayStart = transform.position + Vector3.up * groundRayLength;
        Vector3 rayStartLeft = transform.position + Vector3.up * groundRayLength + Vector3.left * groundRaySpread;
        Vector3 rayStartRight = transform.position + Vector3.up * groundRayLength + Vector3.right * groundRaySpread;

        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.down, groundRayLength * 2, groundLayers);
        RaycastHit2D hitLeft = Physics2D.Raycast(rayStartLeft, Vector2.down, groundRayLength * 2, groundLayers);
        RaycastHit2D hitRight = Physics2D.Raycast(rayStartRight, Vector2.down, groundRayLength * 2, groundLayers);

        Debug.DrawLine(rayStart, rayStart + Vector3.down * groundRayLength * 2, Color.red);
        Debug.DrawLine(rayStartLeft, rayStartLeft + Vector3.down * groundRayLength * 2, Color.red);
        Debug.DrawLine(rayStartRight, rayStartRight + Vector3.down * groundRayLength * 2, Color.red);

        if (hit.collider != null || hitLeft.collider != null || hitRight.collider != null) {
            grounded = true;
            return true;
        }
        grounded = false;
        return false;
    }
}
