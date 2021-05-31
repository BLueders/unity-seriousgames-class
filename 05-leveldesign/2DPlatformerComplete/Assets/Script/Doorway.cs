using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlatformerController2D controller = collision.gameObject.GetComponent<PlatformerController2D>();
        if (controller != null) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
