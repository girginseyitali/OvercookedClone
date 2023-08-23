using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotationSpeed = 5f;

    [SerializeField] private GameInput _gameInput;

    private bool isWalking;
    
    private void Update()
    {
        Vector2 inputVector = _gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * (moveSpeed * Time.deltaTime);

        isWalking = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward ,moveDir, rotationSpeed * Time.deltaTime);
        
        //Debug.Log(inputVector);

    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
