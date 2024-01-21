using UnityEngine;

public class Flash : MonoBehaviour
{
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Invoke("UnFlash", 0.35f);

    }
    void UnFlash()
    {
        sr.gameObject.SetActive(false);
    }
}
