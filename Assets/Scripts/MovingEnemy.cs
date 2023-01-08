using UnityEngine;

public class MovingEnemy : Entity
{
    private int lives = 3;




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.onTouch.Invoke();
            GetDamage();
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
