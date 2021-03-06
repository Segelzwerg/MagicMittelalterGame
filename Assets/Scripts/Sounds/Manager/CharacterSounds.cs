using System.Collections.Generic;
using Sounds.Manager.Util;
using UnityEngine;
using UnityEngine.Audio;

namespace Sounds.Manager
{
    /// <summary>
    /// This collects all triggers to play sounds for one character.
    /// </summary>
    [AddComponentMenu("Sound/Manager/Character Sound Manager")]
    public class CharacterSounds : MonoBehaviour, ISoundManager
    {
        
        [Header("Sound Clips")]
        [Tooltip("This sound is played when the character receives damage.")]
        public AudioClip damage;

        [Tooltip("Sound of running on stone.")]
        public AudioClip runningStone;

        [Tooltip("Sound of sneaking on stone.")]
        public AudioClip sneakingStone;
        
        [Tooltip("Sound of walking in snow.")]
        public AudioClip walkSnow;
        
        [Tooltip("Sound of walking on stones.")]
        public AudioClip walkStone;
        
        [Header("Audio Sources")]
        private DoubleAudioSource _voiceSources;
        private DoubleAudioSource _movementSources;
        private List<DoubleAudioSource> _audioSources;

        [Header("Audio Mixer")]
        [Tooltip("Mixer for voice sounds.")]
        public AudioMixerGroup voiceMixer;
        [Tooltip("Mixer for character sounds.")]
        public AudioMixerGroup characterMixer;

        private void Start()
        {
            DefaultCharacterSounds.SetDefaultForMissing(this);
            
            _voiceSources = gameObject.AddComponent<DoubleAudioSource>();
            _movementSources = gameObject.AddComponent<DoubleAudioSource>();
            
            _movementSources.Start();
            _voiceSources.Start();
            
            _voiceSources.MixerGroup = voiceMixer;
            _movementSources.MixerGroup = characterMixer;

            _audioSources = new List<DoubleAudioSource> {_movementSources, _voiceSources};
        }

        /// <summary>
        /// Pauses all sounds.
        /// </summary>
        public void Pause()
        {
            _audioSources.ForEach(source => source.Pause());
        }

        /// <summary>
        /// Continue all sounds from where they stopped.
        /// </summary>
        public void Continue()
        {
            _audioSources.ForEach(source => source.UnPause());
        }

        /// <summary>
        /// Plays the damage sound for the character.
        /// </summary>
        public void Damage()
        {
            PlaySound(_voiceSources, damage);
        }

        /// <summary>
        /// Plays walking sound for a given ground type.
        /// </summary>
        /// <param name="groundType">The type of ground the character is currently walking on.</param>
        public void Walking(string groundType)
        {
            _movementSources.MixerGroup = characterMixer;
            switch (groundType)
            {
                case "Stone":
                    PlaySoundRandomStart(_movementSources, walkStone);
                    break;
                
                case "Snow":
                    PlaySoundRandomStart(_movementSources, walkSnow);
                    break;
                
                default:
                    PlaySoundRandomStart(_movementSources, walkStone);
                    break;
            }   
        }

        /// <summary>
        /// Plays running sounds for a given ground type.
        /// </summary>
        /// <param name="groundType">The type of ground the character is currently running on.</param>
        public void Running(string groundType)
        {
            _movementSources.MixerGroup = characterMixer;

            switch (groundType)
            {
                case "Stone":
                    PlaySoundRandomStart(_movementSources, runningStone);
                    break;
                default:
                    PlaySoundRandomStart(_movementSources, runningStone);
                    break;
            }
        }
        /// <summary>
        /// Plays sneaking sounds for a given ground type.
        /// </summary>
        /// <param name="groundType">The type of ground the character is currently sneaking on.</param>
        public void Sneaking(string groundType)
        {            
            _movementSources.MixerGroup = characterMixer;
            
            switch (groundType)
            {
                case "Stone":
                    PlaySoundRandomStart(_movementSources, sneakingStone);
                    break;
                default:
                    PlaySoundRandomStart(_movementSources, sneakingStone);
                    break;
            }
        }

        /// <summary>
        /// Plays a dialog for the character on it's voice channel.
        /// </summary>
        /// <param name="clip">The dialog as an audio clip.</param>
        public void Dialog(AudioClip clip)
        {
            _voiceSources.MixerGroup = voiceMixer;
            PlaySound(_voiceSources, clip);
        }

        /// <summary>
        /// Plays a sound clip at a given source.
        /// </summary>
        /// <param name="source">Which player to use.</param>
        /// <param name="clip">Which clip to play.</param>
        protected virtual void PlaySound(DoubleAudioSource source, AudioClip clip)
        {
            if (!source.IsPlaying || source.Clip != clip)
            {
                source.CrossFadeToNewClip(clip);
            }
        }

        protected virtual void PlaySoundRandomStart(DoubleAudioSource source, AudioClip clip)
        {
            if (!source.IsPlaying || source.Clip != clip)
            {
                float clipLength = clip.length;
                float startTime = Random.Range(0f, clipLength);
                source.CrossFadeToNewClip(clip, startTime: startTime);
            }
        }

        /// <summary>
        /// Stops all sound regarding movement.
        /// </summary>
        public void StopMovement()
        {
            _movementSources.Stop();
        }
    }
}