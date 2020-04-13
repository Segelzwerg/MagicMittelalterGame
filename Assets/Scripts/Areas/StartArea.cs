﻿using Sounds.Manager;
using UnityEngine;

namespace Areas
{
    public class StartArea : SoundArea
    {
        private void OnTriggerExit(Collider other) {
            if (other.name == "Player")
            {
                GameObject.Find("Player").GetComponent<MusicManager>().Background("default");
            }
        }
    }
}