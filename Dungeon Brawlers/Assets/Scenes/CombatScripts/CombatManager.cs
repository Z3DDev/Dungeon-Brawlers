using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private bool inCombat;
    private int firstStrike;

    // Start is called before the first frame update
    void Start()
    {
        inCombat = false;
        firstStrike = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetInCombat()
    {
        return inCombat;
    }

    public void SetInCombat(bool newValue)
    {
        inCombat = newValue;
    }

    public int GetFirstStrike()
    {
        return firstStrike;
    }

    public void SetFirstStrike(int newValue)
    {
        firstStrike = newValue;
    }
}
