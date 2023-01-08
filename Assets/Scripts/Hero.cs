using UnityEngine;

public sealed class Hero  :MonoBehaviour , IEntity
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    internal int lives = 5;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    public static Hero Instance { get; set; }


    private Hero() { }

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (isGrounded) State = States.idle;
        else State = States.jump;

        if (Instance != null)
        {
            if (Input.GetButton("Horizontal"))
                Run();

            if (Input.GetButtonDown("Jump") && isGrounded)
                Jump();

        }
    }



    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    public void GetDamage()
    {
        lives--;
        Debug.Log(lives);
    }



    private void Run()
    {
        if (isGrounded) State = States.run;


        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    public void Die()
    {
        Destroy(this.gameObject); 
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