using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemystruct : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D enemybody;
    [SerializeField] private float speed = 0.003f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
        void Update()
        {
            transform.position = Vector3.MoveTowards
            (transform.position, 
            player.transform.position,
             speed);

       float direction = player.transform.position.x - transform.position.x;

        if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
    }
