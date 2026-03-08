using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnRuleButton()
    {

    }

}
