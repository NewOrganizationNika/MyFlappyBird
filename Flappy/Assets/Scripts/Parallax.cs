#pragma warning disable CS0649
using UnityEngine;
using UnityEngine.Events;

public class Parallax : MonoBehaviour
{
    // private float length;
    // private Camera mainCamera;
    // [SerializeField] private float speed = 1;
    // private void Start()
    // {
    //     mainCamera = Camera.main;
    //     length = gameObject.GetComponentInChildren<SpriteRenderer>().size.x;
    // }

    [SerializeField] private float parallaxSpeed = 1;
    [SerializeField] private float startPosX = 1, lastPosX = 1;
    private Pipe pipe;


    private void Awake() => pipe = GetComponent<Pipe>();

    private void Update()
    {
        if (transform.position.x < lastPosX)
        {
            transform.position = Vector2.right * startPosX;
            if (pipe != null) pipe.ChangePlace();
        }

        transform.Translate(Vector2.left * (Time.deltaTime * parallaxSpeed));
    }
}