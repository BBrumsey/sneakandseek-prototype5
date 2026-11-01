using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class PlayerCameraSetup : MonoBehaviour
{
    void Start()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();

        CinemachineCamera cinemachineCamera =
            GetComponentInChildren<CinemachineCamera>();

        CinemachineBrain brain =
            GetComponentInChildren<CinemachineBrain>();

        OutputChannels channel;

        if (playerInput.playerIndex == 0)
        {
            channel = OutputChannels.Channel01;
        }
        else
        {
            channel = OutputChannels.Channel02;
        }

        cinemachineCamera.OutputChannel = channel;
        brain.ChannelMask = channel;
    }
}