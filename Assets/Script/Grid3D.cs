using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid3D
{
    private int gridX;
    private int griY;
    private int gridZ;
    private float cubeSize;

    public Grid3D(int gridX, int griY, int gridZ, float cubeSize)
    {
        this.gridX = gridX;
        this.griY = griY;
        this.gridZ = gridZ;
        this.cubeSize = cubeSize;
    }

    public Vector3 GetWorldPosition(int x, int y, int z)
    {
        return new Vector3(x, y, z) * cubeSize;
    }
}
