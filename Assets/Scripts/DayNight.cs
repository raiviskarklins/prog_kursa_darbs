using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

    const float cycleMins = 1f;
    const float cycleCalc = 0.1f / cycleMins * (-1f);

    void FixedUpdate () {

        transform.Rotate(0, 0, cycleCalc, Space.World);
	}
}
