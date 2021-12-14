using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bouton_menu : MonoBehaviour
{
    private Mission mission;
    public GameManager game;
    public GUI gui;


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
        if (!Mission.Excedant_poid)
        {
            //dans le cas ou le joueur ne doit pas d�passer un poid
            if (Mission.Objectif_poid > gui.Poid)
            {                
                Debug.Log("gagne");
                Resultat.poid = true;
            }
            else
            {
                Debug.Log("perdu");
                Resultat.poid = false;
            }
        }
        else
        {
            //dans le cas ou le joueur doit exc�der un poid
            if (Mission.Objectif_poid < gui.Poid)
            {
                Debug.Log("gagne");
                Resultat.poid = true;
            }
            else
            {
                Debug.Log("perdu");
                Resultat.poid = false;
            }
        }

        //############

        //le jeu va v�rifier si la capacit� de charge de l'avion correspond � la mission
        //ce "if" v�rifie si le joueur doit avoir une valeur plus petit ou plus grande.
        if (!Mission.Excedant_Charge)
        {
            //dans le cas ou le joueur ne doit pas d�passer la capacit�
            if (Mission.Objectif_Charge > gui.Charge)
            {
                Debug.Log("gagne");
                Resultat.charge = true;
            }
            else
            {
                Debug.Log("perdu");
                Resultat.charge = false;
            }
        }
        else
        {
            //dans le cas ou le joueur doit exc�der la capacit�
            if (Mission.Objectif_Charge < gui.Charge)
            {
                Debug.Log("gagne");
                Resultat.charge = true;
            }
            else
            {
                Debug.Log("perdu");
                Resultat.charge = false;
            }
        }

        //############

        //le jeu va v�rifier si la vitesse de l'avion correspond � la mission
        //ce "if" v�rifie si le joueur doit avoir une valeur plus petit ou plus grande.
        if (!Mission.Excedant_Vitesse)
        {
            //dans le cas ou le joueur ne doit pas d�passer la vitesse
            if (Mission.Objectif_Vitesse > gui.Vitesse)
            {
                Debug.Log("gagne");
                Resultat.vitesse = true;
            }
            else
            {
                Debug.Log("perdu");
                Resultat.vitesse = false;
            }
        }
        else
        {
            //dans le cas ou le joueur doit exc�der la vitesse
            if (Mission.Objectif_Vitesse < gui.Vitesse)
            {
                Debug.Log("gagne");
                Resultat.vitesse = true;
            }
            else
            {
                Debug.Log("perdu");
                Resultat.vitesse = false;
            }
        }
        SceneManager.LoadScene("End_Screen");
    }
}
