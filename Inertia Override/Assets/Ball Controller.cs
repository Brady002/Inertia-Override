using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{

    public LayerMask Ground;
    public float playerHeight;
    public Rigidbody rb;
    public GameObject focalPoint;
    public float speed;
    private Vector2 forwardInput;
    [SerializeField]
    public float intertia = 1000f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        forwardInput = context.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        focalPoint.transform.position = rb.transform.position;
    }

    private void FixedUpdate()
    {
        rb.AddForce(focalPoint.transform.forward * speed * forwardInput.y);
        speed = Mathf.Lerp(2f * rb.mass, 12f * rb.mass, rb.velocity.magnitude / intertia);
    }

}
