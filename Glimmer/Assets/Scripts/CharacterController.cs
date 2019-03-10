using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ViewFinder))]
public class CharacterController : MonoBehaviour
{
    ViewFinder viewFinder;

    private void Awake()
    {
        viewFinder = GetComponent<ViewFinder>();    
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //viewFinder.MoveCounterClockWise();
        }
    }
}
