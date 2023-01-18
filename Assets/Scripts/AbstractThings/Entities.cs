using UnityEngine;

public abstract class Entities : MonoBehaviour, IEntity
{

    public abstract void GetDamage();

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}

