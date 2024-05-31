using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotazioneCameraUI : MonoBehaviour {


    private enum Mode {
        LookAtNormale,
        LookAtInvertita,
        CameraNormale,
        CameraInvertita
    }


    [SerializeField] Mode mode;


    private void LateUpdate() {
        switch (mode) {
            case Mode.LookAtNormale:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInvertita:
                Vector3 cameraDirection = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + cameraDirection);
                break;
            case Mode.CameraNormale:
                transform.forward = Camera.main.transform.forward;
                break;
            case Mode.CameraInvertita:
                transform.forward = -Camera.main.transform.forward;
                break;
        }
    }


}

