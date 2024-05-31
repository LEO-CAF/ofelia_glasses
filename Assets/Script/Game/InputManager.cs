using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {


    private const string PLAYER_PREFS_KEYS = "keys";


    public static InputManager Instance { get; private set; }


    public event EventHandler PauseEvent;
    public event EventHandler OnKeyChanged;


    public enum Keys {
        Forward,
        Backward,
        Left,
        Right,
        Pause
    }


    private GameInput gameInput;

    
    private void Awake() {
        Instance = this;

        gameInput = new GameInput();

        if (PlayerPrefs.HasKey(PLAYER_PREFS_KEYS)) {
            gameInput.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PLAYER_PREFS_KEYS));
        }

        gameInput.Game.Enable();

        gameInput.Game.Pause.performed += Pause_performed;
    }


    private void OnDestroy() {
        gameInput.Game.Pause.performed -= Pause_performed;

        gameInput.Dispose();
    }


    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        PauseEvent?.Invoke(this, EventArgs.Empty);
    }


    public Vector2 Movement() {
        Vector2 inputVector = gameInput.Game.Movement.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }


    public string GetStringFromKey(Keys key) {
        switch (key) {
            default:

            case Keys.Forward:
                return gameInput.Game.Movement.bindings[1].ToDisplayString();
            case Keys.Backward:
                return gameInput.Game.Movement.bindings[2].ToDisplayString();
            case Keys.Left:
                return gameInput.Game.Movement.bindings[3].ToDisplayString();
            case Keys.Right:
                return gameInput.Game.Movement.bindings[4].ToDisplayString();

            case Keys.Pause:
                return gameInput.Game.Pause.bindings[0].ToDisplayString();
        }
    }


    public void OnKeyChange(Keys key, Action onKeyChanged) {
        gameInput.Game.Disable();

        InputAction inputAction;
        int keyAddress;

        switch (key) {
            default:

            case Keys.Forward:
                inputAction = gameInput.Game.Movement;
                keyAddress = 1;
                break;
            case Keys.Backward:
                inputAction = gameInput.Game.Movement;
                keyAddress = 2;
                break;
            case Keys.Left:
                inputAction = gameInput.Game.Movement;
                keyAddress = 3;
                break;
            case Keys.Right:
                inputAction = gameInput.Game.Movement;
                keyAddress = 4;
                break;

            case Keys.Pause:
                inputAction = gameInput.Game.Pause;
                keyAddress = 0;
                break;
        }

        inputAction.PerformInteractiveRebinding(keyAddress)
            .OnComplete(callback => {
                callback.Dispose();
                gameInput.Game.Enable();
                onKeyChanged();

                PlayerPrefs.SetString(PLAYER_PREFS_KEYS, gameInput.SaveBindingOverridesAsJson());
                PlayerPrefs.Save();

                OnKeyChanged?.Invoke(this, EventArgs.Empty);
            })
            .Start();
    }




}
