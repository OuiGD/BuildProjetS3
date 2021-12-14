using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public AudioSource btUI;
    public AudioSource btWheel;
    public AudioSource engineFX;
    public AudioSource clangFX;
    public AudioSource clicFX;
    public AudioSource sign;

    public void ClickUI()
    {
        btUI.Play();
    }
    public void SignContract()
    {
        sign.Play();
    }
    public void ClickWheel()
    {
        btWheel.Play();
    }
    public void AjoutModul(string name)
    {
        float randNb = Random.value;
        if (randNb < 0.5)
        {
            clangFX.Play();
        }else
            {
                clicFX.Play();
            }
        if (name == "engine")
        {
            engineFX.Play();
        }
    }
}
