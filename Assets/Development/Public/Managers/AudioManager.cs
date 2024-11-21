using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

namespace Development.Public.Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup bgmAudioMixer;
        [SerializeField] private AudioMixerGroup sfxAudioMixer;
        [SerializeField] private float bgmFadeDuration = 1f;
        [SerializeField] private float sfxFadeDuration = 1f;

        private AudioSource _bgmAudioSource;
        private readonly Dictionary<AudioData, AudioSource> _sfxAudioSources = new();
        private bool _isSfxPaused;

        private static AudioManager _instance;

        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<AudioManager>();
                }

                return _instance;
            }
        }


        private void Start()
        {
            var audioSources = GetComponents<AudioSource>();

            foreach (var audioSource in audioSources)
            {
                Destroy(audioSource);
            }

            _bgmAudioSource = transform.gameObject.AddComponent<AudioSource>();
            _bgmAudioSource.outputAudioMixerGroup = bgmAudioMixer;
            _bgmAudioSource.loop = true;
        }

        public async UniTaskVoid PlaySfx(AudioData audioData, CancellationToken cancellationToken)
        {
            var sfxAudioSource = transform.gameObject.AddComponent<AudioSource>();
            sfxAudioSource.clip = audioData.AudioClip;
            sfxAudioSource.volume = audioData.Volume;
            sfxAudioSource.outputAudioMixerGroup = sfxAudioMixer;
            sfxAudioSource.Play();
            _sfxAudioSources.TryAdd(audioData, sfxAudioSource);

            while (true)
            {
                await UniTask.Yield(cancellationToken: cancellationToken);
                if (_isSfxPaused)
                {
                    continue;
                }

                if (sfxAudioSource == null)
                {
                    break;
                }

                if (!sfxAudioSource.isPlaying)
                {
                    break;
                }
            }

            Destroy(sfxAudioSource);
            _sfxAudioSources.Remove(audioData);
            await UniTask.CompletedTask;
        }

        public async UniTaskVoid PlayBgm(AudioData audioData)
        {
            if (_bgmAudioSource.clip == audioData.AudioClip)
            {
                return;
            }

            if (_bgmAudioSource.clip != null)
            {
                await _bgmAudioSource.DOFade(0f, bgmFadeDuration);
            }

            _bgmAudioSource.clip = audioData.AudioClip;
            _bgmAudioSource.volume = 0f;
            _bgmAudioSource.Play();
            _ = _bgmAudioSource.DOFade(audioData.Volume, bgmFadeDuration);
        }
    }

    [Serializable]
    public class AudioData
    {
        public AudioClip AudioClip;
        [Range(0f, 1f)] public float Volume = 1f;
    }
}