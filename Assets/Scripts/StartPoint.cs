using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPoint: MonoBehaviour
{
    public Transform startPoint;
    public GameObject player;

    public Button resetBtn;
    void Start()
    {

        player = GetComponent<GameObject>();
        Instantiate(player, startPoint);

        resetBtn.onClick.AddListener(Reset);
    }


    public void Reset()
    {
        player.transform.position = startPoint.position;
    }
}