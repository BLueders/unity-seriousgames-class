using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingController2D : CharacterController2D
{
    public Transform patrolPoint1;
    public Transform patrolPoint2;

    private Vector3 target;

    private void Start()
    {
        target = patrolPoint1.position;
    }

    void Update()
    {
        UpdateGrounding();

        if(Mathf.Abs(transform.position.x - target.x) < 0.1f){
            if(target == patrolPoint1.position) {
                target = patrolPoint2.position;
            } else {
                target = patrolPoint1.position;
            }
        }

        Vector3 direction = target - transform.position;
        Vector2 vel = rb2d.velocity;
        vel.x = Mathf.Sign(direction.x) * speed;
        rb2d.velocity = vel;

    }
}
