using UnityEngine;

public class Rule : MonoBehaviour
{
    public GameObject rulePanel;

    public void OpenRule()
    {
        rulePanel.SetActive(true);
    }

    public void CloseRule()
    {
        rulePanel.SetActive(false);
    }
}
