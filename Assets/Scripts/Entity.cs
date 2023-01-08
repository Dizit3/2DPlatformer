using UnityEngine;

public abstract class Entity : MonoBehaviour, IEntity
{

    public abstract void GetDamage();

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}

