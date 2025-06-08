using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoresManager : MonoBehaviour
{
    [SerializeField]
    private Button _settingsButton;

    [SerializeField]
    private Button _returnToGameButton;

    [SerializeField]
    private Button _quitButton;


    private void Start()
    {
        _settingsButton.onClick.AddListener(() => {
            SceneManager.LoadScene("Settings");
        });

        _returnToGameButton.onClick.AddListener(() => {
            SceneManager.LoadScene("main");
        });

        _quitButton.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        });
    }
}
