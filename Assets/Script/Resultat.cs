using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resultat : MonoBehaviour
{
    public Image tamponImg;
    public Image papierImg;
    public Sprite tamponV;
    public Sprite tamponX;
    public Sprite papierV;
    public Sprite papierX;

    public static bool poid;
    public static bool charge;
    public static bool vitesse;

    public Text result;

    // Start is called before the first frame update
    void Start()
    {
        if (poid && charge && vitesse)
        {
            papierImg.sprite = papierV;
            tamponImg.sprite = tamponV;
            result.text = "Cher Latécoère, L’état major a bien observé la démonstration de votre avion, et a été surpris par la grande capacité de l’avion"; 
        }
        else
        {
            string chargetxt ="";
            string vitessetxt ="";
            string poidtxt ="";
            papierImg.sprite = papierX;
            tamponImg.sprite = tamponX;
            if (!poid)
            {
                poidtxt = " probleme de poid, ";
            }
            if (!charge)
            {
                chargetxt = " probleme de capacité de charge, ";
            }
            if (!vitesse)
            {
                vitessetxt = " probleme de vitess, ";
            }
            result.text = "Cher Latécoère, L’état major a bien observé la démonstration de votre avion, ce qui a surtout été dûment observé ont été les terribles erreurs, "+poidtxt+vitessetxt+chargetxt;
        }
    }
}
