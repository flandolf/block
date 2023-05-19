using System.Collections;
using TMPro;
using UnityEngine;

public class RainbowText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private readonly Color[] _colors = { Color.red, Color.magenta, Color.blue, Color.cyan, Color.green, Color.yellow, Color.red };
    private readonly float _transitionTime = 1f; // Time to transition between colors in seconds

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Rainbow());
    }

    private IEnumerator Rainbow()
    {
        while (true) // Continuously loop through the colors
        {
            for (int i = 0; i < _colors.Length - 1; i++)
            {
                float t = 0;
                while (t < _transitionTime)
                {
                    t += Time.deltaTime;
                    _text.color = Color.Lerp(_colors[i], _colors[i + 1], t / _transitionTime);
                    yield return null;
                }
            }
        }
        
        // ReSharper disable once IteratorNeverReturns
    }
}