using UnityEngine;

public abstract class Weapon : Equipment
{


    public override void Use()
    {
        Attack();
    }
    public abstract void Attack();


}