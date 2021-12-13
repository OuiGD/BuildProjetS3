using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControler : MonoBehaviour
{
    public GameObject target;
    public GameObject Maincamera;

    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion init;

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
            init = gyro.attitude;

            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled)
        {
            if (gyro.attitude.eulerAngles.x - init.eulerAngles.x > 30)
            {
                Maincamera.transform.RotateAround(target.transform.position, Vector3.up, 10 * Time.deltaTime);
            }
            else if (gyro.attitude.eulerAngles.x - init.eulerAngles.x < -30)
            {
                Maincamera.transform.RotateAround(target.transform.position, Vector3.down, 10 * Time.deltaTime);
            }
            if (gyro.attitude.eulerAngles.z - init.eulerAngles.z > 30)
            {
                Maincamera.transform.RotateAround(target.transform.position, Vector3.right, 10 * Time.deltaTime);
            }
            else if (gyro.attitude.eulerAngles.z - init.eulerAngles.z < -30)
            {
                Maincamera.transform.RotateAround(target.transform.position, Vector3.left, 10 * Time.deltaTime);
            }

        }else
        {
            Maincamera.transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}

