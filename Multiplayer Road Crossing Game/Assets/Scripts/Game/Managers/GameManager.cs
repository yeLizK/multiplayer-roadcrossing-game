using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject WinPanel, LosePanel;
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public bool isGameOn;
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(_instance);
        else _instance = this;
    }
    private void Start()
    {
        isGameOn = true;
    }
    private void Update()
    {
        if(InputManager.Instance.EscapeButtonInfo())
        {
            BackToLobby();
        }
    }

    public void GameOver()
    {
        LosePanel.SetActive(true);
        isGameOn = false;
    }

    public void Win()
    {
        WinPanel.SetActive(true);
        isGameOn = false;
    }

    public void BackToLobby()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        LobbyManager.Instance.LeaveRoom();

    }

}
