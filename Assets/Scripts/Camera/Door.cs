using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   [SerializeField] private Transform prevRoom;
   [SerializeField] private Transform nxtRoom;
   [SerializeField] private CameraController camera;     //CameraController reference

   private void OnTriggerEnter2D(Collider2D collision)     //detect collision with the player
   {
      if (collision.tag == "Player")       //check if the object collided with has the tag "Player"
      {
         if (collision.transform.position.x < transform.position.x)  //check from whitch direction the player is coming from, if x position is smaller then doors x position the player is coming from the left
         {
            camera.MoveRoom(nxtRoom);                                //move camera left/right
         }
         else
         {
            camera.MoveRoom(prevRoom);
         }
      }
   }
   
}
