using System.Diagnostics;
using UnityEngine;

public class Sword : Weapon
{


    public string Name { get; set; }
    public  int Damage { get; set; }
    public  float Range { get; set; }
    public  float Speed { get; set; }

    public override void Equip()
    {
        //Set parent ?
    }

    public static void Attack()
    {
        UnityEngine.Debug.Log("ATTACK!!!");
        //Do some thing
    }
}