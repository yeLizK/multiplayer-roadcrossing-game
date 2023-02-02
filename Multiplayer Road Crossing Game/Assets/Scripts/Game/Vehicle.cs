using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float speed;
    private PhotonView pv;
    private void Start()
    {
        speed = 2f;
        pv = this.gameObject.GetComponent<PhotonView>();
    }
    private void Update()
    {
        if(pv.IsRoomView)
        {
            if (this.gameObject.activeSelf == true)
            {
                transform.position += new Vector3(-2, 0, 0) * Time.deltaTime * speed;
            }

            if (this.transform.position.x <= -150f)
            {
                this.gameObject.SetActive(false);
            }
        }

    }
}
