using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStones : MonoBehaviour
{
    public GameObject player;
    public GameObject[] Stones;
    float amnStones = 2f;
    float SpawnZ = 10f;
    float StoneLength = -20;
    float SafeZone = 25f;
    List<GameObject> ActiveStone;

    void Start()
    {
        ActiveStone = new List<GameObject>();

        for (int i = 0; i < amnStones; i++)
        {
            SpawnDonut();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z + SafeZone < (SpawnZ - amnStones * StoneLength))
        {
            SpawnDonut();
            DeleteStone();
        }
    }

    public void SpawnDonut(int prefabIndex = -1)
    {
        int RandomDonut = Random.Range(0, Stones.Length);
        GameObject go;
        go = Instantiate(Stones[RandomDonut]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(Random.Range(-5.5f, 9.5f), 0f, 1f * SpawnZ);
        SpawnZ += StoneLength;
        ActiveStone.Add(go);
    }

    void DeleteStone()
    {
        Destroy(ActiveStone[0]);
        ActiveStone.RemoveAt(0);
    }
}
