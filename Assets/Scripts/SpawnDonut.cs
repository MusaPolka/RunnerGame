using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDonut : MonoBehaviour
{
    public GameObject player;
    public GameObject donut;
    float amnDonut = 2f;
    float SpawnZ = 10.0f;
    float donutLength = -20f;
    List<GameObject> ActiveDonut;
    float SafeZone = 25f;

    void Start()
    {
        ActiveDonut = new List<GameObject>();

        for (int i = 0; i < amnDonut; i++)
        {
            Spawn();

        }
    }

    void Update()
    {
        if (player.transform.position.z + SafeZone < (SpawnZ - amnDonut * donutLength))
        {
            Spawn();
            DeleteDonut();
            
        }
    }

    void Spawn(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(donut);
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(Random.Range(-5.5f, 9.5f), -1f, 1f * SpawnZ);
        SpawnZ += donutLength;
        ActiveDonut.Add(go);
        
    }

    void DeleteDonut()
    {
        Destroy(ActiveDonut[0]);
        ActiveDonut.RemoveAt(0);
    }
}
