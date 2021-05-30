using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlatformerController2D controller = other.gameObject.GetComponent<PlatformerController2D>();
        if (controller != null) {
            controller.CollectCoin();
            Destroy(gameObject);
        }
    }
}
