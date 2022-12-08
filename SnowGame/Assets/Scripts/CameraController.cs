using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;

    [SerializeField] private float Y_Float;
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Vector3 newPosition = new Vector3(player.transform.position.x/2,(player.transform.position.y+Y_Float)/2,  offset.z + player.position.z);
        transform.position = newPosition;
    }
}
