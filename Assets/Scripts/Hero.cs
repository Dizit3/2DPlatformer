using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class Hero : Entity
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    internal int lives = 5;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    public static Hero Instance { get; set; }

    public static Action onTouch;

    public List<Equipment> Inventory = new List<Equipment>();
    public int scrollCount = 0;
    public Equipment equipmentInMainHand;
    private bool isMainHandEmpty = true;

    private Hero() { }

    private void Awake()
    {
        Instance = this;
        //Instance.Inventory.Enqueue(null);
        //Instance.Inventory.Enqueue(new Sword("ShortSword", 5, .5f, .5f));

        Instance.Inventory.Add(new Sword("ShortSword", 5, .5f, .5f));
       

        //Instance.equipmentInMainHand = new Sword("ShortSword", 5, .5f, .5f);


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

        if (Input.GetMouseButtonDown(0)) MainEquipmentAction();

        if (Input.mouseScrollDelta.y > 0)
        {
            if (Inventory.Count > scrollCount && scrollCount >= 0)
            {
                if (Inventory.ElementAt(scrollCount) != null)
                {
                    equipmentInMainHand = Inventory.ElementAt(scrollCount);
                    isMainHandEmpty = false;
                    Debug.Log(equipmentInMainHand.Name);
                    scrollCount++;
                }

            }
            else
            {
                isMainHandEmpty = true;
                equipmentInMainHand = null;
                scrollCount = 0;
                Debug.Log("Main hand empty!!");
            }


        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            if (Inventory.Count > scrollCount && scrollCount >= 0)
            {
                if (Inventory.ElementAt(scrollCount) != null)
                {
                    equipmentInMainHand = Inventory.ElementAt(scrollCount);
                    isMainHandEmpty = false;
                    Debug.Log(equipmentInMainHand.Name);
                    scrollCount--;
                }

            }
            else
            {
                isMainHandEmpty = true;
                equipmentInMainHand = null;
                scrollCount = 0;
                Debug.Log("Main hand empty!!");
            }
        }
    }



    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
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


    public override void GetDamage()
    {
        lives--;

        Debug.Log(lives);

        if (lives <= 0)
        {
            Die();
        }
    }


    public override void Die()
    {

        Destroy(this.gameObject);

        Instance = null;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;

    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }



    public void MainEquipmentAction()
    {
        if (!isMainHandEmpty) equipmentInMainHand.Use();
    }

}


public enum States
{
    idle,
    run,
    jump
}