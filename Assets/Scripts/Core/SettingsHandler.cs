using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public Button ReverseControlsButton;
    public Sprite CheckboxChecked;
    public Sprite CheckboxUnchecked;

    void Start()
    {
        UpdateChecks();
    }

    public void Toggle_ReverseControls()
    {
        PlayerPrefs.SetInt(Constants.SETTINGS_REVERSECONTROLS, PlayerPrefs.GetInt(Constants.SETTINGS_REVERSECONTROLS) == 0 ? 1 : 0);

        UpdateChecks();
    }

    private void UpdateChecks()
    {
        ReverseControlsButton.image.sprite = (PlayerPrefs.GetInt(Constants.SETTINGS_REVERSECONTROLS) == 0 ? CheckboxUnchecked : CheckboxChecked);
    }
}
