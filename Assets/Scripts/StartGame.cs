using UnityEngine;

public class StartGame : MonoBehaviour
{
    // странное решение ждать импука игрока серез тайм скейл,вынес бы в активаторе в коде игрока, тип пока там фолс игрок не двигается
    private void Start()
    {
        Time.timeScale = 0f;
    }

    // кнопки через инспектор не таскаем, все подписвыается в коде
    // yourButton.AddListener(()=> Play);
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
