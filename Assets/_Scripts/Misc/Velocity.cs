using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
