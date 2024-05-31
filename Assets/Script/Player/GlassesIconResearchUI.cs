using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassesIconResearchUI : MonoBehaviour {


    public static GlassesIconResearchUI Instance { get; private set; }


    public event EventHandler<OnResearchNPCEventArgs> OnResearchNPC;
    public class OnResearchNPCEventArgs : EventArgs {
        public NameIconSO nameIconSO;
        public AgeIconSO ageIconSO;
        public JobIconSO jobIconSO;
        public HobbyIconSO hobbyIconSO;
        public CharacterIconSO characterIconSO;
    };


    [SerializeField] Transform prefab;

    [SerializeField] private Transform sliderBox;
    [SerializeField] private Transform nameBox;
    [SerializeField] private Transform ageBox;
    [SerializeField] private Transform jobBox;
    [SerializeField] private Transform hobbyBox;
    [SerializeField] private Transform characterBox;

    [SerializeField] private NameIconSO[] nameIcons;
    [SerializeField] private AgeIconSO[] ageIcons;
    [SerializeField] private JobIconSO[] jobIcons;
    [SerializeField] private HobbyIconSO[] hobbyIcons;
    [SerializeField] private CharacterIconSO[] characterIcons;


    private float stepDistance = 0.007f;
    private int sliderBoxStep = 0;
    private int sliderBoxStepMax = 4;
    private int nameBoxStep;
    private int ageBoxStep;
    private int jobBoxStep;
    private int hobbyBoxStep;
    private int characterBoxStep;


    private void Awake() {
        Instance = this;
    }


    private void Start() {
        foreach (NameIconSO nameIcon in nameIcons) {
            Transform obj = Instantiate(prefab);
            obj.SetParent(nameBox);
            obj.localPosition = Vector3.zero;
            Image objImage = obj.GetComponent<Image>();
            objImage.sprite = nameIcon.spriteIcon;
        }
        foreach (AgeIconSO ageIcon in ageIcons) {
            Transform obj = Instantiate(prefab);
            obj.SetParent(ageBox);
            obj.localPosition = Vector3.zero;
            Image objImage = obj.GetComponent<Image>();
            objImage.sprite = ageIcon.spriteIcon;
        }
        foreach (JobIconSO jobIcon in jobIcons) {
            Transform obj = Instantiate(prefab);
            obj.SetParent(jobBox);
            obj.localPosition = Vector3.zero;
            Image objImage = obj.GetComponent<Image>();
            objImage.sprite = jobIcon.spriteIcon;
        }
        foreach (HobbyIconSO hobbyIcon in hobbyIcons) {
            Transform obj = Instantiate(prefab);
            obj.SetParent(hobbyBox);
            obj.localPosition = Vector3.zero;
            Image objImage = obj.GetComponent<Image>();
            objImage.sprite = hobbyIcon.spriteIcon;
        }
        foreach (CharacterIconSO characterIcon in characterIcons) {
            Transform obj = Instantiate(prefab);
            obj.SetParent(characterBox);
            obj.localPosition = Vector3.zero;
            Image objImage = obj.GetComponent<Image>();
            objImage.sprite = characterIcon.spriteIcon;
        }
    }


    private void Update() {
        Vector3 sliderMovement = new Vector3();
        Vector3 nameMovement = new Vector3();
        Vector3 ageMovement = new Vector3();
        Vector3 jobMovement = new Vector3();
        Vector3 hobbyMovement = new Vector3();
        Vector3 characterMovement = new Vector3();

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (sliderBoxStep > 0) {
                sliderBoxStep--;
                sliderMovement = Vector3.left;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (sliderBoxStep < sliderBoxStepMax) {
                sliderBoxStep++;
                sliderMovement = Vector3.right;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            switch (sliderBoxStep) {
                case 0:
                    if (nameBoxStep > 0) {
                        nameBoxStep--;
                        nameMovement = Vector3.up;
                    }
                    break;
                case 1:
                    if (ageBoxStep > 0) {
                        ageBoxStep--;
                        ageMovement = Vector3.up;
                    }
                    break;
                case 2:
                    if (jobBoxStep > 0) {
                        jobBoxStep--;
                        jobMovement = Vector3.up;
                    }
                    break;
                case 3:
                    if (hobbyBoxStep > 0) {
                        hobbyBoxStep--;
                        hobbyMovement = Vector3.up;
                    }
                    break;
                case 4:
                    if (characterBoxStep > 0) {
                        characterBoxStep--;
                        characterMovement = Vector3.up;
                    }
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            switch (sliderBoxStep) {
                case 0:
                    if (nameBoxStep < nameIcons.Length - 1) {
                        nameBoxStep++;
                        nameMovement = Vector3.down;
                    }
                    break;
                case 1:
                    if (ageBoxStep < ageIcons.Length - 1) {
                        ageBoxStep++;
                        ageMovement = Vector3.down;
                    }
                    break;
                case 2:
                    if (jobBoxStep < jobIcons.Length - 1) {
                        jobBoxStep++;
                        jobMovement = Vector3.down;
                    }
                    break;
                case 3:
                    if (hobbyBoxStep < hobbyIcons.Length - 1) {
                        hobbyBoxStep++;
                        hobbyMovement = Vector3.down;
                    }
                    break;
                case 4:
                    if (characterBoxStep < characterIcons.Length - 1) {
                        characterBoxStep++;
                        characterMovement = Vector3.down;
                    }
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            NameIconSO nameIconSO = null;
            AgeIconSO ageIconSO = null;
            JobIconSO jobIconSO = null;
            HobbyIconSO hobbyIconSO = null;
            CharacterIconSO characterIconSO = null;

            switch (sliderBoxStep) {
                case 0:
                    nameIconSO = nameIcons[nameBoxStep];
                    break;
                case 1:
                    ageIconSO = ageIcons[ageBoxStep];
                    break;
                case 2:
                    jobIconSO = jobIcons[jobBoxStep];
                    break;
                case 3:
                    hobbyIconSO = hobbyIcons[hobbyBoxStep];
                    break;
                case 4:
                    characterIconSO = characterIcons[characterBoxStep];
                    break;
            }

            OnResearchNPC?.Invoke(this, new OnResearchNPCEventArgs {
                nameIconSO = nameIconSO,
                ageIconSO = ageIconSO,
                jobIconSO = jobIconSO,
                hobbyIconSO = hobbyIconSO,
                characterIconSO = characterIconSO,
            });
        }

        sliderBox.localPosition += sliderMovement * stepDistance * -1;
        nameBox.localPosition += nameMovement * stepDistance * -1;
        ageBox.localPosition += ageMovement * stepDistance * -1;
        jobBox.localPosition += jobMovement * stepDistance * -1;
        hobbyBox.localPosition += hobbyMovement * stepDistance * -1;
        characterBox.localPosition += characterMovement * stepDistance * -1;
    }


}
