using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(CharacterController))]
public class CharController : MonoBehaviour
{
    private CharacterController charController;

    private Vector2 inputVector;
    private Vector3 movementVector;

    [SerializeField]
    private float charSpeed;

    private PhotonView photonView;
    private void Start()
    {
        charController = this.gameObject.GetComponent<CharacterController>();
        charSpeed = 8f;
        photonView = this.gameObject.GetComponent<PhotonView>();
    }

    private void Update()
    {
        if(photonView.IsMine)
        {
            inputVector = InputManager.Instance.GetPlayerInputs();
            movementVector = new Vector3(inputVector.x, transform.position.y, inputVector.y);
            movementVector = transform.forward * movementVector.z + transform.right * movementVector.x;
            charController.Move(movementVector * Time.deltaTime * charSpeed);
        }

    }
}
