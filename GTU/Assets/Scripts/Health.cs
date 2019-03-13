using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float maxhealth = 100;
    [SerializeField] protected float currentHelath;

    private void Start()
    {
        currentHelath = maxhealth;
    }

    protected bool IsDeath()
    {
        if(currentHelath <= 0)
        {
            currentHelath = 0;
            return true;
        }
        return false;
    }

    protected abstract void DestroyEffect();
}
