using UnityEngine;

[
    RequireComponent(typeof(Blackboard_Player))
]
public class Player : Entity
{
    protected override StaterType EntityStaterType => StaterType.Player;
}
