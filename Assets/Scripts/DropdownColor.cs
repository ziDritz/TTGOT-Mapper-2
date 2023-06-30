using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropdownColor : MonoBehaviour
{
    private TMP_Dropdown tmpDropdown;
    private List<string> dropdownList;

    // Start is called before the first frame update
    void Start()
    {
        tmpDropdown = GetComponent<TMP_Dropdown>();
        dropdownList = new List<string> {
            "black",
            "blue",
            "cyan",
            "gray",
            "green",
            "grey",
            "magenta",
            "red",
            "white",
            "yellow"
        };

        tmpDropdown.AddOptions(dropdownList);

    }
}
