using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{

    public Image statBar;
    public GameObject carousel;

    private Vector3 InitPos;
    private Vector3 CurPos;
    private bool Open;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {  
        statBar.fillAmount=0f;
        Open = true;
    }
    

    /********old method Section de secour***********/
    /*private void OnMouseDown()
    {
        InitPos = Input.mousePosition;
    }*/

    /*private void OnMouseDrag()
    {
        float distance;
        CurPos = Input.mousePosition;
        distance = Vector3.Distance(CurPos, InitPos);
        SelectionWheel(distance, Input.GetAxisRaw("Mouse Y"));

    }*/
    /********************************************/

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

        if (Input.GetMouseButton(0))
        {
            if (Open) {
                //Debug.Log("1er click");
                InitPos = Input.mousePosition;
                Open = false;
            }
            else
            {
                //Debug.Log("ça drag");
                CurPos = Input.mousePosition;
                distance = Vector3.Distance(CurPos, InitPos);
                SelectionWheel(distance, Input.GetAxisRaw("Mouse Y"));
            }
            
        }

        if (Input.GetMouseButtonUp(0) && !Open)
        {
            Open = true;
        }
    }
}
