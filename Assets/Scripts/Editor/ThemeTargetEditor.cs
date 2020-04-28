﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Theme
{
    [CustomEditor(typeof(ThemeTarget), true)]
    public class ThemeTargetEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ThemeTarget script = (ThemeTarget)target;
            GUIContent arrayLabel = new GUIContent("Theme Component Name");
            GUILayout.Label("The Popup-Dialog cannot set the value of variable. Type in the name manually.");
            int index = EditorGUILayout.Popup(arrayLabel, ThemeManager.GetPropertyIndex(script.copyName), ThemeManager.GetGroupNames());
            script.copyName = ThemeManager.GetPropertyName(index);

            base.OnInspectorGUI();
        }
    }
}