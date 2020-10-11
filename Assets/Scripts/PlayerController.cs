using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!");
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
