using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 300f; //controls mouse sensitivity
    public Transform playerBody;
    float xRotation = 0;

    //Start is called before the first frame update
    private void Start() {
        CameraLockData.setLock(true); //locks cursor so it doesn't go out of the screen
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0 , 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
