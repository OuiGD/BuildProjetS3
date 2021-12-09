using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int x;
    public int y;
    public int z;
    public float size;
    public List<GridObject> objDataBase;
    public GridObject curObject;
    public GUI gui;

    private Grid3D Grid;
    private Vector3 Invert;
    private int midle;
    private GameObject Modul;

    // Start is called before the first frame update
    void Start()
    {
        Invert = new Vector3(-1f, 1f, 1f);
        Grid = new Grid3D(x,y,z,size);
        Instantiate(objDataBase[0].Module, Grid.GetWorldPosition(((x-objDataBase[0].Dimension[0])/2),((y - objDataBase[0].Dimension[1])/2),((z - objDataBase[0].Dimension[2])/2)), Quaternion.identity);
        midle = x/2;
    }


    void Update()
    {

        //selection de l'objet curObject=selection
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit pos;
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out pos))
            {
                Vector3 coord = ray.origin+(ray.direction*(pos.distance));// point de contact du ray avec le dodule / size + mathf.round
                Grid.GetGridPosition(coord, out int x, out int y, out int z);

                if (Grid.canBuild(x,y,z))
                {
                    Modul = Instantiate(curObject.Module, Grid.GetWorldPosition(x,y,z), Quaternion.identity);
                    gui.StatsBarUpdate(curObject);
                    if (x < midle && curObject.Name == "Aile")
                    {
                        Modul.transform.localScale = Invert;
                        Grid.ObjInGrid(x, y, z, curObject.Dimension,-1);
                    }
                    else
                    {
                        Grid.ObjInGrid(x, y, z, curObject.Dimension,1);
                    }
                    
                }
            }            
        }
    }

}