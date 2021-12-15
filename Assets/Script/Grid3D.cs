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
                }

            }
        }

    }
    public Vector3 GetWorldPosition(int x, int y, int z)
    {
        return new Vector3(x, y, z) * cubeSize;
    }

    public void GetGridPosition(Vector3 position , out int px, out int py, out int pz)
    {
        px = Mathf.FloorToInt(position.x / cubeSize);
        py = Mathf.FloorToInt(position.y / cubeSize);
        pz = Mathf.FloorToInt(position.z / cubeSize);
    }

    public void ObjInGrid(int x, int y, int z, List<int> dim, int pas)
    {
        for (int i = 0; i < dim[0]; i++)
        {
            Debug.Log("c'est re merde");
            for (int j = 0; j < dim[1]; j++)
            {
                Debug.Log("c'est encore la merde");
                for (int k = 0; k < dim[2]; k++)
                {
                    Debug.Log("c'est la merde");
                    gridArray[x + (i * pas), y + (j * pas), z + (k * pas)] = 1;
                }
            }
        }
    }

    public bool canBuild(int x, int y, int z)
    {
        if (((x < gridX) && (y < gridY) && (z < gridZ) && (x > 0) && (y > 0) && (z >0)) /*&& gridArray[x,y,z]!=1*/)
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
