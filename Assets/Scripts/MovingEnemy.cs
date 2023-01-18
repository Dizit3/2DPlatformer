using UnityEngine;

public class MovingEnemy : Entities
{
    private int lives = 3;

    private Vector3 direction = Vector3.right;
    //private float speed = 3.5f;

    private SpriteRenderer sprite;

    public Transform triangle;
    private Ray2D myRay;
    [SerializeField] private float rayDist;


    private void Update()
    {

        Move();
    }



    private void Move()
    {


        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {

            var hit = Physics2D.Raycast(new Vector2(triangle.position.x, triangle.position.y), Vector2.right, rayDist);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.tag);
                Debug.DrawRay(new Vector2(triangle.position.x, triangle.position.y), new Vector3(rayDist, 0), Color.black, 5f);

                if (direction == Vector3.right)
                {
                    direction = Vector3.left;
                }
                else
                {
                    direction = Vector3.right;
                }
                return;
            }

            if (collision.gameObject == Hero.Instance?.gameObject)
            {
                Hero.onTouch.Invoke();
                GetDamage();
            }

        }

    }


    public override void GetDamage()
    {
        lives--;

        Debug.Log("Enemy lives: " + lives);

        if (lives <= 0)
        {
            Die();
        }
    }
}
