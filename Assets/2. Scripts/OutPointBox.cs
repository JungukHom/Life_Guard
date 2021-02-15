using UnityEngine;

using BusinessConversation.CHN.Hotel;

public class OutPointBox : MonoBehaviour
{
    public void TriggerEnter()
    {
        SceneLoader.LoadScene(SceneName._06_Quiz);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            BusinessConversation.CHN.Hotel.Screen.FadeOut(() =>
            {
                SceneLoader.LoadScene(SceneName._06_Quiz);
            });
        }
    }
}