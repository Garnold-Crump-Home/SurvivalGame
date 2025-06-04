using UnityEngine;

public class SunCycle : MonoBehaviour
{
    public Light sun;                        // Assign your directional light
    public Gradient lightColor;             // Gradient for color transitions
    public AnimationCurve lightIntensity;   // Curve for intensity transitions
    public float fullDayLength = 1200f;     // 1200 seconds = 20 minutes
    private float timeOfDay = 0.25f;        // Start at sunrise (0.25 = 6am)

    void Start()
    {
        if (sun == null)
        {
            sun = GetComponent<Light>();
        }
    }

    void Update()
    {
        // Update time
        timeOfDay += Time.deltaTime / fullDayLength;
        if (timeOfDay >= 1f) timeOfDay = 0f;

        // Rotate the sun (360 degrees over full cycle)
        float sunAngle = timeOfDay * 360f - 90f; // -90 to start at sunrise
        sun.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);

        // Change light color and intensity based on time
        sun.color = lightColor.Evaluate(timeOfDay);
        sun.intensity = lightIntensity.Evaluate(timeOfDay);
    }
}