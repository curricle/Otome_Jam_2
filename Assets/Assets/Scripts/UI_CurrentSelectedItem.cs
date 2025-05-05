using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CurrentSelectedItem : MonoBehaviour
{
    
    public TextMeshProUGUI ui_currentSelectedItemName;
    public TextMeshProUGUI ui_currentSelectedItemDescription;
    public Image ui_currentSelectedItemSprite;

    public GameObject go_currentSelectedItemName;
    public GameObject go_currentSelectedItemDescription;
    public GameObject go_currentSelectedItemSprite;

    void Awake() {
        ui_currentSelectedItemName = go_currentSelectedItemName.GetComponent<TextMeshProUGUI>();
        ui_currentSelectedItemDescription = go_currentSelectedItemDescription.GetComponent<TextMeshProUGUI>();
        ui_currentSelectedItemSprite = go_currentSelectedItemSprite.GetComponent<Image>();
    }

}
