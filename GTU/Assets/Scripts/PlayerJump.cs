using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float minJumpDistance = 2f;
    [SerializeField] float maxJumpDisntance = 4.5f;

    private Vector3 dragEnd, dragStart;
    private Rigidbody2D rb;
    private bool isGlued;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
        Vector2 direction = (dragEnd - dragStart)* force;
        direction = direction.ClampMagnitudeMinMax(minJumpDistance, maxJumpDisntance);
        audioSource.Play();
        rb.AddForce(-direction, ForceMode2D.Impulse);
    }

    void GlueObject()
    {
        isGlued = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector3.zero;
    }

  public  void UnStick()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGlued = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isGlued)
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
