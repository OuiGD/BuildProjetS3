using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GridObject : ScriptableObject
{
    public string Name;
    public int Poid;
    public int Portance;
    public int Puissance;
    public int Consommation;
    public int Capacite;
    public List<int> Dimension;
    public int Fuel;
    public GameObject Module;

    //public GridObject(int Poid, int Portance, int gridZ, float cubeSize)

}
