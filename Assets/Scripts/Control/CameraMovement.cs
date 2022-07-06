using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]
    Camera MainCamera;
    float Sensetivity;

    [SerializeField]
    float MaxSize;
    [SerializeField]
    float MinSize;

    [SerializeField]
    float MaxSensitivity;
    [SerializeField]
    float MinSensitivity;

    private void Start()
    {
        Sensetivity = Mathf.Lerp(MinSensitivity, MaxSensitivity, MainCamera.orthographicSize / MaxSize);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0f) {
            MainCamera.orthographicSize = Mathf.Clamp(MainCamera.orthographicSize + Input.GetAxis("Mouse ScrollWheel"), MinSize, MaxSize);
            Sensetivity = Mathf.Lerp(MinSensitivity, MaxSensitivity, MainCamera.orthographicSize / MaxSize);
        }
        if (Input.GetKey(KeyCode.Mouse1)) {
            Vector3 movement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            MainCamera.transform.position -= movement * Sensetivity;
        }
    }
}
