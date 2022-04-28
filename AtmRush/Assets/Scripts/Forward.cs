using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    public static Forward insance;

    public float speed;

    private void Awake()
    {
        insance = this;
    }

    private void FixedUpdate()
    {
        if (GameManager.insance.isGameStart)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }
    }
}
