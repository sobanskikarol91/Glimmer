using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TouchDamage : Health
{
    [SerializeField] float decreaseHealthSpeed = 1;

    private PlayerJump player;

    protected override void DestroyEffect()
    {
        Destroy(gameObject);
        player.UnStick();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        currentHelath -= decreaseHealthSpeed * Time.deltaTime;

        player = collision.GetComponent<PlayerJump>();
        Debug.Log(currentHelath);

        if (IsDeath())
            DestroyEffect();
    }
}
