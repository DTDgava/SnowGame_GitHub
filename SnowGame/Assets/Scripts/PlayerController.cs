using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float gravity;

    [SerializeField] private Score scoreScrpt;
    [SerializeField] private int coins;

    private CapsuleCollider col;
    
    private int LineToMove = 1;
    public float LineDistance = 4;

    const float maxSpeed = 40;

    private Animator anim;

    public Text PresentText;

    private Bonus BonusScrpt;

    void Start()
    {
        BonusScrpt = GetComponent<Bonus>();
        col = GetComponent<CapsuleCollider>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        StartCoroutine(speedIncrease());
    }
    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }
    private void Update()
    {
        if(SwipeController.swipeRight)
        {
            if(LineToMove < 2)
            {
                LineToMove++;
            }
        }
        if(SwipeController.swipeLeft)
        {
            if(LineToMove > 0)
            {
                LineToMove--;
            }
        }
        if(SwipeController.swipeUp)
        {
            gravity = -20;
            if (controller.isGrounded)
            {
                Jump();
            }
        }
        if(SwipeController.swipeDown)
        {
            gravity = -50;
            StartCoroutine(Slide());
        }

        if(controller.isGrounded)
        {
            anim.SetTrigger("Running");
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(LineToMove == 0)
        {
            targetPosition += Vector3.left * LineDistance;
        }
        else if (LineToMove == 2)
        {
            targetPosition += Vector3.right * LineDistance;
        }
        if (transform.position == targetPosition)
        {
            return;
        }
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if(moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }
    }
    private void Jump()
    {
        dir.y = JumpForce;
        anim.SetTrigger("Jumping");
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Obstacle")
        {
            
            scoreScrpt.Die();
        }
    }
    IEnumerator speedIncrease()
    {
        yield return new WaitForSeconds(2);
        if (speed < maxSpeed)
        {
            speed += 1;
            StartCoroutine(speedIncrease());
            anim.SetFloat("Speed", speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Present")
        {
            Destroy(other.gameObject);
            coins++;
            PresentText.text = coins.ToString();
        }
    }
    private IEnumerator Slide()
    {
        col.center = new Vector3(0,-0.5f,0);
        col.height = 1f;
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1f;
        anim.SetTrigger("Sliding");
        yield return new WaitForSeconds(1);

        col.center = new Vector3(0, 0, 0);
        col.height = 2f;
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2f;
        anim.ResetTrigger("Sliding");
    }
  
}
