using UnityEngine;
using System.Collections;

public class StartPoint: MonoBehaviour
{
    public Transform startPoint;
    public GameObject player;
    void Start()
    {
        player = GetComponent<GameObject>();
        Instantiate(player, new Vector3(this.transform.position.x, this.transform.position.z, this.transform.position.y), Quaternion.identity);
    }


    public void Reset()
    {
        player.transform.position = startPoint.position;
    }
}