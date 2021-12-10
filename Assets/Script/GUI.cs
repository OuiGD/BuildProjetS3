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
    private float Portance;
    private float Puissance;

    const float FACTOR_POID = 1.40f;
    const float FACTOR_PUISSANCE = 0.10f;
    const float FACTOR_PORTANCE = 0.25f;

    public float POID_MAX;
    public float CHARGE_MAX;
    public float VITESSE_MAX;


    // Start is called before the first frame update
    void Start()
    {
        Poid = 0f;
        Dimention = 0f;
        Vitesse = 0f;
        Charge = 0f;
        Distance = 0f;
        Portance = 0f;
        Puissance = 0f;

        POID_MAX = Mission.Objectif_poid;
        CHARGE_MAX = Mission.Objectif_Charge;
        VITESSE_MAX = Mission.Objectif_Vitesse;

        statBarPoid.fillAmount = Poid;
        statBarCharge.fillAmount = Charge;
        statBarVitesse.fillAmount = Vitesse;

        Debug.Log("poid max: "+POID_MAX);
        Debug.Log("charge max: "+CHARGE_MAX);
        Debug.Log("vitesse max: "+VITESSE_MAX);
        Debug.Log("************************");
    }

    public void SelectionWheel(float x, float Axis)
    {
        carousel.transform.Rotate(new Vector3(0, 0, 1), ((Mathf.Sqrt(x) * -Axis)/2));
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

        Poid = Poid * 0.1f;
        Vitesse = (Puissance - Poid) * (Portance * Mathf.Pow(FACTOR_PORTANCE, 2));
        Charge = (Portance * FACTOR_PORTANCE) + (Puissance * FACTOR_PUISSANCE) - (Poid * FACTOR_POID);

        Debug.Log("vitesse actuel: " + Vitesse);
        Debug.Log("charge actuel: " + Charge);
        Debug.Log("************************");

        statBarPoid.fillAmount = Poid / (POID_MAX*0.1f);
        statBarVitesse.fillAmount = Vitesse / VITESSE_MAX;
        statBarCharge.fillAmount = Charge / CHARGE_MAX;
    }

    //cette fonction valide les missions
    public void Bouton_validation(float mission_poid, bool poid_greater_than, float mission_charge, bool charge_greater_than, float vitesse_max, bool vitesse_greater_than)
    {

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
