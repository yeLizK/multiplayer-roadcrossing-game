using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private List<Transform> spawnPoints = new List<Transform>();

    private void Start()
    {
        int temp = Random.Range(0, spawnPoints.Count);
        Vector3 spawnPoint = spawnPoints[temp].position;

        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint, Quaternion.identity);
    }
}
