using UnityEngine;

public class GameController : MonoBehaviour
{

    private bool isPause = false;

    private void Start()
    {
        Hero.onTouch += Hero.Instance.GetDamage;

        //Equipment.onAttackButtonDown += Sword.Attack;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause) {
                Time.timeScale = 0f;
                isPause = true;
                return;
            }
            if (isPause){
                Time.timeScale = 1.0f;
                isPause = false;
                return;
            }

        }
    }


    private void OnDisable()
    {
        Hero.onTouch -= Hero.Instance.GetDamage;
    }



}
