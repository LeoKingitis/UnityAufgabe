using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private float damage;
   public BoxCollider2D enemyBox;
   public SpriteRenderer enemySprite;
   
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.tag == "Player")
      {
         collision.GetComponent<Health>().TakeDamage(damage);
      }

      else if (collision.tag == "Projectile")
      {
         
      }
      

      
      
      
   }

   
}
