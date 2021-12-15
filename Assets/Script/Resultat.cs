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
            result.text = "Cher Latécoère, L’état major a bien observé la démonstration de votre avion, et a été surpris par la grande capacité de l’avion, à tel point qu’il a été songé par le gouvernement de faire de votre entreprise le principal fournisseur d’avion de l'État, mais cela reste en débat. Sur le plan des modalités de paiement, l’Etat a décidé de vous récompenser avec une coupe en fonte pure pour célébrer votre victoire au concours."; 
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
                chargetxt = "probleme de capacité de charge, ";
            }
            if (!vitesse)
            {
                vitessetxt = "probleme de vitesse, ";
            }
            result.text = "Cher Latécoère, L’état major a bien observé la démonstration de votre avion, ce qui a surtout été dûment observé ont été les terribles erreurs, aussi, l’avion ne répondent pas aux demandes de notre état-major. En effet il presente les defauts suivant: "+poidtxt+vitessetxt+chargetxt+ "Cependant, dans son extrême clémence, Mr le président Raymond Poincaré vous laisse la possibilité de réparer vos erreurs en corrigeant votre avion.";
        }
    }
}
