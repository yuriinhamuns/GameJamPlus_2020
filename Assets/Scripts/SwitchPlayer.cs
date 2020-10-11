using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchPlayer : MonoBehaviour
{
    public GameObject player1, player2;
    private int whichPlayerIsOn = 1;
    bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isPressed)
        {
            SwitchPlayers();
            isPressed = false;
        }
    }

    void SwitchPlayers()
    {
        switch (whichPlayerIsOn)
        {
            case 1:
                whichPlayerIsOn = 2;

                player1.gameObject.SetActive(false);
                player2.gameObject.SetActive(true);
                break;

            case 2:
                whichPlayerIsOn = 1;

                player1.gameObject.SetActive(true);
                player2.gameObject.SetActive(false);
                break;
        }
    }

    void OnSwitchAvatar()
    {
        Debug.Log("SWITCH");
        isPressed = true;
    }
}
