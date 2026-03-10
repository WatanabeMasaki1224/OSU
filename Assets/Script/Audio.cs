using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;
    public AudioSource audioSource;
    public AudioClip trueSE;
    public AudioClip falseSE;
    public AudioClip selectSE;

    void Awake()
    {
        instance = this;
    }

   public void PlayTrue()
    {
        audioSource.PlayOneShot(trueSE);
    }

    public void PlayFalse()
    {
        audioSource.PlayOneShot(falseSE);
    }

    public void SelectSE()
    {
        audioSource.PlayOneShot(selectSE);
    }
}
