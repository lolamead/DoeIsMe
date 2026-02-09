using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement2_5D : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float minY = -2f;
    public float maxY = 2f;

void LateUpdate()
{
    Vector3 pos = transform.position;
    pos.y = Mathf.Clamp(pos.y, minY, maxY);
    transform.position = pos;
}

    private CharacterController controller;
    private Vector3 moveDirection;

 
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D
        float vertical = Input.GetAxisRaw("Vertical");     // W/S

        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}

