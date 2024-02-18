using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public float CoinValue;
    public Text CoinText;
    
    
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        CoinText.text = CoinValue.ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin5"))
        {
            CoinValue = CoinValue + 5;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Coin25"))
        {
            CoinValue = CoinValue + 25;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Coin100"))
        {
            CoinValue = CoinValue + 100;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Coin500"))
        {
            CoinValue = CoinValue + 500;
            Destroy(collision.gameObject);
        }
       
        
    }
}
