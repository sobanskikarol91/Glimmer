using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] float speed = 5;

    private void Update()
    {
        transform.Translate(Vector3.down * speed*Time.deltaTime);    
    }
}
