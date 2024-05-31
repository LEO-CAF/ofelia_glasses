using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {


    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;


    private void Awake() {
        playButton.onClick.AddListener(() => {
            Loading.SceneLoader(Loading.Scenes.GameScene);
        });

        exitButton.onClick.AddListener(() => {
            Application.Quit();
        });

        Time.timeScale = 1f;
    }


}
