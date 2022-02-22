using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSmoothTime = 0.2f;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private Transform cameraTransform;

    private float turnSmoothVelocity;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0f, vertical * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -vertical * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0f, 0f, -horizontal * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0f, 0f, horizontal * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0f, verticalSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0f, -verticalSpeed * Time.deltaTime, 0f);
        }
    }
}
