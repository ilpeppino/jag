using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]

public class PlayerInput : MonoBehaviour
{
    #region Local variables

    private Vector3 input;

    #endregion

    #region Cached references

    private PlayerMovement playerMovement;

    #endregion

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMovement.Move(input);
    }

}
