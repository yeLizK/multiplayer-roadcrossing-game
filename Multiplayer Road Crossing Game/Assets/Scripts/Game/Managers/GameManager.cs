using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    private void Update()
    {
        if(InputManager.Instance.EscapeButtonInfo())
        {
            LobbyManager.Instance.LeaveRoom();
        }
    }

}
