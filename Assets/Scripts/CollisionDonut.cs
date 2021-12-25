using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDonut : MonoBehaviour
{

    SpawnManager gameSpawnManager;
    public int CoinValue;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameSpawnManager.AddCoins(CoinValue);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameSpawnManager = FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
