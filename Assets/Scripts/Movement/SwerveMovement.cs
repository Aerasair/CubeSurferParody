using UnityEngine;

[RequireComponent(typeof(SwerveInputSystem))]
public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    [SerializeField] private float _roadWidth;
    [SerializeField] Transform _transformCenter;

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void Update()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        if(CheckIsBound(transform.localPosition.x + swerveAmount - _transformCenter.localPosition.x))
            transform.Translate(swerveAmount, 0, 0);
    }

    private bool CheckIsBound(float nextPositionX)
    {
        bool value = false;


        if (nextPositionX > -1.95f && nextPositionX<=2.3f) //can move 
            return true;


        return value;
    }
}
