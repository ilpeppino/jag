using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]

public class PlayerInput : MonoBehaviour
{
    #region Local variables

    private Vector3 input;
    private float speed = 100f;

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
        DetermineInput();
    }

    void FixedUpdate()
    {
        playerMovement.Move(input);
    }

    private void DetermineInput()
    {
        float xPos = -Input.GetAxis("Vertical");
        float zPos = Input.GetAxis("Horizontal");
        input = new Vector3(xPos, 0f, zPos).normalized;
    }
}
