using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = System.Object;



public class StateMachine
{
    private IState _currentState;

    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();
    private List<Transition> _currentTransitions = new List<Transition>();
    private List<Transition> _anyTransitions = new List<Transition>();

    private static List<Transition> EmptyTransitions = new List<Transition>(0);

    public void Tick()
    {
        var transition = GetTransition();
        if (transition != null)
            SetState(transition.To);

        _currentState?.Tick();
    }

    public void SetState(IState state)
    {
        if (state == _currentState)
            return;

        _currentState?.OnExit();
        _currentState = state;

        _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
        if (_currentTransitions == null)
            _currentTransitions = EmptyTransitions;

        _currentState.OnEnter();
    }

    //_anyTransition is List of all transitions that are added in the wake function in Gatherer
    public void AddTransition(IState from, IState to, bool predicate)
    {
        if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
        {
            transitions = new List<Transition>();
            _transitions[from.GetType()] = transitions;
        }

        transitions.Add(new Transition(to, predicate));
    }

    
    //_anyTransition is the list of suddent interrupting state which is scared
    public void AddAnyTransition(IState state, bool predicate)
    {
        _anyTransitions.Add(new Transition(state, predicate));
    }

    private class Transition
    {
        public bool Condition { get; }
        public IState To { get; }

        public Transition(IState to, bool condition)
        {
            To = to;
            Condition = condition;
        }
    }

    private Transition GetTransition()
    {
        //priority is the suddent interrupting state which is scared
        foreach (var transition in _anyTransitions)
            if (transition.Condition)
                return transition;

        foreach (var transition in _currentTransitions)
            if (transition.Condition)
                return transition;

        return null;
    }
}
