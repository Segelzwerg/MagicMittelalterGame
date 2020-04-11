using System;
using Sounds.Manager;
using UnityEngine;

namespace Areas
{
    public class GenericArea : SoundArea
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player")
            {
                GameObject.Find("Player").GetComponent<MusicManager>().Background(playlist);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            throw new NotImplementedException();
        }
    }
}