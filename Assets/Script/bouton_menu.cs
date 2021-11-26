using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bouton_menu : MonoBehaviour
{
    public void OnbuttonPress()
    {
        Debug.Log("test");
        SceneManager.LoadScene("test");
    }
}
