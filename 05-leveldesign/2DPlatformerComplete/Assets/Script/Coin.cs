using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        Doorway door = FindObjectOfType<Doorway>();
        if(door!=null) door.RegisterCoin();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlatformerController2D controller = other.gameObject.GetComponent<PlatformerController2D>();
        if (controller != null) {
            controller.CollectCoin();
            Doorway door = FindObjectOfType<Doorway>();
            if (door!=null) door.CoinCollected();
            Destroy(gameObject);
        }
    }
}
