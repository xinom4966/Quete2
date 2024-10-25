using UnityEngine;

public class Sc_CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;

    private void Update()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        _camera.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _camera.transform.position.z);
    }
}
