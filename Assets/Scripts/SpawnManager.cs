using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ground;
    Transform playerTransform;
    float SpawnZ = 10.0f;
    float groundLength = -20f;
    int amnGround = 5;
    List<GameObject> ActiveGround;
    float SafeZone = 25f;
    public int coins;
    public Text coinText;

    void Start()
    {
        coinText.text = "" + coins;
        ActiveGround = new List<GameObject>();
        for (int i = 0; i < amnGround; i++)
        {
            SpawnGround();
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z + SafeZone < (SpawnZ - amnGround * groundLength))
        {
            SpawnGround();
            DeleteGround();
        }
    }

    void SpawnGround(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(ground) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * SpawnZ;
        SpawnZ += groundLength;
        ActiveGround.Add(go);
    }

    void DeleteGround()
    {
        Destroy(ActiveGround[0]);
        ActiveGround.RemoveAt(0);
    }

    public void AddCoins(int numOfCoins)
    {
        coins += numOfCoins;
        coinText.text = "" + coins;
    }
}
