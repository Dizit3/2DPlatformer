using UnityEngine;

public class Obstacle : MonoBehaviour 
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();

            if (Hero.Instance.lives <= 0)
            {
                Hero.Instance.Die();
            }
        }
    }

    
}
