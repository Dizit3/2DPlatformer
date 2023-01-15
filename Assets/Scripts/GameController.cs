using UnityEngine;

public class GameController : MonoBehaviour
{

    private void Start()
    {
        Hero.onTouch += Hero.Instance.GetDamage;
        Equipment.onAttackButtonDown += 
    }

    private void OnDisable()
    {
        Hero.onTouch -= Hero.Instance.GetDamage;
    }



}
