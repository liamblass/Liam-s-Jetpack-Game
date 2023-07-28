using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCollectible : MonoBehaviour
{
    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.AddFuel();
            Destroy(gameObject);
        }
    }
}
