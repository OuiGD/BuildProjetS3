using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int x;
    public int y;
    public int z;
    public int size;
    public List<GridObject> objDataBase;
    
        // Start is called before the first frame update
    void Start()
    {
        Grid3D Grid = new Grid3D(x,y,z,size);
    }

}
