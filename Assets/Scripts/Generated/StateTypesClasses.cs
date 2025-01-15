using System;
using System.Collections.Generic;
public class StateTypesClasses
{
	public enum StateTypes
	{
		None,
		ChaseState,
		IdleState,
		JumpState,
		SkillState,
		WalkState,
		Max
	}
	private static readonly Dictionary<Type, StateTypes> TypeToState = new()
	{
		[typeof(ChaseState_Monster)] = StateTypes.ChaseState,
		[typeof(IdleState)] = StateTypes.IdleState,
		[typeof(IdleState_Monster)] = StateTypes.IdleState,
		[typeof(JumpState)] = StateTypes.JumpState,
		[typeof(SkillState_Monster)] = StateTypes.SkillState,
		[typeof(WalkState)] = StateTypes.WalkState,
		[typeof(WalkState_Monster)] = StateTypes.WalkState,
	};
	public static StateTypes GetState<T>() => GetState(typeof(T));
	public static StateTypes GetState(Type type )
	{
		return TypeToState.GetValueOrDefault(type, StateTypes.None);
	}
}
