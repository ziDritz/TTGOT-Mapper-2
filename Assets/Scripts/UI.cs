using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Reflection;

public class UI : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private Mapper mapper;

    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Selectable firstSelectable;
    [SerializeField] private Button generate;
    [SerializeField] private TMP_InputField widthInputField;
    [SerializeField] private TMP_InputField heigthInputField;
    [SerializeField] private TMP_Dropdown dropdownColor;

    private Vector2 mousePosition;

    private void Start() {
        firstSelectable.Select();
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift)) {
            // Select previous selectable object
            Selectable previous = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (previous != null) { previous.Select(); }
        } else if (Input.GetKeyDown(KeyCode.Tab)) {
            // Select next selectable object
            Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null) { next.Select(); }
        }

        if (Input.GetKeyDown(KeyCode.Return) && EventSystem.current.currentSelectedGameObject == generate.gameObject) {
            OnClickGenerateButton();
        }
    }

    public void OnClickGenerateButton() {
        mapper.GenerateMap(Int32.Parse(widthInputField.text), Int32.Parse(heigthInputField.text));
        eventSystem.SetSelectedGameObject(null);
    }

    public void OnClickAddButton() {

    }

    public void OnClickDeleteButton() {

    }

    public Color GetColor() {
        switch (dropdownColor.value) {
            case 0: return Color.black;
            case 1: return Color.blue;
            case 2: return Color.cyan;
            case 3: return Color.gray;
            case 4: return Color.green;
            case 5: return Color.grey;
            case 6: return Color.magenta;
            case 7: return Color.red;
            case 8: return Color.white;
            case 9: return Color.yellow;
        }

        return Color.black;
    }

}
