using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10.0f;
    public float Jumpforce;
    private Vector3 scale;
    Rigidbody rb;

    public float playerHeight;
    public LayerMask ground;
    bool grounded;
    public float groundDrag;


    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
         rb =  GetComponent<Rigidbody>();
         rb.freezeRotation = true;
         
    }

    private void MyInput(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
    }

    private void MovePlayer() {
        moveDirection= transform.forward * verticalInput + transform.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        SpeedControl();

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f+0.2f, ground);
        Debug.DrawRay(transform.position, Vector3.down, Color.yellow, playerHeight * 0.5f+0.2f);
        if(grounded){
            Debug.Log("Grounded");
            rb.drag=groundDrag;
            
            if (Input.GetKeyDown(KeyCode.Space)){
                Debug.Log("Space is pressed");
                rb.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
            }
            

        }
        else {
            rb.drag=0;
        }
    }

    void FixedUpdate() {
        // Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // rb.MovePosition(transform.position + (m_Input).normalized * Time.deltaTime * speed);
        MovePlayer();


    }

    private void SpeedControl(){
        Vector3 flatVel = new Vector3(rb.velocity.x,0f,rb.velocity.z);
        if(flatVel.magnitude > speed) {
            Vector3 limitedVel = flatVel.normalized*speed;
            rb.velocity = new Vector3(limitedVel.x,rb.velocity.y,limitedVel.z);

        }

    }
}
