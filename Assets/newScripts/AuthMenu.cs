using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class AuthMenu : MonoBehaviour
{ 
    public void EnterOnGameBtn()
    {
        Debug.Log("se logeo , ingresando");
        SceneManager.LoadScene("TestScene");
    }
    public void SalirBtn()
    {
        Debug.Log("deberia cerrar");
        Application.Quit();
    }
    public void BackAuthMenu()
    {
        SceneManager.LoadScene("Auth");
    }
    public void GoRegister()
    {
        SceneManager.LoadScene("Register");
    }

}
