using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float mouseSensitivity = 400f;

    private float mouseX;
    private float mouseY;

    public bool canRotate = true;

    private void OnEnable()
    {
        GameManager.Instance.onGameStart -= CanRotate;
        GameManager.Instance.onGameStart += CanRotate;

        GameManager.Instance.onGameOver -= CantRotate;
        GameManager.Instance.onGameOver += CantRotate;

    }

    private void OnDestroy()
    {
        GameManager.Instance.onGameStart -= CanRotate;
        GameManager.Instance.onGameOver -= CantRotate;
    }

    private void Update()
    {
        if (canRotate)
            Rotation();
    }

    public void CanRotate()
    {
        canRotate = true;
    }

    public void CantRotate()
    {
        canRotate = false;
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