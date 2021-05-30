using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleClickerGame : MonoBehaviour
{
    float vitamins = 0;
    int lemons = 0;
    int berries = 0;

    public Text vitaminScoreText;
    public Text lemonNumberText;
    public Text berryNumberText;
    public Text berryPriceText;
    public Text lemonPriceText;

    public float berryVPS;
    public float lemonVPS;
    public int berryPrice;
    public int lemonPrice;

    private void Update()
    {
        vitamins += Time.deltaTime * (berryVPS * berries + lemonVPS * lemons);
        vitaminScoreText.text = ((int)vitamins).ToString("D5");
    }

    public void ClickApple()
    {
        vitamins++;
    }

    public void BuyBerry()
    {
        if(vitamins >= berryPrice) {
            vitamins -= berryPrice;
            berries++;
            berryPrice += berryPrice;
            berryNumberText.text = berries.ToString();
            berryPriceText.text = berryPrice.ToString();
        }
    }

    public void BuyLemon()
    {
        if (vitamins >= lemonPrice) {
            vitamins -= lemonPrice;
            lemons++;
            lemonPrice += lemonPrice;
            lemonNumberText.text = lemons.ToString();
            lemonPriceText.text = lemonPrice.ToString();
        }
    }
}
