using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] float speed = 1;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            //if(collision.tag == "Player")
            
    }
}
