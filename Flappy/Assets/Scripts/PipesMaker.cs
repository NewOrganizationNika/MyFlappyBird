using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PipesMaker : MonoBehaviour
{
    [SerializeField] private float number = 1, distance = 1;

    [SerializeField] private Transform pipeParent = null;
    [SerializeField] private GameObject pipePrefab = null;
    [SerializeField] private Bird bird = null;

    public void Start()
    {
        for (short i = 0; i < number; ++i)
        {
            var pipe = Instantiate(pipePrefab, pipeParent.transform);
            pipe.transform.position = new Vector2(pipeParent.transform.position.x + distance * i,
                Random.Range(Pipe.Min, Pipe.Max));
            bird.onGameOver.AddListener(pipe.GetComponent<Pipe>().StartPosition);
        }
    }
}