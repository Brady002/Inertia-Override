using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    private float mouseX;
    private float mouseY;
    public Vector2 mouse;
    private float horizontalInput;
    public GameObject c;
    public GameObject centerpoint;

    public float sensitivityX = 1000f;
    public float sensitivityY = 1000f;

    private bool locked = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(CameraLockRelease());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouse = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if(!locked)
        {
            mouseX = mouse.x * Time.deltaTime * sensitivityX;
            mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;
            horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * sensitivityX;

            transform.Rotate(Vector3.up, mouseX);
            //transform.Rotate(Vector3.up, horizontalInput);
        }

    }

    private IEnumerator CameraLockRelease()
    {
        yield return new WaitForSeconds(20);
        c.transform.position = centerpoint.transform.position;
        c.transform.rotation = centerpoint.transform.rotation;
        locked = false;
    }

}
