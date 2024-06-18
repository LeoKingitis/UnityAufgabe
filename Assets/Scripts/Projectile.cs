using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float direction;
    private BoxCollider2D boxCollider; //reference for BoxXollider
    private float lifetime;
    
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;    // if projectile hits something rest of the code wont be executed
        {
            float movementSpeed = speed * Time.deltaTime * direction;
            transform.Translate(movementSpeed, 0 , 0);  // move the projectile on the x axis
        }
        lifetime += Time.deltaTime;
        if(lifetime > 2) gameObject.SetActive(false);    //time the projectile will be visible without hitting something
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;                         //if projectile hits something it will vanish
        boxCollider.enabled = false;        
        Deactivate();   
    }

    public void SetDirection(float _direction)      //tell the projectile to go left or right
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
        
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
            
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
}
