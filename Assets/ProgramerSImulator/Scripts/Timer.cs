using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _tickDuration;

    private float _elapsedTime;

    public event Action Tick;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _tickDuration)
        {
            _elapsedTime = 0;
            Tick?.Invoke();
        }
    }
}
