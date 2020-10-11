using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float speed = 10f;
    private float turnMoveTime = .1f;
    private float turnMoveVelocity;
    private CharacterController controller;
    public GameObject hitbox;
    public GameObject dashHitbox;
    private bool slideEnabled = true;
    public float attackDuration = 0.2f;
    private float attackLag = 0f;
    private int health = 10;
    private bool isMovable = true;
    public GameObject penguim;
    private Animator anim;
    private bool isDashing = false;
    private float dashTime = -1;
    private float dashDuration = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = penguim.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        Slide();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude > 0.1f && isMovable)
        {
            anim.SetBool("running", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnMoveVelocity, turnMoveTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
        else
            anim.SetBool("running", false);
    }
    private void Attack()
    {
        //inserir bottão de ataque
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ShowHitboxForSeconds());
        }
    }

    private void Slide()
    {
        if (dashTime>=0)
        {
            controller.Move(transform.TransformDirection(Vector3.forward) * speed * 3 * Time.deltaTime);
            dashTime -= Time.deltaTime;
            Debug.Log(dashTime);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z) && slideEnabled)
            {
                isMovable = false;
                anim.SetBool("dashing", true);
                dashHitbox.SetActive(true);
                isDashing = true;
                dashTime = dashDuration;
                
            }
            else
            {
                isMovable = true;
                dashHitbox.SetActive(false);
                anim.SetBool("dashing", false);
            }
            


        }
        
    }

    IEnumerator DashHelper()
    {        
        //transform.TransformDirection(Vector3.forward)*moveSpeed
        yield return new WaitForSeconds(1);
        isMovable = true;
        anim.SetBool("dashing", false);
    }

    IEnumerator DashCounter()
    {
        yield return new WaitForSeconds(1);
        isDashing = false;

    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision entered");
        if (collision.gameObject.tag == "Enemy")
        {
            LoseHealth(1);
        }
        
    }
    
    IEnumerator ShowHitboxForSeconds()
    {
        //yield return new WaitForSeconds(attackLag);
        //isMovable = false;
        anim.SetTrigger("attack");
        speed /= 3;
        hitbox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        hitbox.SetActive(false);
        //isMovable = true;
        speed *= 3;
    }


}

