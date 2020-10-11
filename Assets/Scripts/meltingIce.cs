using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meltingIce : MonoBehaviour
{
    public float timer;
    public float limitTimer;

    public GameObject gameObject;
    public Vector3 sink;
    public RebuiltIce rebuilt;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!rebuilt.goingUp)
        {
            timer += Time.deltaTime;

            if(timer >= limitTimer)
            {
                gameObject.transform.position += sink;
                //box2d.size += boxIncrease;
                timer = 0f;
                if(gameObject.transform.position.y <= -1)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
