using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    //public GameObject obj;
    private GameObject target;
    private Rigidbody rb;
    private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("Collided with player");
            SceneManager.LoadScene("Week2");
            //Destroy(other.gameObject);
        }
    }
}
