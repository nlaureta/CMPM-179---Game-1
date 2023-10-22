using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    private float spawnRate = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            InvokeRepeating("EnemySpawner", 0.5f, spawnRate);
            Destroy(gameObject,5);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void EnemySpawner(){
        Instantiate(enemy,enemyPos.position, enemyPos.rotation);
    }
}
