using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button startBtn, restartBtn;
    [SerializeField] private PathFollower pathFollower;

    private void Start()
    {
        startBtn.onClick.AddListener(Play);
        restartBtn.onClick.AddListener(Restart);
    }

    public void Play()
    {
        pathFollower.IsMoving = true;
        startBtn.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
