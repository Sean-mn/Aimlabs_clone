using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float mouseSensitivity = 400f;

    private float mouseX;
    private float mouseY;

    private void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        mouseX = Mathf.Clamp(mouseX, -90f, 90f);
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(mouseY, mouseX, 0f);
    }
}
