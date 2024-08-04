using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppStartup : MonoBehaviour
{
    private void Start()
    {
        ProjectContext.I.Initialize();

        SceneManager.LoadScene(1);

    }
}
