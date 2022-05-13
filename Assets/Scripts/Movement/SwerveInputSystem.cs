using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    public float MoveFactorX => moveFactorX;

    private float lastFrameFingerPositionX;
    private float moveFactorX;

    private void Update()
    {
        // эти инпуты не будут работыть на мобилке, делай все через юи, посмотри что такое DragHandlers
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
}
