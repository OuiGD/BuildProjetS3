using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bouton_menu : MonoBehaviour
{
    public void OnbuttonPress()
    {
        //renvoie au selecteur de mission
        SceneManager.LoadScene("Selecteur mission");
    }

    public void Ouverture_contrat()
    {
        //déploie le contrat
        SceneManager.LoadScene("Selecteur mission with contrat");
    }

    public void Contrat_return()
    {
        //renvoie au selecteur de mission
        SceneManager.LoadScene("Selecteur mission");
    }

    public void Contrat_continue()
    {
        //renvoie au hangar de construction
        SceneManager.LoadScene("Hanger_contruction");
    }

    public void Hangar_no_contrat()
    {
        //ne lance pas de mission quand il renvoie au hangar
        SceneManager.LoadScene("Hanger_contruction");
    }

    public void Menu()
    {
        //renvoie au menu
        SceneManager.LoadScene("Main_Menu");
    }

    public void validation()
    {
        //pour l'instant, ce boutton ne fais rien, mais il servira à valider les missions
    }
}
