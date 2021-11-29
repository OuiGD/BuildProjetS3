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

    //cette fonction valide les missions
    public void Bouton_validation(float mission_poid, bool poid_greater_than, float mission_charge, bool charge_greater_than, float vitesse_max, bool vitesse_greater_than)
    {
        //le jeu va v�rifier si le poid de l'avion correspond � la mission
        //ce "if" v�rifie si le joueur doit avoir une valeur plus petit ou plus grande.
        if(poid_greater_than)
        {
            //dans le cas ou le joueur ne doit pas d�passer un poid
            if (mission_poid > Poid)
            {
                Debug.Log("gagn�");
            }
            else
            {
                Debug.Log("perdu");
            }
        }
        else
        {
            //dans le cas ou le joueur doit exc�der un poid
            if (mission_poid < Poid)
            {
                Debug.Log("gagn�");
            }
            else
            {
                Debug.Log("perdu");
            }
        }

        //############

        //le jeu va v�rifier si la capacit� de charge de l'avion correspond � la mission
        //ce "if" v�rifie si le joueur doit avoir une valeur plus petit ou plus grande.
        if (charge_greater_than)
        {
            //dans le cas ou le joueur ne doit pas d�passer la capacit�
            if (mission_charge > Charge)
            {
                Debug.Log("gagn�");
            }
            else
            {
                Debug.Log("perdu");
            }
        }
        else
        {
            //dans le cas ou le joueur doit exc�der la capacit�
            if (mission_charge < Charge)
            {
                Debug.Log("gagn�");
            }
            else
            {
                Debug.Log("perdu");
            }
        }

        //############

        //le jeu va v�rifier si la vitesse de l'avion correspond � la mission
        //ce "if" v�rifie si le joueur doit avoir une valeur plus petit ou plus grande.
        if (vitesse_greater_than)
        {
            //dans le cas ou le joueur ne doit pas d�passer la vitesse
            if (vitesse_max > Vitesse)
            {
                Debug.Log("gagn�");
            }
            else
            {
                Debug.Log("perdu");
            }
        }
        else
        {
            //dans le cas ou le joueur doit exc�der la vitesse
            if (vitesse_max < Vitesse)
            {
                Debug.Log("gagn�");
            }
            else
            {
                Debug.Log("perdu");
            }
        }
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
