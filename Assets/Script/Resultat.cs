using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resultat : MonoBehaviour
{
    public Image tamponImg;
    public Sprite tamponV;
    public Sprite tamponX;

    public static bool poid;
    public static bool charge;
    public static bool vitesse;

    // Start is called before the first frame update
    void Start()
    {
        if (poid && charge && vitesse)
        {
            tamponImg.sprite = tamponV;
        }
        else
        {
            tamponImg.sprite = tamponX;
        }
    }
}
