using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float TimeMultiplier;
    float CurrentTimeMultiplier;

    bool BonusActive;
    public void Multiplier()
    {
        Score.Multiplier = 2;
    }
}
