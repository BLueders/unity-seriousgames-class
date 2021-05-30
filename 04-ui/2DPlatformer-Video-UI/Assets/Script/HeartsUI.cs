using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    private static HeartsUI instance;
    public Image[] hearts;
    private int heartsVisible;

    void Start()
    {
        instance = this;
        heartsVisible = hearts.Length;
    }

    public static void RemoveHeart()
    {
        instance.heartsVisible--;
        if(instance.heartsVisible >= 0) {
            instance.hearts[instance.heartsVisible].enabled = false;
        }
    }
}
