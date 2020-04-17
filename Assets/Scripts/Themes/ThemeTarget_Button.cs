﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Theme
{
    [AddComponentMenu("Theme/Target/ButtonTarget")]
    public class ThemeTarget_Button : ThemeTarget
    {
        public string nameHighlighted;
        public string namePressed;
        public string nameSelected;

        public override void Refresh()
        {
            Button button = GetComponent<Button>();
            if (button == null)
            {
                Logger.logError("Button Target on " + gameObject.name + " could not find the Button!");
                return;
            }
            var colors = button.colors;
            colors.normalColor = GetColor(name);
            colors.highlightedColor = GetColor(nameHighlighted);
            colors.pressedColor = GetColor(namePressed);
            colors.selectedColor = GetColor(nameSelected);
            button.colors = colors;
        }
    }
}