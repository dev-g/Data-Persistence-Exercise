using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private InputField _playerNameText;

    [SerializeField]
    private Button _returnToGameButton;

    [SerializeField]
    private Button _quitButton;

    private void Awake()
    {
        _playerNameText.text = PersistentDataManager.GetUserSettings().UserName;

        _playerNameText.onValueChanged.AddListener((string name) => { 
            PersistentDataManager.GetUserSettings().UserName = name;
            PersistentDataManager.SaveUserSettings();
        });

        _returnToGameButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("main", LoadSceneMode.Single);
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
