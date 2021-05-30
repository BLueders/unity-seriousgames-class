using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlatformerController2D : Controller2D
{
    public float jumpforce;
    public int lives = 5;
    private float inputX;
    private SpriteRenderer sRenderer;
    private bool invulnerable = false;

    public override void Start()
    {
        base.Start();
        sRenderer = GetComponent<SpriteRenderer>();
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

    protected override void Hurt(Vector3 impactDirection)
    {
        if (Mathf.Abs(impactDirection.x) > Mathf.Abs(impactDirection.y)) {
            TakeDamage();
        } else {
            if(impactDirection.y > 0.0f) {
                TakeDamage();
            }
            Vector2 vel = rb2d.velocity;
            vel.y = jumpforce;
            rb2d.velocity = vel;
        }
    }

    void TakeDamage()
    {
        if (invulnerable) {
            return;
        }
        lives--;
        if(lives <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        StartCoroutine(Invulnerability(1));
    }

    IEnumerator Invulnerability(float time)
    {
        invulnerable = true;
        for(int i = 0; i < time/0.2f; i++) {
            sRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
        invulnerable = false;
    }
}
