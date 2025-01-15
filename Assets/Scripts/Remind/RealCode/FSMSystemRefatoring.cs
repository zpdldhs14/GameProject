using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class StateBaseNew
{
    protected FSMSystemRefatoring Fsm;
    protected MonsterController Monster;

    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnUpdate() { }
    
    public void Initialize(FSMSystemRefatoring fsm, MonsterController monster)
    {
        Fsm = fsm;
        Monster = monster;
    }
}

[Serializable]
public class TransitionCodition_New
{
    public string fromState;
    public string toState;
    public string conditionMethod;
}

[Serializable]
public class FSMCofiguration_New
{
    public string initialState;
    public List<string> states;
    public List<TransitionCodition_New> transitions;
}

public class FSMSystemCore
{
    private Dictionary<string, StateBaseNew> states = new();
    private StateBaseNew currentState;
    private Dictionary<string, List<TransitionCodition_New>> transitionsByState = new();

    public void Initialize(FSMCofiguration_New configuration, MonsterController monster)
    {
        foreach (string stateName in configuration.states)
        {
            AddState(stateName, monster);
        }

        OrganizeTransitions(configuration.transitions);
        ChangeState(configuration.initialState);
    }

    private void AddState(string stateName, MonsterController monster)
    {
        Dictionary<string, Type> stateMap = new()
        {
            { "IdleState", typeof(IdleState_New) },
            { "AttackState", typeof(AttackState_New) },
            // 기타 상태 추가
        };
        if (stateMap == null)
        {
            throw new Exception($"State type '{stateName}' not found.");
        }

        StateBaseNew stateInstance = (StateBaseNew)Activator.CreateInstance(stateMap[stateName]);
        //stateInstance.Initialize(this, monster);
        states[stateName] = stateInstance;
    }

    private void OrganizeTransitions(List<TransitionCodition_New> transitions)
    {
        foreach (var transition in transitions)
        {
            if (!transitionsByState.ContainsKey(transition.fromState))
                transitionsByState[transition.fromState] = new List<TransitionCodition_New>();

            transitionsByState[transition.fromState].Add(transition);
        }
    }

    public void Update()
    {
        currentState?.OnUpdate();
        CheckTransitions();
    }

    private void CheckTransitions()
    {
        if (!transitionsByState.TryGetValue(currentState?.GetType().Name, out var stateTransitions))
            return;

        foreach (var transition in stateTransitions)
        {
            if (transition.conditionMethod != null && CheckCondition(transition.conditionMethod))
            {
                ChangeState(transition.toState);
                break;
            }
        }
    }

    private bool CheckCondition(string methodName)
    {
        // 델리게이트를 통한 성능 최적화 (MonsterController에서 초기화 단계에서 미리 로드)
        return conditionMethodCache.TryGetValue(methodName, out var condition) && condition();
    }

    private void ChangeState(string newStateName)
    {
        currentState?.OnExit();

        if (states.TryGetValue(newStateName, out var nextState))
        {
            currentState = nextState;
            currentState.OnEnter();
        }
    }

    private Dictionary<string, Func<bool>> conditionMethodCache = new();

    public void InitializeConditionMethods(MonsterController monster)
    {
        var methods = monster.GetType()
            .GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        foreach (var method in methods)
        {
            if (method.ReturnType == typeof(bool) && method.GetParameters().Length == 0)
            {
                conditionMethodCache[method.Name] = (Func<bool>)Delegate.CreateDelegate(typeof(Func<bool>), monster, method);
            }
        }
    }
}

public class FSMSystemRefatoring : MonoBehaviour
{
    private FSMSystemCore fsmCore = new();

    public void Initialize(FSMCofiguration_New configuration, MonsterController monster)
    {
        // FSM 핵심 로직 초기화
        fsmCore.Initialize(configuration, monster);
        fsmCore.InitializeConditionMethods(monster);
    }

    private void Update()
    {
        fsmCore.Update();
    }
}