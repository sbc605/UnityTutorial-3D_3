using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorAction : MonoBehaviour
{
    private PlayableDirector pd;

    public Camera targetCam;

    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        pd.Play();        
    }

    void Update()
    {
        if (pd.time > pd.duration)
        {
            if (Camera.main == targetCam)
            {
                targetCam.GetComponent<CinemachineBrain>().enabled = false;
            }

            targetCam.gameObject.SetActive(false);

            gameObject.SetActive(false);
        }
    }
}
