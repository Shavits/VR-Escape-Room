using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayController : MonoBehaviour
{
    [SerializeField] private float rotationDuration = 3f;
    private bool rotating;

    [SerializeField] List<TextMeshProUGUI> HighScores = new List<TextMeshProUGUI>();

    private void Start()
    {
        HighScores[0].text = "#1 - " + (PlayerPrefs.HasKey("First Place") ? FormatTime(PlayerPrefs.GetFloat("First Place")) : "Not set yet");
        HighScores[1].text = "#2 - " + (PlayerPrefs.HasKey("Second Place") ? FormatTime(PlayerPrefs.GetFloat("Second Place")) : "Not set yet");
        HighScores[2].text = "#3 - " + (PlayerPrefs.HasKey("Third Place") ? FormatTime(PlayerPrefs.GetFloat("Third Place")) : "Not set yet");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("EscapeRoom");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }


    public void Rotate(bool right)
    {

        if (!rotating)
        {
            StartCoroutine(RotateEnum(right));
        }

    }

    [ContextMenu("Do Something")]
    public void RotateRight()
    {

        Rotate(true);

    }
    IEnumerator RotateEnum(bool right)
    {
        Debug.Log("test");
        rotating = true;
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        int direction = right ? 1 : -1;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 120 * direction, 0);

        while (timeElapsed < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / rotationDuration);
            timeElapsed += Time.fixedDeltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
        rotating = false;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string t = string.Format("{0:0}:{1:00}", minutes, seconds);
        return t;
    }
}
