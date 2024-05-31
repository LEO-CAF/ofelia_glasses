using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {


    public static GameUI Instance { get; private set; }


    [SerializeField] private Button PausePlayButton;
    [SerializeField] private Button PauseSettingsButton;
    [SerializeField] private Button PauseExitButton;


    [SerializeField] private Button SettingsMusicButton;
    [SerializeField] private Slider SettingsSensSlider;

    [SerializeField] private Button ForwardButton;
    [SerializeField] private TextMeshProUGUI ForwardText;
    [SerializeField] private Button BackwardButton;
    [SerializeField] private TextMeshProUGUI BackwardText;
    [SerializeField] private Button LeftButton;
    [SerializeField] private TextMeshProUGUI LeftText;
    [SerializeField] private Button RightButton;
    [SerializeField] private TextMeshProUGUI RightText;

    [SerializeField] private Button PauseButton;
    [SerializeField] private TextMeshProUGUI PauseText;

    [SerializeField] private Button SettingsBackButton;


    [SerializeField] private Transform PauseTransform;
    [SerializeField] private Transform SettingsTransform;
    [SerializeField] private Transform KeyTransform;


    private void Awake() {
        Instance = this;

        PausePlayButton.onClick.AddListener(() => {
            Hide(PauseTransform);
        });

        PauseSettingsButton.onClick.AddListener(() => {
            Hide(PauseTransform);
            Show(SettingsTransform);
        });

        PauseExitButton.onClick.AddListener(() => {
            Loading.SceneLoader(Loading.Scenes.MenuScene);
        });

        SettingsMusicButton.onClick.AddListener(() => {
            // musica
        });

        SettingsSensSlider.onValueChanged.AddListener((sens) => {
            PlayerMovement.Instance.mouseSensitivity = sens;
        });

        ForwardButton.onClick.AddListener(() => { NewKey(InputManager.Keys.Forward); });
        BackwardButton.onClick.AddListener(() => { NewKey(InputManager.Keys.Backward); });
        LeftButton.onClick.AddListener(() => { NewKey(InputManager.Keys.Left); });
        RightButton.onClick.AddListener(() => { NewKey(InputManager.Keys.Right); });

        PauseButton.onClick.AddListener(() => { NewKey(InputManager.Keys.Pause); });

        SettingsBackButton.onClick.AddListener(() => {
            Hide(SettingsTransform);
            Show(PauseTransform);
        });
    }


    private void Start() {
        Hide(PauseTransform);
        Hide(SettingsTransform);
        Hide(KeyTransform);

        SettingsSensSlider.value = PlayerMovement.Instance.mouseSensitivity;

        UpdateText();

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;

        InputManager.Instance.PauseEvent += InputManager_PauseEvent;
    }


    private void InputManager_PauseEvent(object sender, System.EventArgs e) {
        OnPauseTrigger();
    }


    private void Show(Transform transform) {
        transform.gameObject.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }


    private void Hide(Transform transform) {
        transform.gameObject.SetActive(false);

        if (transform == PauseTransform && transform != SettingsTransform) {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


    private bool IsShow(Transform transform) {
        return transform.gameObject.activeSelf;
    }


    private void UpdateText() {
        ForwardText.text = InputManager.Instance.GetStringFromKey(InputManager.Keys.Forward);
        BackwardText.text = InputManager.Instance.GetStringFromKey(InputManager.Keys.Backward);
        LeftText.text = InputManager.Instance.GetStringFromKey(InputManager.Keys.Left);
        RightText.text = InputManager.Instance.GetStringFromKey(InputManager.Keys.Right);

        PauseText.text = InputManager.Instance.GetStringFromKey(InputManager.Keys.Pause);
    }


    private void NewKey(InputManager.Keys key) {
        Show(KeyTransform);

        InputManager.Instance.OnKeyChange(key, () => {
            Hide(KeyTransform);
            UpdateText();
        });
    }


    public void OnPauseTrigger() {
        if (IsShow(PauseTransform)) {
            Hide(PauseTransform);
        } else {
            if (IsShow(SettingsTransform)) {
                Hide(SettingsTransform);
                Show(PauseTransform);
            } else {
                Show(PauseTransform);
            }
        }
    }


    public bool IsPause() {
        return IsShow(PauseTransform) || IsShow(SettingsTransform) || IsShow(KeyTransform);
    }


}
