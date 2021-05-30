using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    public Image[] hearts;
    private int heartsVisible;
    private static HeartsUI instace;

    void Start()
    {
        instace = this;
        heartsVisible = hearts.Length;
    }

    public static void RemoveHeart()
    {
        instace._RemoveHeart();
    }

    private void _RemoveHeart()
    {
        heartsVisible--;
        if(heartsVisible >= 0) {
            hearts[heartsVisible].enabled = false;
        }
    }
}
