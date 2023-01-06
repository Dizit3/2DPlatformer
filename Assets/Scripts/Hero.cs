using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int lives = 5;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    private void Run()
    {
        if (isGrounded) State = States.run;


        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }


    private void Update()
    {

        if (isGrounded) State = States.idle;
        else State = States.jump;


        if (Input.GetButton("Horizontal"))
            Run();

        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
         isGrounded = true;
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}


public enum States
{
    idle,
    run,
    jump
}