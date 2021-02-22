namespace BusinessConversation.CHN.Hotel
{
    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public class Popup : MonoBehaviour
    {
        [Header("기본 버튼")]
        public Button btn_backgroundPannel;
        public Button btn_close;

        protected bool unhandledAreaSwitcher = false;

        protected void Awake()
        {
            Initialize();
        }

        protected void Initialize()
        {
            SetListeners();
        }

        protected void SetListeners()
        {
            btn_close.onClick.AddListener(() => OnCloseButtonClicked());
            btn_backgroundPannel.onClick.AddListener(() => OnBackgroundButtonClicked());
        }

        protected void SetSortingLayerToHighest()
        {
            int highest = -1;
            Canvas[] canvasArray = FindObjectsOfType<Canvas>();
            foreach (Canvas canvas in canvasArray)
            {
                if (canvas.sortingOrder > highest && canvas.sortingOrder != 999)
                {
                    highest = canvas.sortingOrder;
                }
            }

            GetComponent<Canvas>().sortingOrder = highest + 1;
        }

        protected void OnCloseButtonClicked()
        {
            this.gameObject.SetActive(false);
        }

        protected void OnBackgroundButtonClicked()
        {
            if (unhandledAreaSwitcher)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
