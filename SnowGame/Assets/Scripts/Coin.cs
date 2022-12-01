using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0,40*Time.deltaTime,0);
    }
}
