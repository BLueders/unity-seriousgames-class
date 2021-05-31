using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5;
    public Transform[] patrolPoints;
    [HideInInspector] public Rigidbody2D rb2d;
    private Vector3[] patrolPositions;
    private int nextIndex = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        patrolPositions = new Vector3[patrolPoints.Length];
        for(int i = 0; i < patrolPoints.Length; i++)
        {
            patrolPositions[i] = patrolPoints[i].position;
            Destroy(patrolPoints[i].gameObject);
        }
    }

    void Update()
    {
        Vector2 toTarget = patrolPositions[nextIndex] - transform.position;
        if (toTarget.magnitude <= speed * Time.fixedDeltaTime)
        {
            nextIndex++;
            nextIndex %= patrolPositions.Length;
        }
        if (toTarget.magnitude > 1)
        {
            toTarget.Normalize();
        }
        rb2d.velocity = toTarget * speed;
    }

    private void OnDrawGizmos()
    {
        if (patrolPoints.Length < 2) return;

        Color startColor = new Color(0.1f, 0.2f, 0.5f);
        Color endColor = new Color(0.5f, 0.6f, 1f);
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            Gizmos.color = Color.Lerp(startColor, endColor, i / (float)patrolPoints.Length);
            Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[(i + 1) % patrolPoints.Length].position);
            Gizmos.DrawWireSphere(patrolPoints[i].position,0.5f);
        }
    }
}
