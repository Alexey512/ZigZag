using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Entity;
using UnityEngine;

namespace Assets.Scripts.Game.Actions
{
    public class CameraFollower: MonoBehaviour
    {
        private Vector3 _cameraDelta;

        private float _cameraHeight;

        private Camera _camera;

        private void Start()
        {
            _camera = FindObjectOfType<Camera>();
            _cameraDelta = this.transform.position - _camera.transform.position;
            _cameraHeight = _camera.transform.position.y;
        }

        private void Update()
        {
            var pos = this.transform.position - _cameraDelta;
            //_camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(pos.x, _cameraHeight, pos.z), );
            _camera.transform.position = new Vector3(pos.x, _cameraHeight, pos.z);
        }
    }
}
