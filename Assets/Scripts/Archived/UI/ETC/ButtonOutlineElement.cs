namespace BusinessConversation.CHN.Hotel
{
    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public class ButtonOutlineElement : MonoBehaviour
    {
        public Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void SetVisibillity(bool visible)
        {
            if (visible)
                SetAlpha(1);
            else
                SetAlpha(0);
        }

        private void SetAlpha(int alpha)
        {
            Color color = image.color;
            color.a = alpha;

            image.color = color;
        }
    }
}
