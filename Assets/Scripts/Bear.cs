using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public float speed = 10f;
    private float turnMoveTime = .1f;
    private float turnMoveVelocity;
    public float attackDuration = 0;
    public bool hasSnowBall;
    private CharacterController controller;
    public GameObject hitbox;
    public int health;

    public GameObject bear;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        hasSnowBall = false;
        controller = GetComponent<CharacterController>();
        anim = bear.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(!hasSnowBall){
            PickUpSnow();
        }
        else{
            PlaceSnow();
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude > 0.1f)
        {
            anim.SetBool("bearRunning", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnMoveVelocity, turnMoveTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("bearRunning", false);
        }
    }
    private void PickUpSnow()
    {
        //inserir bottão de ataque
        if (Input.GetKeyDown(KeyCode.Space) && !hasSnowBall)
        {
            //anim.SetBool("bearHasSnowBall", true);
            Debug.Log("snow ball " + hasSnowBall.ToString());
            hasSnowBall = true;
            //StartCoroutine(ShowHitboxForSeconds(attackDuration));            
        }
    }

    private void PlaceSnow()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hasSnowBall)
        {
            //anim.SetBool("bearHasSnowBall", false);
            hasSnowBall = false;
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

