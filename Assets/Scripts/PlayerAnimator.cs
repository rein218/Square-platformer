using UnityEngine;
using Random = UnityEngine.Random;

namespace Controller {
    public class PlayerAnimator : MonoBehaviour {
        [SerializeField] private Animator _anim;
        [SerializeField] private float _maxTilt = .1f, _tiltSpeed = 1;
        [SerializeField, Range(1f, 3f)] private float _maxIdleSpeed = 1;
        private static readonly int GroundedKey = Animator.StringToHash("Grounded"), IdleSpeedKey = Animator.StringToHash("IdleSpeed"), JumpKey = Animator.StringToHash("Jump");
        private IPlayerController _player;
        private bool _playerGrounded;
        private Vector2 _movement;

        void Awake() => _player = GetComponentInParent<IPlayerController>();

        void Update() 
        {
            if (_player.Input.X != 0)
            {
                transform.localScale = new Vector3(_player.Input.X > 0 ? 1 : -1, 1, 1);
            }
            var targetRotVector = new Vector3(0, 0, Mathf.Lerp(-_maxTilt, _maxTilt, Mathf.InverseLerp(-1, 1, _player.Input.X)));
            _anim.transform.rotation = Quaternion.RotateTowards(_anim.transform.rotation, Quaternion.Euler(targetRotVector), _tiltSpeed * Time.deltaTime);

            _anim.SetFloat(IdleSpeedKey, Mathf.Lerp(1, _maxIdleSpeed, Mathf.Abs(_player.Input.X)));

            // Splat
            if (_player.LandingThisFrame) {
                _anim.SetTrigger(GroundedKey);
            }
            // Jump effects
            if (_player.JumpingThisFrame) {
                _anim.SetTrigger(JumpKey);
                _anim.ResetTrigger(GroundedKey);
            }

            // Play landing effects and begin ground movement effects
            if (!_playerGrounded && _player.Grounded) {
                _playerGrounded = true;
            }
            else if (_playerGrounded && !_player.Grounded) {
                _playerGrounded = false;
            }
            _movement = _player.RawMovement; // Previous frame movement is more valuable
        }        

    }
}