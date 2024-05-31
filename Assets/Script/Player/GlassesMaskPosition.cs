using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesMaskPosition : MonoBehaviour {


    public static GlassesMaskPosition Instance { get; private set; }


    private void Awake() {
        Instance = this;
    }


}
