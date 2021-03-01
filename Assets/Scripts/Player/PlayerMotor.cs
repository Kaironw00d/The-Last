using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerMotor : MonoBehaviour
{
    private Transform _transform;
    private PlayerInput _input;
    private NavMeshAgent _agent;
    private Animator _animator;

    private Vector3 _motion;
    [Inject] private void Construct(
        [Inject(Id = "PlayerTransform")] Transform transform,
        PlayerInput input,
        NavMeshAgent agent,
        Animator animator)
    {
        _transform = transform;
        _input = input;
        _agent = agent;
        _animator = animator;
    }

    private void Update()
    {
        _motion.x = _input.Axis.x;
        _motion.y = 0f;
        _motion.z = _input.Axis.y;

        if(_motion != Vector3.zero)
            _transform.forward = _motion;

        _agent.Move(_motion * _agent.speed * Time.deltaTime);
        _animator.SetFloat("motionX", _motion.x, 0.05f, Time.deltaTime);
        _animator.SetFloat("motionY", _motion.z, 0.05f, Time.deltaTime);
    }
}
