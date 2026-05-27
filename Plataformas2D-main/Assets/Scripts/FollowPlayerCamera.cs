using UnityEngine;
using Unity.Cinemachine;

public class FollowPlayerCamera : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cinemachineCamera;

    public float offSetAmount = 4f;
    public float smoothSpeed = 3f;

    private float targetOffsetX;

    PlayerMovement player;

    private void Start()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        player = FindFirstObjectByType<PlayerMovement>();  //Busca el objeto con ese componente es decir el Player
        if (player == null)
        {
            Debug.LogWarning("No se ha encontrado al player"); //Para que no salga el error si no esta el personaje en la escena y salga un aviso

            return;
        }

        Transform playerTransform = player.transform;
        cinemachineCamera.Follow = playerTransform;
    }

    private void Update()
    {
        if (player.movingRight == true)
        {
            targetOffsetX = offSetAmount;
        }
        else if (player.movingRight == false) {
            targetOffsetX = -offSetAmount;
        }
        else
        {
            targetOffsetX = 0;
        }
    }

}
