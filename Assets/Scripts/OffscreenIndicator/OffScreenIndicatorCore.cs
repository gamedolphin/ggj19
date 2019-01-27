using UnityEngine;

public class OffScreenIndicatorCore
{
    public static Vector3 GetScreenPosition(Camera mainCamera, Vector3 targetPosition)
    {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(targetPosition);
        return screenPosition;
    }

    public static bool IsTargetVisible(Vector3 screenPosition)
    {
        bool isTargetVisible = screenPosition.z > 0 && screenPosition.x > 0 && screenPosition.x < Screen.width && screenPosition.y > 0 && screenPosition.y < Screen.height;
        return isTargetVisible;
    }

    public static void GetArrowIndicatorPositionAndAngle(ref Vector3 screenPosition, ref float angle, Vector3 screenCentre, Vector3 screenBounds)
    {
        //offscreen
        if (screenPosition.z < 0)
        {
            screenPosition *= -1;//stuff is flipped when its behind us
        }

        //Note coordinates translated
        //make 00 the centre of screen instead of bottom left
        screenPosition -= screenCentre;

        ///find angle from centre of screen to mouse position
        angle = Mathf.Atan2(screenPosition.y, screenPosition.x);
        angle -= 90 * Mathf.Deg2Rad;

        float cos = Mathf.Cos(angle);
        float sin = -Mathf.Sin(angle);

        //y=mx + c format
        float m = cos / sin;

        //Check up and down first
        if (cos > 0)
        {
            screenPosition = new Vector3(screenBounds.y / m, screenBounds.y, 0);
        }
        else
        {
            //down
            screenPosition = new Vector3(-screenBounds.y / m, -screenBounds.y, 0);
        }

        //if out of bounds , get point on appropriate side
        if (screenPosition.x > screenBounds.x)
        {
            //out of bounds must be on the target
            screenPosition = new Vector3(screenBounds.x, screenBounds.x * m, 0);
        }
        else if (screenPosition.x < -screenBounds.x)
        {
            //out of bounds left
            screenPosition = new Vector3(-screenBounds.x, -screenBounds.x * m, 0);
        }
        //else in bounds

        //remove coordinate translation
        screenPosition += screenCentre;
    }
}
