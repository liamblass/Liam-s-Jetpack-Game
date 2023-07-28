using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shreder : MonoBehaviour
{
    public static event Action onObjactDestroid;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);

        onObjactDestroid?.Invoke();
    }
}
