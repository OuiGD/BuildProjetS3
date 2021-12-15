using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{

    public Image statBarPoid;
    public Image statBarCharge;
    public Image statBarVitesse;
    
    public Sprite BarRG;

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

        if (Mission.Excedant_poid)
        {
            statBarPoid.sprite = BarRG;
        }
        if (Mission.Excedant_Charge)
        {
            statBarCharge.sprite = BarRG;
        }
        if (Mission.Excedant_Vitesse)
        {
            statBarVitesse.sprite = BarRG;
        }

        statBarPoid.fillAmount = PoidRatio;
        statBarCharge.fillAmount = Charge;
        statBarVitesse.fillAmount = Vitesse;

        /*Debug.Log("poid max: " + POID_MAX);
        Debug.Log("charge max: " + CHARGE_MAX);
        Debug.Log("vitesse max: " + VITESSE_MAX);
        Debug.Log("************************");*/
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

        PoidRatio = Poid * 0.001f;
        Vitesse = (Puissance - PoidRatio) * (Portance * Mathf.Pow(FACTOR_PORTANCE, 2)) * 10;
        Charge = (Portance * FACTOR_PORTANCE) + (Puissance * FACTOR_PUISSANCE) - (PoidRatio * FACTOR_POID);

        valPoid.text = Poid.ToString("0");
        valCharge.text = Charge.ToString("0");
        valVitesse.text = Vitesse.ToString("0");

        if (Poid <= POID_MAX) { statBarPoid.fillAmount = Poid / POID_MAX; } else { statBarPoid.fillAmount = 1; }
        if (Vitesse <= VITESSE_MAX) { statBarVitesse.fillAmount = Vitesse / VITESSE_MAX; } else { statBarVitesse.fillAmount = 1; }
        if (Charge <= CHARGE_MAX) { statBarCharge.fillAmount = Charge / CHARGE_MAX; } else { statBarCharge.fillAmount = 1; }
    }


    private void Update()
    {
        print(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("1er click");
            InitPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && InitPos.x > 1800)
        {
            //Debug.Log("�a drag");
            CurPos = Input.mousePosition;
            distance = Vector3.Distance(CurPos, InitPos);
            SelectionWheel(distance, Input.GetAxisRaw("Mouse Y"));
        }
    }
}
