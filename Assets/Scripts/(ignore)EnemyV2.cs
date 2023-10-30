using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyV2 : MonoBehaviour
{
    [SerializeField] private Transform player;
    public NavMeshAgent agent;

    [Space]

    public float moveSpeed;
    public bool playerInSightRange;
    public float sightRadius;



    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
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
