using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PaddleScript paddle;
    [SerializeField] Vector2 push = new Vector2(0, 20);
    [SerializeField] AudioClip[] ballSound;
    Rigidbody2D rb2d;
    Vector2 paddle_to_ball_vector;
    bool hasStarted = false;

    float initialMagnitude;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        paddle_to_ball_vector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBall();
            LaunchOnClickMouse();
        }
    }
    private void LaunchOnClickMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rb2d.velocity = new Vector2(push.x, push.y);
            initialMagnitude = rb2d.velocity.magnitude;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        rb2d.velocity = rb2d.velocity.normalized * initialMagnitude;
        if (hasStarted == true)
        {
            AudioClip clip = ballSound[UnityEngine.Random.Range(0, ballSound.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }

    private void LockBall()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddle_to_ball_vector + paddlePosition;
    }

}