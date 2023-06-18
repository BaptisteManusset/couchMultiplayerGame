using System.Collections.Generic;
using UnityEngine;

public class UiListPlayers : MonoBehaviour
{
    [Header("Ref")]
    [SerializeField] GameObject PlayerUiPrefab;

    [SerializeField] RectTransform UiPlayerListParent;

    [SerializeField] private List<PlayerUiElement> m_playerUiElements = new();


    public void DisplayPlayers(List<Player> m_source)
    {
        if (m_playerUiElements.Count != 0)
        {
            Clear();
        }

        for (int i = 0; i < m_source.Count; i++)
        {
            GameObject instance = Instantiate(PlayerUiPrefab, UiPlayerListParent);

            PlayerUiElement uiElement = instance.GetComponent<PlayerUiElement>();
            uiElement.SetLink(m_source[i]);

            m_playerUiElements.Add(uiElement);
        }
    }

    public void Clear()
    {
        for (int i = m_playerUiElements.Count - 1; i >= 0; i--)
        {
            Destroy(m_playerUiElements[i]);
        }
    }
}