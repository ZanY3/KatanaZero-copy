using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleporter : MonoBehaviour
{
    public string TpSceneName;
    public GameObject fade;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            fade.SetActive(true);
            Invoke("SceneLoad", 1f);
        }
    }
    void SceneLoad()
    {
        SceneManager.LoadScene(TpSceneName);
    }
}
