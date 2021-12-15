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

    public Text valPoid;
    public Text valVitesse;
    public Text valCharge;

    private Vector3 InitPos;
    private Vector3 CurPos;
    private float distance;

    public float Poid = 0f;
    private float PoidRatio = 0f;
    private float Dimention = 0f;
    public float Vitesse =0f;
    public float Charge = 0f;
    private float Distance = 0f;
    private float Portance = 0f;
    private float Puissance = 0f;

    const float FACTOR_POID = 1.40f;
    const float FACTOR_PUISSANCE = 0.10f;
    const float FACTOR_PORTANCE = 0.25f;

    public float POID_MAX;
    public float CHARGE_MAX;
    public float VITESSE_MAX;


    // Start is called before the first frame update
    void Start()
    {
        PoidRatio = 0f;

        POID_MAX = Mission.Objectif_poid;
        CHARGE_MAX = Mission.Objectif_Charge;
        VITESSE_MAX = Mission.Objectif_Vitesse;

        statBarPoid.fillAmount = PoidRatio;
        statBarCharge.fillAmount = Charge;
        statBarVitesse.fillAmount = Vitesse;

        Debug.Log("poid max: " + POID_MAX);
        Debug.Log("charge max: " + CHARGE_MAX);
        Debug.Log("vitesse max: " + VITESSE_MAX);
        Debug.Log("************************");
    }

    public void SelectionWheel(float x, float Axis)
    {
        carousel.transform.Rotate(new Vector3(0, 0, 1), ((Mathf.Sqrt(x) * -Axis) / 2));
    }

    public void StatsBarUpdate(GridObject objAjout)
    {
        Puissance += (float)objAjout.Puissance;
        Portance += (float)objAjout.Portance;
        Poid += (float)objAjout.Poid;

        Debug.Log("puissance actuel: " + Puissance);
        Debug.Log("portance actuel: " + Portance);
        Debug.Log("poid actuel: " + Poid);
        Debug.Log("************************");

        PoidRatio = Poid * 0.001f;
        Vitesse = (Puissance - PoidRatio) * (Portance * Mathf.Pow(FACTOR_PORTANCE, 2)) * 10;
        Charge = (Portance * FACTOR_PORTANCE) + (Puissance * FACTOR_PUISSANCE) - (PoidRatio * FACTOR_POID);

        Debug.Log("vitesse actuel: " + Vitesse);
        Debug.Log("charge actuel: " + Charge);
        Debug.Log("************************");

        valPoid.text = Poid.ToString("0");
        valCharge.text = Charge.ToString("0");
        valVitesse.text = Vitesse.ToString("0");

        statBarPoid.fillAmount = Poid / POID_MAX;
        statBarVitesse.fillAmount = Vitesse / VITESSE_MAX;
        statBarCharge.fillAmount = Charge / CHARGE_MAX;
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
            //Debug.Log("�a drag");
            CurPos = Input.mousePosition;
            distance = Vector3.Distance(CurPos, InitPos);
            SelectionWheel(distance, Input.GetAxisRaw("Mouse Y"));
        }
    }
}
