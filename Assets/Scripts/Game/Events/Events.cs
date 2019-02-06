using System;
using System.Collections.Generic;
using Assets.Scripts.Common.EventAggregator;
using Assets.Scripts.Game.Model;
using Assets.Scripts.Game.Units;
using UnityEngine;

namespace Assets.Scripts.Game.Events
{
	public sealed class CreateUnitsEvent : EventHub<CreateUnitsEvent, List<Tuple<string, Vector3>>> { }

	public sealed class SetInputStateEvent : EventHub<SetInputStateEvent, eInputState> { }

	//public sealed class SceneClickEvent : EventHub<SceneClickEvent, RaycastHit> { }

	public sealed class ClickUnitEvent : EventHub<ClickUnitEvent, IUnit> { }

	public sealed class MoveUnitByPathEvent : EventHub<MoveUnitByPathEvent, IUnit, Vector3> { }

	public sealed class AttackUnitEvent : EventHub<AttackUnitEvent, IUnit, IUnit> { }

}
