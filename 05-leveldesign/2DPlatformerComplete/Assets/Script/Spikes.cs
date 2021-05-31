using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D collision)
    {
        PlatformerController2D controller = collision.gameObject.GetComponent<PlatformerController2D>();
        if (controller != null) {
            controller.TakeDamage();
        }
    }
}
