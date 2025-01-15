using System;

[AttributeUsage(AttributeTargets.Class)]
public class StateAttribute : Attribute
{
    public string StateName{ get; private set; }

    public StateAttribute(string stateName)
    {
        StateName = stateName;
    }
}
