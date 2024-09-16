using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private GameObject _timeSlierParent;

    private void Awake()
    {

    }

    private void Update()
    {
        MinusSlider();
        EndSlider();
    }

    private void MinusSlider()
    {
        _timeSlider.value -= Time.deltaTime;
    }

    private void EndSlider()
    {
        if (_timeSlider.value == 0)
            _timeSlierParent.SetActive(false);
    }
}
