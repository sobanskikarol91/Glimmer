using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    public delegate void State();
    public static State OnTapStart, OnTapEnd;
    public static State OnCollision;


    private void Update()
    {
        CheckTapStart();
        CheckTapEnd();
    }

    private void CheckTapStart()
    {
        if (Input.GetMouseButtonDown(0))
            OnTapStart();
    }

    private void CheckTapEnd()
    {
        if (Input.GetMouseButtonUp(0))
            OnTapEnd();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollision();
    }
}
