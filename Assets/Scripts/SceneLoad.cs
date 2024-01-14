using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoad : MonoBehaviour
{
    public string sceneLoad;
    private void Start()
    {
        Invoke("SceneLoadd", 2f);
    }
    public void SceneLoadd()
    {
        SceneManager.LoadScene(sceneLoad);
    }
}
