using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    
    //Positions for patrol
    [SerializeField] private Transform[] idleTargetPositions;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float chaseDetectionDistance;

    private bool _isIdle = true;
    private bool _isChasing = false;

    private int _idleTargetIndex = 0;
    
    private void Start()
    {
        if (GetComponent<SphereCollider>() != null)
        {
            GetComponent<SphereCollider>().radius = chaseDetectionDistance;
        }
    }

    private void Update()
    {
        if (_isIdle)
        {
            CheckIdleTargetDistance();
            PatrolWhenIdle();
        }
        else if (_isChasing)
        {
            ChasePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Enters");
            _isIdle = false;
            _isChasing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Exits");
            _isIdle = true;
            _isChasing = false;
        }
    }

    private void PatrolWhenIdle()
    {
        Vector3 tempVector = idleTargetPositions[_idleTargetIndex].position;
        Vector3 targetPosition = new Vector3(tempVector.x, transform.position.y, tempVector.z);
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.LookAt(targetPosition);
    }

    private void CheckIdleTargetDistance()
    {
        if (Vector3.Distance(transform.position, idleTargetPositions[_idleTargetIndex].position) < 0.1f)
        {
            _idleTargetIndex++;
            if (_idleTargetIndex >= idleTargetPositions.Length)
            {
                _idleTargetIndex -= idleTargetPositions.Length;
            }
        }
    }

    private void ChasePlayer()
    {
        Vector3 tempVector = playerTransform.position;
        Vector3 targetPosition = new Vector3(tempVector.x, transform.position.y, tempVector.z);
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.LookAt(targetPosition);
    }
}
