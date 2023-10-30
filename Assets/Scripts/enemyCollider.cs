using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyCollider : MonoBehaviour
{
    public float sphereRadius;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.CheckSphere(transform.position, sphereRadius, enemyLayer, QueryTriggerInteraction.Ignore))
        {
            Debug.Log("Something in Here. Sphere Radius: " + sphereRadius);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }
}
