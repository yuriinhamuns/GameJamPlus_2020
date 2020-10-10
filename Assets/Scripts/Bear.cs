using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
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
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnMoveVelocity, turnMoveTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
    private void Attack()
    {
        //inserir bottão de ataque
        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartCoroutine(ShowHitboxForSeconds(attackDuration));
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision entered");
        if (collision.gameObject.tag == "Enemy")
        {
            LoseHealth(1);
        }
        
    }
    
    IEnumerator ShowHitboxForSeconds(float time)
    {
        hitbox.SetActive(true);
        yield return new WaitForSeconds(time);
        hitbox.SetActive(false);
    }

    private void LoseHealth(int amount)
    {
        health -= amount;
    }


}

