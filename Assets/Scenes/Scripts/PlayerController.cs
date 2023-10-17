using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
 

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; 
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    private bool onGround = true;
    //public float raycastDistance = 0.6f;

    public float maxSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
          count = 0; 
        rb = GetComponent <Rigidbody>() ; 
        SetCountText();
    }

    void OnMove (InputValue movementValue)
   {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y; 
   }

        void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
   }


    private void FixedUpdate() 
   {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 
   }

     void OnTriggerEnter(Collider other) 
   {

     count = count + 1;
     if (other.gameObject.CompareTag("PickUp")) 
       {
          SetCountText();
          other.gameObject.SetActive(false);
       } 

     if(other.gameObject.CompareTag("foot")) {
          Debug.Log("On Ground");
          onGround = true; 
     } 
   }

   void OnCollisionEnter (Collision other) {
     //if (other.gameObject.CompareTag("foot")) {
          Debug.Log("2");
          onGround = true;

     //}
   }

   void OnCollisionExit (Collision other) {
     //if (other.gameObject.CompareTag("foot")) {
          Debug.Log("1");
          onGround = false; 
    // }
   }



     void OnJump() {
          
          //rb.velcoity = new Vector3(0,5,0);
          if(onGround) {
              Debug.Log("Jumped");
              rb.velocity = new Vector3(0,10,0);
          } else {
               Debug.Log("Nah");
          }

     }

     private void Update() {
     //      RaycastHit hit;
     //      if(Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, groundLayer)) {
     //           isGrounded = true;
     //           Debug.Log("raycast1");
     //      } else {
     //           isGrounded = false; 
     //           Debug.Log("raycast2");
     //      }

          Debug.Log(rb.velocity.magnitude);
         if(rb.velocity.magnitude > maxSpeed) {
               rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
         }      

     }
   

}
