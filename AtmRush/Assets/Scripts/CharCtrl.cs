using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCtrl : MonoBehaviour
{
    private Animator anim;
    private Vector3 firstTouchPosition;
    private Vector3 curTouchPosition;
    [SerializeField] private float sensitivityMultiplier = 0.01f; 
    private float finalTouchX;
    private float xBound = 4f;
    private bool canMove = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (canMove && GameManager.insance.isGameStart)
        {
            Move();
        }  
    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            curTouchPosition = Input.mousePosition;

            Vector2 touchDelta = (curTouchPosition - firstTouchPosition);

            finalTouchX = (transform.position.x + (touchDelta.x * sensitivityMultiplier));
            finalTouchX = Mathf.Clamp(finalTouchX, -xBound, xBound);

            transform.position = new Vector3(finalTouchX, transform.position.y, transform.position.z);

            firstTouchPosition = Input.mousePosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Conveyor"))
        {
            anim.SetTrigger("Idle");
            canMove = false;
            Forward.insance.speed = 0;
        }
    }
}
