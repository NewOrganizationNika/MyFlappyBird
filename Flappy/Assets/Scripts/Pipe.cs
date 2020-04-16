using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Pipe : MonoBehaviour
{
    public const float Min = -2.5f, Max = 2.5f; //It is const so cant display in inspector for now I dont know how

    private float startPositionX;

    private void Start()
    {
        startPositionX = transform.position.x;
    }

    public void ChangePlace()
    {
        transform.position = new Vector2(transform.position.x, Random.Range(Min, Max));
    }

    public void StartPosition()
    {
        var transform1 = transform;
        transform1.position = new Vector2(startPositionX, transform1.position.y);
    }
}