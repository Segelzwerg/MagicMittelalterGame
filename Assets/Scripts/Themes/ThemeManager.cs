﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Theme
{
    public class ThemeManager : MonoBehaviour
    {
        public static ThemeManager instance;
        public ThemeScriptable currentTheme;

        public ThemeScriptable[] selectableThemes;

        private void Awake()
        {
            instance = this;
        }

        public static string GetName(int id)
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ThemeManager>();
            return instance.currentTheme.GetName(id);
        }

        public static Color GetColorByName(string name)
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ThemeManager>();
            return instance.currentTheme.GetColorByName(name);
        }

        public static string[] GetGroupNames()
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ThemeManager>();
            return instance.currentTheme.GetGroupNames();
        }

        public void forceApplyTheme()
        {
            ThemeTarget[] targets = FindObjectsOfType<ThemeTarget>();
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].Refresh();
            }
        }

        private ThemeScriptable oldTheme;

        private void Update()
        {
            if (oldTheme != currentTheme)
            {
                forceApplyTheme();
                oldTheme = currentTheme;
            }
        }
    }
}