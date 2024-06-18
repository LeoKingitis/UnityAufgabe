
using System;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   private Rigidbody2D body;  // create a reference to the player Rigidbody2D
   [SerializeField] private float speed;
   [SerializeField] private float jumpheight;
   private BoxCollider2D boxCollider;
   [SerializeField] private LayerMask groundLayer;
   
   
   private void Awake()
   {
       body = GetComponent<Rigidbody2D>();  // Grab references for rigidbody from object
       boxCollider = GetComponent<BoxCollider2D>();

   }

   private void Update()
   {
       float horizontalInput = Input.GetAxis("Horizontal");
       body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

       /*
       
       // flip player when moving left/right
       
       if (horizontalInput > 0.01f)             //animation
       {
           transform.localScale = Vector3.one;
       }

        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

       */
       
       if (Input.GetKey(KeyCode.Space) && isGrounded()) //player can only jump if grounded
       {
           Jump();
       }
       
       
   }

   private void Jump()
   {
       body.velocity = new Vector2(body.velocity.x, jumpheight);
       

   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
        
   }

   private bool isGrounded()
   {
       RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down,
           0.1f, groundLayer);

       return raycastHit.collider != null;  // if nothing is under the player the collider will be = null
                                            // isGrounded will be false
                                            // if the plyer is on the ground the collider will not be null
   }
}
