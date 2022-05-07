using UnityEngine;

public class StartGame : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void Play()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void Reload()
    {
        Application.LoadLevel(0);
    }
}
