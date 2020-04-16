using UnityEngine;
using UnityEngine.Events;
public class Bird : MonoBehaviour
{
    [SerializeField] private float velocityForce = 1.5f;
    private Rigidbody2D birdRigidbody2D;
    public UnityEvent onGameOver = null;
    private ushort score;
    private Vector2 startPos;
    
    [SerializeField] private UnityEngine.UI.Text scoreText = null;

    private void Awake()
    {
        startPos = transform.position;
        birdRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        transform.position = startPos;
        score = 0;
        scoreText.text = score.ToString();
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        birdRigidbody2D.velocity = Vector2.up * velocityForce;
    }

    private Pipe pipe;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Pipe")) return;
        Debug.Log("Lost");
        onGameOver.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("ScorePipe")) return;
        Debug.Log("Score: " + score.ToString());
        ++score;
        scoreText.text = score.ToString();
    }
}