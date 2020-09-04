using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlower : MonoBehaviour
{
    public GameObject flower;
    int spawnNum = 8;

    void Spawn()
    {
        for (int i = 0; i < spawnNum; i++)
        {
            Vector3 flowerPos = new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y + Random.Range(0.0f, 1.0f), this.transform.position.z + Random.Range(-1.0f, 1.0f));
            Instantiate(flower, flowerPos, Quaternion.identity);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
