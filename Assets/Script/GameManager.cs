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
    // Start is called before the first frame update
    void Start()
    {
        Grid = new Grid3D(x,y,z,size);
        Instantiate(objDataBase[0].Module, Grid.GetWorldPosition(((x-objDataBase[0].Dimension[0])/2),((y - objDataBase[0].Dimension[1])/2),((z - objDataBase[0].Dimension[2])/2)), Quaternion.identity);

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
                Grid.GetGridPosition(coord, out int px, out int py, out int pz);

                if (Grid.canBuild(px,py,pz))
                {
                    Instantiate(curObject.Module, Grid.GetWorldPosition(x,y,z), Quaternion.identity);
                }
            }
            
        }
    }

}
/*

public class GyroControl : MonoBehaviour
    {
        private bool gyroEnabled;
        private Gyroscope gyro;

        private GameObject cameraContainer;
        private Quaternion rot;

        private void Start()
        {
            cameraContainer = new GameObject("Camera Container");
            cameraContainer.transform.position = transform.position;
            transform.SetParent(cameraContainer.transform);

            gyroEnabled = EnableGyro();
        }

        private bool EnableGyro()
        {
            if (SystemInfo.supportsGyroscope)
            {
                gyro = Input.gyro;
                gyro.enabled = true;

                cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
                rot = new Quaternion(0, 0, 1, 0);

                return true;
            }
            return false;
        }
        private void Update()
        {
            if (gyroEnabled)
            {
                transform.localRotation = gyro.attitude * rot;
            }
        }
    }
*/


