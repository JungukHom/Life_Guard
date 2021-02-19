namespace BusinessConversation.CHN.Hotel
{
    // Unity
    using UnityEngine;

    public class Sound : MonoBehaviour
    {
        public AudioSource bgmSource;                      // 배경음악 출력용 오디오소스
        public AudioSource effectSource;                   // 효과음 출력용 오디오소스
        public AudioSource voiceSource;                    // 목소리 출력용 오디오소스

        private float bgmVolume = 0.5f;                    // 배경음악 볼륨
        public float BGMVolume                             // 배경음악 볼륨
        {
            get { return bgmVolume; }
            set
            {
                bgmVolume = value;
                bgmSource.volume = value;
            }
        }

        private float effectVolume = 0.5f;                 // 효과음 볼륨
        public float EffectVolume                          // 효과음 볼륨
        {
            get { return effectVolume; }
            set
            {
                effectVolume = value;
                effectSource.volume = value;
            }
        }

        private float voiceVolume = 0.5f;                 // 목소리 볼륨
        public float VoiceVolume                          // 목소리 볼륨
        {
            get { return voiceVolume; }
            set
            {
                voiceVolume = value;
                voiceSource.volume = value;
            }
        }

        /// <summary>
        /// 씬에 존재하는 SoundManager 반환. 없을 시 새로 생성
        /// </summary>
        /// <returns></returns>
        public static Sound GetOrCreate()
        {
            Sound soundManager = FindObjectOfType<Sound>();
            if (!soundManager)
            {
                GameObject _soundManager = new GameObject(typeof(Sound).Name);
                soundManager = _soundManager.AddComponent<Sound>();

                GameObject _bgmSource = new GameObject("BGMSource");
                GameObject _effectSource = new GameObject("EffectSource");
                GameObject _voiceSource = new GameObject("VoiceSource");

                _bgmSource.transform.SetParent(_soundManager.transform);
                _effectSource.transform.SetParent(_soundManager.transform);
                _voiceSource.transform.SetParent(_soundManager.transform);

                AudioSource _bgmSourceComponent = _bgmSource.AddComponent<AudioSource>();
                AudioSource _effectSourceComponent = _effectSource.AddComponent<AudioSource>();
                AudioSource _voiceSourceComponent = _voiceSource.AddComponent<AudioSource>();

                _bgmSourceComponent.playOnAwake = false;
                _effectSourceComponent.playOnAwake = false;
                _voiceSourceComponent.playOnAwake = false;

                soundManager.bgmSource = _bgmSourceComponent;
                soundManager.effectSource = _effectSourceComponent;
                soundManager.voiceSource = _voiceSourceComponent;
            }

            return soundManager;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            Initialize();
        }

        /// <summary>
        ///  초기설정
        /// </summary>
        private void Initialize()
        {
            bgmSource.volume = BGMVolume;
            effectSource.volume = EffectVolume;
        }

        /// <summary>
        /// 배경음악 볼륨 조절
        /// </summary>
        /// <param name="volume"></param>
        public void SetBGMVolume(float volume)
        {
            BGMVolume = volume;
        }

        /// <summary>
        /// 효과음 볼륨 조절
        /// </summary>
        /// <param name="volume"></param>
        public void SetEffectVolume(float volume)
        {
            EffectVolume = volume;
        }

        /// <summary>
        /// 목소리 볼륨 조절
        /// </summary>
        /// <param name="volume"></param>
        public void SetVoiceVolume(float volume)
        {
            VoiceVolume = volume;
        }

        /// <summary>
        /// 배경음악 재생
        /// </summary>
        /// <param name="clip">배경음악</param>
        /// <param name="repeat">반복 여부</param>
        public void PlayBGM(AudioClip clip, bool repeat = true)
        {
            bgmSource.clip = clip;
            bgmSource.loop = repeat;
            bgmSource.Play();
        }

        /// <summary>
        /// 배경음악 재생
        /// </summary>
        /// <param name="clip">배경음악</param>
        /// <param name="volume">볼륨</param>
        /// <param name="repeat">반복 여부</param>
        public void PlayBGM(AudioClip clip, float volume, bool repeat = true)
        {
            BGMVolume = volume;

            bgmSource.clip = clip;
            bgmSource.loop = repeat;
            bgmSource.Play();
        }

        /// <summary>
        /// BGM 일시정지
        /// </summary>
        public void PauseBGM()
        {
            bgmSource.Pause();
        }

        /// <summary>
        /// BGM 일시정지 해제
        /// </summary>
        public void ResumeBGM()
        {
            bgmSource.UnPause();
        }

        /// <summary>
        /// BGM 정지
        /// </summary>
        public void StopBGM()
        {
            bgmSource.Stop();
        }

        /// <summary>
        /// 효과음 재생
        /// </summary>
        /// <param name="clip">효과음</param>
        public void PlayEffectSound(AudioClip clip, bool stop = true)
        {
            if (stop)
            {
                effectSource.Stop();
            }
            effectSource.PlayOneShot(clip, EffectVolume);
        }

        /// <summary>
        /// 효과음 재생
        /// </summary>
        /// <param name="clip">효과음</param>
        /// <param name="volume">볼륨</param>
        public void PlayEffectSound(AudioClip clip, float volume, bool stop = true)
        {
            if (stop)
            {
                effectSource.Stop();
            }

            effectSource.PlayOneShot(clip, volume);
        }

        /// <summary>
        /// 목소리 재생
        /// </summary>
        /// <param name="clip">목소리</param>
        public void PlayVoiceSound(AudioClip clip, bool stop = true)
        {
            if (stop)
            {
                voiceSource.Stop();
            }
            voiceSource.PlayOneShot(clip, VoiceVolume);
        }

        /// <summary>
        /// 목소리 재생
        /// </summary>
        /// <param name="clip">목소리</param>
        /// <param name="volume">볼륨</param>
        public void PlayVoiceSound(AudioClip clip, float volume, bool stop = true)
        {
            if (stop)
            {
                voiceSource.Stop();
            }

            voiceSource.PlayOneShot(clip, volume);
        }

        /// <summary>
        /// 목소리 정지
        /// </summary>
        public void StopVoiceSound()
        {
            voiceSource.Stop();
        }
    }
}