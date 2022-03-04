using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAttackTransition : PlayerTransition{
    [SerializeField] private AttackState attackState;
    public override void Enable()    {
        attackState.AbilityEnded += OnAbbilityEnded;
    }
    private void OnDisable()    {
        attackState.AbilityEnded -= OnAbbilityEnded;
    }
    private void OnAbbilityEnded() {
        NeedTranst = true;
    }
    void Update()    {
        
    }
}
