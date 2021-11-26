using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{

    public Image statBar;
    public GameObject carousel;
    // Start is called before the first frame update
    void Start()
    {  
        statBar.fillAmount=0f;
    }

    public void SelectionWheel(float x, float Axis)
    {
        x = x * Axis;
        carousel.transform.Rotate(new Vector3(0, 0, 1), x);
    }
}
