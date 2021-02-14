using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    
    private Rigidbody2D myRigidBody;

    public bool isGrounded;
    public LayerMask whatIsGround; 
    
    private Collider2D myCollider;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myRigidBody.velocity = new Vector2(moveSpeed,myRigidBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            myRigidBody.velocity += new Vector2(myRigidBody.velocity.x,jumpForce);
        }
        myAnimator.SetFloat("Speed",myRigidBody.velocity.x);
        myAnimator.SetBool("Grounded",isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name == "BottomBoundary"){
            Destroy(gameObject);
        }
    }
}
