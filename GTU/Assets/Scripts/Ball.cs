using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float force;

    private Vector3 dragEnd, dragStart;
    private Rigidbody2D rb;
    private bool isGlued;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        InputHandler.OnTapEnd += TapEnd;
        InputHandler.OnTapStart += TapStart;
    }

    void TapEnd()
    {
        dragEnd = GetMousePosition();
        rb.bodyType = RigidbodyType2D.Dynamic;
        AddForce();
    }

    void TapStart()
    {
        dragStart = GetMousePosition();
    }

    void AddForce()
    {
        Vector3 direction = dragEnd - dragStart;
        rb.AddForce(-direction * force, ForceMode2D.Impulse);
    }

    void GlueObject()
    {
        isGlued = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGlued = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isGlued)
        {
            isGlued = true;
            GlueObject();
        }
    }

    Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
