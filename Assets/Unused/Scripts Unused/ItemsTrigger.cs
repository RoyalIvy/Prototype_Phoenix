using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsTrigger : MonoBehaviour
{
    [SerializeField] private Text textCoins;
    [SerializeField] private Text textDiamond;

    [SerializeField] private int coins;
    [SerializeField] private int diamond;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coins")
        {
            coins++;
            Destroy(other.gameObject);
            textCoins.text = coins.ToString();
        }

        if (other.gameObject.tag == "Diamond")
        {
            diamond++;
            Destroy(other.gameObject);
            textDiamond.text = diamond.ToString();
        }
    }
}
