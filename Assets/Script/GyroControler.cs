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

            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {       
        if (gyroEnabled)
        {
            target.transform.localRotation = gyro.attitude;
        }
        else
        {
            Maincamera.transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}

