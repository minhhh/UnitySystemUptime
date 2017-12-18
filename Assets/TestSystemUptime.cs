using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSystemUptime : MonoBehaviour
{
    GUIStyle _labelStyle;

    public GUIStyle LabelStyle {
        get {
            if (_labelStyle == null) {
                _labelStyle = new GUIStyle (GUI.skin.label);
                _labelStyle.fontSize = 40;
            }
            return _labelStyle;
        }
    }

    void OnGUI ()
    {
        GUILayout.Label ("Uptime: " + SystemUptime.GetDeviceUptime (), LabelStyle);
    }

}
