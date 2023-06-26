using UnityEngine;
using Cinemachine;

public class CameraPOVSetter : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Transform chillCameraFollow;
    [SerializeField] private Transform activeCameraFollow;
    private bool isActive = false;

    public void Chill()
	{
        if (!isActive)
            return;

        cam.m_Follow = chillCameraFollow;
        isActive = false;
    }

    public void Active()
    {
        if (isActive)
            return;

        cam.m_Follow = activeCameraFollow;
        isActive = true;
    }

}
