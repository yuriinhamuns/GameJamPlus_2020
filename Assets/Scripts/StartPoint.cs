using UnityEngine;
using System.Collections;

public class StartPoint: MonoBehaviour
{
    public Transform startPoint;
    public GameObject player;
    void Start()
    {
        Instantiate(player, startPoint);
    }


    /*public void Reset()
    {
        player.transform.position = startPoint.position;
    }*/
}