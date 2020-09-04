using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public int respawnTime = 5;

    private void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;

        Invoke("Respawning", respawnTime);
    }

    void Respawning()
    {
        this.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<MeshRenderer>().enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
