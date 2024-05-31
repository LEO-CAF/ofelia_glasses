using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loading {


    public enum Scenes {
        MenuScene,
        LoadingScene,
        GameScene
    }


    private static Scenes targetScene;


    public static void SceneLoader(Scenes targetScene) {
        Loading.targetScene = targetScene;

        SceneManager.LoadScene(Scenes.LoadingScene.ToString());
    }


    public static void LoadingLoader() {
        SceneManager.LoadScene(targetScene.ToString());
    }


}
