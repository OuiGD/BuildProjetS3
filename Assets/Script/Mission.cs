using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    //l'objectif de mission concernant le poids (en Tonnes).            
    public static float Objectif_poid;                                         
    // le joueur doit-il exceder le poids ?                             
    public static bool Excedant_poid;                                          
                                                                        
    //l'objectif de mission concernant la charge.                       
    public static float Objectif_Charge;                                       
    // le joueur doit-il exceder la charge ?                            
    public static bool Excedant_Charge;                                        
                                                                        
    //l'objectif de mission concernant la vitesse.                      
    public static float Objectif_Vitesse;                                      
    // le joueur doit-il exceder la vitesse ?                           
    public static bool Excedant_Vitesse;                                       
                                                                        
    private static int ID;

    public Mission(int id)                                              
    {                                                                   
        ID = id;                                                        
    }                                                                   
                                                                        
    public void LaunchMission()                                         
    {                                                                   
        switch (ID)                                                     
        {                                                               
            case 1:                                                     
                //le joueur ne doit pas dépasser 1300kg                 
                Objectif_poid = 1300f;                      
                Excedant_poid = false;                                  
                                                                        
                //il n'y a pas d'objectif de charge                     
                Objectif_Charge = 0f;                                   
                Excedant_Charge = true;                                 
                                                                        
                //le joueur doit atteindre un minimum de 180 km/h       
                Objectif_Vitesse = 179f;                                
                Excedant_Vitesse = true;                                
                break;                                                  
                                                                        
            case 2:                                                     
                //le joueur n'a pas de limite de poids                  
                Objectif_poid = 0f;                                     
                Excedant_poid = true;                                   
                                                                        
                //le joueur doit atteindre un minimum de 1 t de charge  
                Objectif_Charge = 900f;                                 
                Excedant_Charge = true;                                 
                                                                        
                //le joueur doit atteindre un minimum de 200 km/h       
                Objectif_Vitesse = 199f;                                
                Excedant_Vitesse = true;                                
                break;                                                  
                                                                        
            default:                                                    
                break;                                                  
        }                                                               
                                                                        
        }                                                               
                                                                        
    }                                                                   
                                                                        