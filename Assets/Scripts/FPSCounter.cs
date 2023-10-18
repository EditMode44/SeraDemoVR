using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public float updateInterval = 0.5f; // FPS güncelleme sýklýðý
    private float lastInterval;
    private int frames = 0;
    private float fps;
    public TextMeshProUGUI fpsText;

    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    void Update()
    {
        frames++;

        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = frames / (timeNow - lastInterval);
            frames = 0;
            lastInterval = timeNow;
        }

        fpsText.text = fps.ToString();
    }
}
