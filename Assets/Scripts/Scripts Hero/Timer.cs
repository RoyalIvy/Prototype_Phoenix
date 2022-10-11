using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [Space]

    [SerializeField] private float time;
    [SerializeField] private float increase;

    [Space]

    [SerializeField] private Image timerImage;

    [Space]

    [SerializeField] private Text timerText;

    protected float timeLeft = 0f;

    private void Start()
    {
        timeLeft = time;
    }

    private void OnTriggerEnter2D(Collider2D other) // если игрок подобрал предмет - таймер
    {
        if (other.CompareTag("QuestYellowItem"))
        {
            Destroy(other.gameObject);

            timeLeft += increase;

            if (timeLeft + increase > time)
            {
                timeLeft = time;
            }

            var normalizedValue = Mathf.Clamp(timeLeft / time, 0.0f, 1.0f);
            float minutes = Mathf.FloorToInt(timeLeft / 60);
            float seconds = Mathf.FloorToInt(timeLeft % 60);

            timerImage.fillAmount = normalizedValue;
            timerText.text = string.Format("{0} : {1:00}", minutes, seconds);
        }
    }

    private void OnTriggerStay2D(Collider2D other) // обратный отсчет, если игрок попал в облако
    {
        if (other.CompareTag("Cloud") || other.CompareTag("DeadZone"))
        {
            timeLeft -= Time.unscaledDeltaTime;

            var normalizedValue = Mathf.Clamp(timeLeft / time, 0.0f, 1.0f);
            float minutes = Mathf.FloorToInt(timeLeft / 60);
            float seconds = Mathf.FloorToInt(timeLeft % 60);

            timerImage.fillAmount = normalizedValue;
            timerText.text = string.Format("{0} : {1:00}", minutes, seconds); 
        }
        if (timeLeft < 0) // загрузка новой сцены, если время закончилось
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
