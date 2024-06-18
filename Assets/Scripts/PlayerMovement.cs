
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
   [SerializeField] private LayerMask wallLayer;
   private float wallJumpCooldown;
   private float horizontalInput;
   
   
   private void Awake()
   {
       body = GetComponent<Rigidbody2D>();  // Grab references for rigidbody from object
       boxCollider = GetComponent<BoxCollider2D>();

   }

   private void Update()
   {
      horizontalInput = Input.GetAxis("Horizontal");
       

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
       
       //Wall jump

       if (wallJumpCooldown > 0.2f)
       {
           if (Input.GetKey(KeyCode.Space)) //player can only jump if grounded
           {
               Jump();
           }
           body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

           if (onWall() && !isGrounded())
           {
               body.gravityScale = 0;
               body.velocity = Vector2.zero;
           }
           else
           {
               body.gravityScale = 3;
           }
           if (Input.GetKey(KeyCode.Space)) //player can only jump if grounded
           {
               Jump();
           }
       }
       else
       {
           wallJumpCooldown += Time.deltaTime;
       }
   }

   private void Jump()
   {
       if (isGrounded())
       {
           body.velocity = new Vector2(body.velocity.x, jumpheight);
       }
       else if (onWall() && !isGrounded())
       {
           if (horizontalInput == 0)
           {
               body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 12, 0);
               transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y,
                   transform.localScale.z);
           }
           else
           {
               body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 2, 6);
           }
           wallJumpCooldown = 0;
           body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 2, 6); // track the direction the player is facing and create a force opposite to it
       }                                                                                // 2 is the power the player gets pushed away and 6 is the power that pushes up

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
   
   private bool onWall()
   {
       RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,
           new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);

       return raycastHit.collider != null;
   }
}
