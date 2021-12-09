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

    public float POID_MAX = 100;
    public float CHARGE_MAX = 100;
    public float VITESSE_MAX = 100;


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

        statBarPoid.fillAmount = Poid;
        statBarCharge.fillAmount = Charge;
        statBarVitesse.fillAmount = Vitesse;
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
        Vitesse = (Puissance - Poid) * (Portance * Mathf.Pow(FACTOR_PORTANCE, 2));
        Charge = (Portance * FACTOR_PORTANCE) + (Puissance * FACTOR_PUISSANCE) - (Poid * FACTOR_POID);
        statBarPoid.fillAmount = Poid/ POID_MAX;
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
