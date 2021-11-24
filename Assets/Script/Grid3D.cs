using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid3D
{
    private int gridX;
    private int gridY;
    private int gridZ;
    private float cubeSize;
    private int[,,] gridArray;
    public Vector3 GetWorldPosition(int x, int y, int z)
    {
        return new Vector3(x, y, z) * cubeSize;
    }
    public Grid3D(int gridX, int gridY, int gridZ, float cubeSize)
    {
        this.gridX = gridX;
        this.gridY = gridY;
        this.gridZ = gridZ;
        this.cubeSize = cubeSize;
        gridArray = new int[gridX, gridY, gridZ];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                for (int z = 0; z < gridArray.GetLength(2); z++)
                {
                    Debug.DrawLine(GetWorldPosition(x, y, z), GetWorldPosition(x, y + 1, z), Color.white, 100f);// hauteur
                    Debug.DrawLine(GetWorldPosition(x, y, z), GetWorldPosition(x, y, z + 1), Color.white, 100f);// largeur
                    Debug.DrawLine(GetWorldPosition(x, y, z), GetWorldPosition(x + 1, y, z), Color.white, 100f);// lngueur
                    //create a world text for debug
                }

            }
        }

    }

    public bool canBuild(Vector3 pos)
    {
        Vector3 max = GetWorldPosition(gridX, gridY, gridZ);
        if (((pos.x < max.x)&&(pos.y < max.y)&&(pos.z < max.z))||((pos.x > 0) && (pos.y > 0) && (pos.z >0)))
        {
            return true;
        }
        else
        {
            Debug.Log("tu peux pas construire ici");
            return false;
        }
    }

    
}
