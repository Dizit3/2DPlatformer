using System.Diagnostics;
using UnityEngine;

public class Sword : Weapon
{

    public Sword(string name, int damage, float range, float speed)
    {
        Name = name;
        Damage = damage;
        Range = range;
        Speed = speed;
    }

    //public static Sword Instance;

    //public Sword GetSword(string name, int damage, float range, float speed)
    //{
    //    if (Instance == null) 
    //    return new Sword(name, damage, range, speed);

    //    return Instance;
    //}


    public override void Equip()
    {
        //Set parent ?
    }

    public override void Use()
    {
        UnityEngine.Debug.Log("ATTACK!!!");
        //Do some thing
    }
}