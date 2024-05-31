using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassesMaskMovement : MonoBehaviour {


    private Vector3 childPosition;
    private Quaternion childRotation;
    // private Vector3 childScale;


    /*private void Start() {
        foreach (Transform child in transform) {
            childScale = child.transform.localScale;
        }

        // transform.localPosition = Vector3.zero;
        // transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = MaskPosition.Instance.transform.localScale;

        foreach (Transform child in transform) {
            child.transform.localScale = childScale;
        }
    }*/


    private void Update() {
        if (transform.position != GlassesMaskPosition.Instance.transform.position || transform.rotation != GlassesMaskPosition.Instance.transform.rotation) {
            foreach (Transform child in transform) {
                childPosition = child.transform.position;
                childRotation = child.transform.rotation;
            }

            transform.position = GlassesMaskPosition.Instance.transform.position;
            transform.rotation = GlassesMaskPosition.Instance.transform.rotation;

            foreach (Transform child in transform) {
                child.transform.position = childPosition;
                child.transform.rotation = childRotation;
            }
        }
    }


}
