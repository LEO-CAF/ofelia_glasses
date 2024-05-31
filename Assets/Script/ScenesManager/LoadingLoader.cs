using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingLoader : MonoBehaviour {


    private bool isFirstFrame = true;


    private void Update() {
        if (isFirstFrame) {
            isFirstFrame = false;

            Loading.LoadingLoader();
        }
    }


}