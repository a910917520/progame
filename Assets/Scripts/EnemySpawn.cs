using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy1;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnEnemy", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        Instantiate(Enemy1, transform.position, Quaternion.identity);
    }
}
