using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebuiltIce : MonoBehaviour
{

    public GameObject gameObject;
    public Button rebuiltBtn;

    public float timer = 0f;
    public float limitTimer = 5f;
    public Vector3 upp;
    public bool goingUp;

    private void Awake()
    {
        goingUp = false;
    }
    void Start()
    {
        rebuiltBtn.onClick.AddListener(rebuiltPlatform);
        goingUp = false;
    }

    void Update()
    {
        if(goingUp)
        {
            timer += Time.deltaTime;
            if(timer >= limitTimer)
            {
                timer = 0f;
                gameObject.transform.position += upp;
                if(gameObject.transform.position.y >= 0)
                {
                    goingUp = false;
                }
            }
        }
    }

    void rebuiltPlatform()
    {
        //gameObject.transform.position = new Vector3Int(1,1,1);
        gameObject.SetActive(true);
        goingUp = true;
    }

}
