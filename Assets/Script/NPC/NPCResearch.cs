using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCResearch : MonoBehaviour {


    [SerializeField] private Transform objUI;


    private Outline outline;


    private void Start() {
        GlassesIconResearchUI.Instance.OnResearchNPC += Instance_OnResearchNPC;

        outline = GetComponent<Outline>();
        HideOutline();
    }


    private void Instance_OnResearchNPC(object sender, GlassesIconResearchUI.OnResearchNPCEventArgs e) {
        NPCInfoUI infoUI = objUI.GetComponent<NPCInfoUI>();
        PeopleSO peopleSO = infoUI.GetPeopleSO();

        HideOutline();

        if (e.nameIconSO == peopleSO.NameIcon) {
            ShowOutline();
        }
        if (e.ageIconSO == peopleSO.AgeIcon) {
            ShowOutline();
        }
        if (e.jobIconSO == peopleSO.JobIcon) {
            ShowOutline();
        }
        if (e.hobbyIconSO == peopleSO.HobbyIcon) {
            ShowOutline();
        }
        if (e.characterIconSO == peopleSO.CharacterIcon) {
            ShowOutline();
        }
    }


    private void ShowOutline() {
        outline.enabled = true;
    }


    private void HideOutline() {
        outline.enabled = false;
    }


}
