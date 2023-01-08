using UnityEngine;

public class GameController : MonoBehaviour
{

    private void Start()
    {
        Hero.onTouch += Hero.Instance.GetDamage;
    }

    private void OnDisable()
    {
        Hero.onTouch -= Hero.Instance.GetDamage;
    }
}
