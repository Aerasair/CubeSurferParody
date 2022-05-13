using UnityEngine;

[RequireComponent(typeof(SwerveInputSystem))]
public class SwerveMovement : MonoBehaviour
{
    [SerializeField] private SwerveInputSystem swerveInputSystem;
    [SerializeField] private Transform transformCenter;

    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;

    [SerializeField] private float leftBorderPosition, rightBorderPosition;

    private void Update()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        if (CheckIsBound(transform.localPosition.x + swerveAmount - transformCenter.localPosition.x))
        {
            transform.Translate(swerveAmount, 0, 0);
        }
    }
    private bool CheckIsBound(float nextPositionX)
    {
        bool value = false;

        if (nextPositionX > leftBorderPosition && nextPositionX <= rightBorderPosition) //can moving
        { 
            return true;
        }

        return value;
    }

}
