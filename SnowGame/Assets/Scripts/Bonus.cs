using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    public Slider progressBarStarBonus;
    public Slider progressBarJumpBonus;

    public float jumpTime;
    private float jumpCurrentTime;

    public float starTime;
    private float starCurrentTime;

    bool isJumpBonus;
    bool isStar;


    private void Update()
    {
        StarActive();
        JumpBonusActive();
    }

    public void StarActive()
    {
        if (isStar == true)
        {
            starCurrentTime += Time.deltaTime;
            progressBarStarBonus.value -= Time.deltaTime;
            if (starCurrentTime >= starTime)
            {
                isStar = false;
                PlayerController.presentScore -= 2;
                starCurrentTime = 0;
                progressBarStarBonus.gameObject.SetActive(false);
            }
        }
    }

    public void BonusStar()
    {
        progressBarStarBonus.maxValue = starTime;
        progressBarStarBonus.value = starTime;
        isStar = true;
        progressBarStarBonus.gameObject.SetActive(true);
    }

    public void JumpBonusActive()
    {
        if(isJumpBonus == true)
        {
            jumpCurrentTime += Time.deltaTime;
            progressBarJumpBonus.value -= Time.deltaTime;
            if (jumpCurrentTime >= jumpTime)
            {
                isJumpBonus = false;
                PlayerController.JumpForce = 10;
                jumpCurrentTime = 0;
                progressBarJumpBonus.gameObject.SetActive(false);
            }
        }
    }

    public void JumpBonus()
    {
        progressBarJumpBonus.maxValue = jumpTime;
        progressBarJumpBonus.value = jumpTime;
        isJumpBonus = true;
        progressBarJumpBonus.gameObject.SetActive(true);
    }
}
