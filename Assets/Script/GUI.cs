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
    // Start is called before the first frame update
    void Start()
    {  
        statBar.fillAmount=0f;
    }
    private void OnMouseDown()
    {
        InitPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        float distance;
        CurPos = Input.mousePosition;
        distance = Vector3.Distance(CurPos, InitPos);
        SelectionWheel(distance, Input.GetAxisRaw("Mouse Y"));

    }

    public void SelectionWheel(float x, float Axis)
    {
        carousel.transform.Rotate(new Vector3(0, 0, 1), (Mathf.Sqrt(x)*-Axis));
        Debug.Log("on y est");
    }
}
