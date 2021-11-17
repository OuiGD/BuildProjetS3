using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid3D
{
    private int gridX;
    private int griY;
    private int gridZ;
    private float cubeSize;
    private int[,,] gridArray;
    public Vector3 GetWorldPosition(int x, int y, int z)
    {
        return new Vector3(x, y, z) * cubeSize;
    }
    public Grid3D(int gridX, int griY, int gridZ, float cubeSize)
    {
        this.gridX = gridX;
        this.griY = griY;
        this.gridZ = gridZ;
        this.cubeSize = cubeSize;
        gridArray = new int[gridX, griY, gridZ];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                for (int z = 0; z < gridArray.GetLength(2); z++)
                {
                    Debug.DrawLine(GetWorldPosition(x, y, z), GetWorldPosition(x, y + 1, z), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y, z), GetWorldPosition(x, y, z + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y, z), GetWorldPosition(x + 1, y, z), Color.white, 100f);
                    //create a world text for debug
                }
            }
        }
        Debug.DrawLine(GetWorldPosition(0, griY, gridZ), GetWorldPosition(gridX + 1, griY, gridZ), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(gridX, 0, gridZ), GetWorldPosition(gridX, griY + 1, gridZ), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(gridX, griY, 0), GetWorldPosition(gridX, griY, gridZ + 1), Color.white, 100f);
    }


    
}
