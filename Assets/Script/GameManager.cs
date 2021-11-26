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
    public GridObject curObject;
    private Grid3D Grid;
    private Vector3 InitPos;
    private Vector3 CurPos;
    // Start is called before the first frame update
    void Start()
    {
        Grid = new Grid3D(x,y,z,size);
        Instantiate(objDataBase[1].Module, new Vector3(x/2*size,y/ 2 * size, z/ 2 * size), Quaternion.identity);

    }

    private void OnMouseDown()
    {
        InitPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        float distance;
        CurPos = Input.mousePosition;
        distance = Vector3.Distance(CurPos,InitPos);
        
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
                Vector3 coord = ray.origin+(ray.direction*pos.distance);// point de contact du ray avec le dodule / size + mathf.round
                if (Grid.canBuild(coord))
                {
                    Instantiate(objDataBase[1].Module, new Vector3(Mathf.Round(coord.x /size), Mathf.Round(coord.y / size), Mathf.Round(coord.z / size)), Quaternion.identity);
                }
            }
            
        }

    }

}
