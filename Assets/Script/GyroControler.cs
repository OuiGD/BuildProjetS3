using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControler : MonoBehaviour
{
    public GameObject target;
    public GameObject Maincamera;

    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {       
        if (gyroEnabled)
        {
            target.transform.localRotation = gyro.attitude * rot;
        }
        else
        {
            Maincamera.transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}

/*

public class GyroControl : MonoBehaviour
    {
        private bool gyroEnabled;
        private Gyroscope gyro;

        private GameObject cameraContainer;
        private Quaternion rot;

        private void Start()
        {
            cameraContainer = new GameObject("Camera Container");
            cameraContainer.transform.position = transform.position;
            transform.SetParent(cameraContainer.transform);

            gyroEnabled = EnableGyro();
        }

        private bool EnableGyro()
        {
            if (SystemInfo.supportsGyroscope)
            {
                gyro = Input.gyro;
                gyro.enabled = true;

                cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
                rot = new Quaternion(0, 0, 1, 0);

                return true;
            }
            return false;
        }
        private void Update()
        {
            if (gyroEnabled)
            {
                transform.localRotation = gyro.attitude * rot;
            }
        }
    }
*/
