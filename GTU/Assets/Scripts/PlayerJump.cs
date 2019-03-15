using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float minJumpDistance = 2f;
    [SerializeField] float maxJumpDisntance = 4.5f;
    [SerializeField] GameObject effect;
    [SerializeField] Transform jumpPoint;

    private Vector3 dragEnd, dragStart;
    private Rigidbody2D rb;
    private bool isGlued;
    private AudioSource audioSource;
    private int jumpAmount;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        InputHandler.OnTapStart += GetStartPosition;
        InputHandler.OnTapEnd += Jump;
        InputHandler.OnCollision += GlueObject;
        InputHandler.OnCollision += ResetJumpAmountAfterCollision;
    }

    void ResetJumpAmountAfterCollision()
    {
        jumpAmount = 0;
    }

    void Jump()
    {
        Debug.Log(jumpAmount);
        //jumpAmount++;
        //if (IsDoubleJumpUsed()) return;

        CreateEffect();
        rb.velocity = Vector3.zero;
        dragEnd = GetMousePosition();
        rb.bodyType = RigidbodyType2D.Dynamic;
        AddJumpForce();
    }

    private void CreateEffect()
    {
        Instantiate(effect, jumpPoint.position, Quaternion.identity);
    }

    void GetStartPosition()
    {
        dragStart = GetMousePosition();
    }

    void AddJumpForce()
    {
        Vector2 direction = (dragEnd - dragStart) * force;
        direction = direction.ClampMagnitudeMinMax(minJumpDistance, maxJumpDisntance);
        audioSource.Play();
        rb.AddForce(-direction, ForceMode2D.Impulse);
    }

    void GlueObject()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector3.zero;
    }

    public void UnStick()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    bool IsDoubleJumpUsed() { return jumpAmount > 4; } 
}
