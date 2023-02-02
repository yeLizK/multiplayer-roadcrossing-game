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
        if(photonView.IsMine&&GameManager.Instance.isGameOn)
        {
            inputVector = InputManager.Instance.GetPlayerInputs();
            movementVector = new Vector3(inputVector.x, 10f, inputVector.y);
            movementVector = transform.forward * movementVector.z + transform.right * movementVector.x;
            charController.Move(movementVector * Time.deltaTime * charSpeed);
            transform.position = new Vector3(transform.position.x,1f,transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            GameManager.Instance.Win();
        }
    }
}
