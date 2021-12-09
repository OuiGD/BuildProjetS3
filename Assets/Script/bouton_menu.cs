using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bouton_menu : MonoBehaviour
{
    private Mission mission;
    public GameManager game;


    public void selectObject(int ID)
    {
        game.curObject = game.objDataBase[ID];
    }

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

    public void Contrat_continue(int id)
    {
        //renvoie au hangar de construction
        mission = new Mission(id);
        SceneManager.LoadScene("Hanger_contruction");
        mission.LaunchMission();
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

        Debug.Log("On est valide ou pas");
        //gui.Bouton_validation(mission.Objectif_poid, mission.Excedant_poid, mission.Objectif_Charge, mission.Excedant_Charge, mission.Objectif_Vitesse, mission.Excedant_Vitesse);
        //le jeu va v�rifier si le poid de l'avion correspond � la mission
        //ce "if" v�rifie si le joueur doit avoir une valeur plus petit ou plus grande.
       /* if (poid_greater_than)
        {
            //dans le cas ou le joueur ne doit pas d�passer un poid
            if (mission_poid > Poid)
            {
                Debug.Log("gagne");
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
                Debug.Log("gagne");
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
                Debug.Log("gagne");
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
                Debug.Log("gagne");
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
                Debug.Log("gagne");
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
                Debug.Log("gagne");
            }
            else
            {
                Debug.Log("perdu");
            }
        }*/
    }
}
