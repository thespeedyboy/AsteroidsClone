using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titlescreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
      if(Input.GetButtonDown("Start"))
        {
            SceneManager.LoadScene("mainLevel");
        }
      if(Input.GetButtonDown("Exit"))
        {
            Application.Quit();
        }
    }
}
