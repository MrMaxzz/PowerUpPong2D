using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameObject UISFX;
    public void MoveToScene(int sceneID)
    {
        Instantiate(UISFX, transform.position, transform.rotation);
        SceneManager.LoadScene(sceneID);
       
    }

    public void Quit()
    {
        Instantiate(UISFX, transform.position, transform.rotation);
        Application.Quit();
    }
}
