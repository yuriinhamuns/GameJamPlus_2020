using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    public float speed = 10f;
    private float turnMoveTime = .1f;
    private float turnMoveVelocity;
    public float attackDuration = 0;
    private CharacterController controller;
    public GameObject hitbox;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(movement.x, 0f, movement.y);

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnMoveVelocity, turnMoveTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void OnJump()
    {
        Debug.Log("Jump");
    }

    void OnAttack()
    {
        Debug.Log("Attack");
    }

    void OnAction()
    {
        Debug.Log("Action");
    }
}
