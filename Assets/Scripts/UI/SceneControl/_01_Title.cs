namespace BusinessConversation.CHN.Hotel
{
    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public class _01_Title : MonoBehaviour
    {
        public Button btn_start;
        public Button btn_quit;

        public bool isHotel = true;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            Screen.NotifySceneLoaded();
            CursorControl.VisibleMode();

            SetListeners();
        }

        private void SetListeners()
        {
            btn_start.onClick.AddListener(() => OnStartButtonClicked());
            btn_quit.onClick.AddListener(() => OnQuitButtonClicked());
        }

        private void OnStartButtonClicked()
        {
            Screen.FadeOut(() =>
            {
                if (isHotel)
                {
                    SceneLoader.LoadScene(SceneName._02_Menu_Hotel);
                }
                else
                {
                    SceneLoader.LoadScene(SceneName._02_Menu_Airport);
                }
            });
        }

        private void OnQuitButtonClicked()
        {
            MessagePopup.Show("프로그램을 종료하시겠습니까?", () => { Application.Quit(); }, null);
        }
    }
}
