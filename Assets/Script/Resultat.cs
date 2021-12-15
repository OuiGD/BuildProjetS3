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
    public SoundFX sound;

    public static bool poid;
    public static bool charge;
    public static bool vitesse;

    public Text result;

    // Start is called before the first frame update
    void Start()
    {
        sound.ValidStamp();
        if (poid && charge && vitesse)
        {
            papierImg.sprite = papierV;
            tamponImg.sprite = tamponV;
            result.text = "Cher Lat�co�re, L��tat major a bien observ� la d�monstration de votre avion, et a �t� surpris par la grande capacit� de l�avion, � tel point qu�il a �t� song� par le gouvernement de faire de votre entreprise le principal fournisseur d�avion de l'�tat, mais cela reste en d�bat. Sur le plan des modalit�s de paiement, l�Etat a d�cid� de vous r�compenser avec une coupe en fonte pure pour c�l�brer votre victoire au concours."; 
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
                poidtxt = "probleme de poid, ";
            }
            if (!charge)
            {
                chargetxt = "probleme de capacit� de charge, ";
            }
            if (!vitesse)
            {
                vitessetxt = "probleme de vitesse, ";
            }
            result.text = "Cher Lat�co�re, L��tat major a bien observ� la d�monstration de votre avion, ce qui a surtout �t� d�ment observ� ont �t� les terribles erreurs, aussi, l�avion ne r�pondent pas aux demandes de notre �tat-major. En effet il presente les defauts suivant: "+poidtxt+vitessetxt+chargetxt+ "Cependant, dans son extr�me cl�mence, Mr le pr�sident Raymond Poincar� vous laisse la possibilit� de r�parer vos erreurs en corrigeant votre avion.";
        }
    }
}
