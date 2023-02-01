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
        Vector3 spawnPoint = spawnPoints[0].position;
        spawnPoints.RemoveAt(0);

        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint, Quaternion.identity);
    }
}
