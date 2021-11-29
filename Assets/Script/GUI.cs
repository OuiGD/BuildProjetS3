using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{

    public Image statBarPoid;
    public Image statBarCharge;
    public Image statBarVitesse;
    public GameObject carousel;

    private Vector3 InitPos;
    private Vector3 CurPos;
    private float distance;

    private float Poid;
    private float Dimention;
    private float Vitesse;
    private float Charge;
    private float Distance;

    // Start is called before the first frame update
    void Start()
    {
        Poid = 0f;
        Dimention = 0f;
        Vitesse = 0f;
        Charge = 0f;
        Distance = 0f;

        statBarPoid.fillAmount= Poid;
        statBarCharge.fillAmount = Charge;
        statBarVitesse.fillAmount = Vitesse;
    }

    public void SelectionWheel(float x, float Axis)
    {
        carousel.transform.Rotate(new Vector3(0, 0, 1), (Mathf.Sqrt(x)*-Axis));
    }

    public void BoutonTest()
    {
        Debug.Log("lllollll");
    }


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("1er click");
            InitPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("ça drag");
            CurPos = Input.mousePosition;
            distance = Vector3.Distance(CurPos, InitPos);
            SelectionWheel(distance, Input.GetAxisRaw("Mouse Y"));
        }
    }
}
