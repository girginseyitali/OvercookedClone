using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotationSpeed = 5f;

    private bool isWalking;
    
    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
        
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1f;
        }if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1f;
        }if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1f;
        }if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1f;
        }

        inputVector = inputVector.normalized;

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
