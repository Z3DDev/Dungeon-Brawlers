using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntRange {
    public int m_Min;       //Minimum Value for this Range
    public int m_Max;       //Maximum Value for this Range

    //Constructor to set the Values
    public IntRange(int min, int max) {
        m_Min = min;
        m_Max = max;
    }

    public int Random {     //Get a Random Value for the Range
        get {return UnityEngine.Random.Range(m_Min, m_Max); }
    }
}
