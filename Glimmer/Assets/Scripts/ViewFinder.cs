using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFinder : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] float speed;
    
    public void Update()
    {
        transform.RotateAround(origin.position, new Vector3(0, 0, 1), Time.deltaTime * speed);
    }
}


