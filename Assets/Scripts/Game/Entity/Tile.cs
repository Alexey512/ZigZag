using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Actions;
using Assets.Scripts.Game.Model;
using Game.Objects.Logics;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.Entity
{
    public class Tile: GameEntity
    {
        private GameField _field;

        private Animator _animator;

        [Inject]
        public new void Construct(GameField field, FieldElement.Factory elementFactory)
        {
            _field = field;
            _animator = GetComponent<Animator>();

            var createState = new Sequence(
                new CheckUnitLeave(),
                new CreateNewTile(field),
                new WaitForSecondAction(0.15f),
                new CustomAction(c =>
                {
                    _animator?.SetBool("Destroy", true);
                }),
                new WaitForSecondAction(1.0f),
                new DestroyTile(field)
            );

            Behaiour.Register(BehaiourState.Create, createState);
        }

        public override void Enable()
        {
            base.Enable();

            var context = Behaiour.Context;
            context.SetValue(ActionConsts.Unit, this);

            _animator?.SetBool("Destroy", false);
            _animator?.Play("Idle");

            //_behaiour.SelectState(BehaiourState.Create);
        }

        public override void Disable()
        {
            base.Disable();

            _animator?.SetBool("Destroy", false);
        }

        public class Factory : PlaceholderFactory<Tile>
        {
        }
    }
}
