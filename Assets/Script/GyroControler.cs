using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControler : MonoBehaviour
{
    public GameObject target;
    public GameObject Maincamera;

    private Vector3 InitPos;
    private Vector3 CurPos;
    private float distance;

    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion init;

    private float angle;

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

            //Debug.Log("init: "+init);

            return false;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled)
        {
            angle = gyro.attitude.eulerAngles.x - init.eulerAngles.x;

            if (angle > 20)
            {
                Maincamera.transform.RotateAround(target.transform.position, Vector3.up, 10 * Time.deltaTime);
            }
            else if (angle < -20)
            {
                Maincamera.transform.RotateAround(target.transform.position, Vector3.up, 10 * Time.deltaTime);
            }

            /*if (gyro.attitude.eulerAngles.z - init.eulerAngles.z > 30)
            {
                Maincamera.transform.RotateAround(target.transform.position, Vector3.right, 10 * Time.deltaTime);
            }
            else if (gyro.attitude.eulerAngles.z - init.eulerAngles.z < -30)
            {
                Maincamera.transform.RotateAround(target.transform.position, Vector3.left, 10 * Time.deltaTime);
            }*/
          
            //Debug.Log(init);
            //Debug.Log(init.eulerAngles);
            //Debug.Log("angle cam" + (gyro.attitude.eulerAngles.x - init.eulerAngles.x));
            //Debug.Log("angle cam" + gyro.attitude.w);
            //Debug.Log("angle init"+init.eulerAngles.x);
            //Debug.Log("angle init" + init.eulerAngles);
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("1er click");
                InitPos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                //Debug.Log("on drag");
                CurPos = Input.mousePosition;
                distance = Vector3.Distance(CurPos, InitPos);
                Maincamera.transform.RotateAround(target.transform.position, Vector3.up, ((Mathf.Sqrt(distance) * Input.GetAxisRaw("Mouse X")) / 2));
            } 
        }
    }
}

