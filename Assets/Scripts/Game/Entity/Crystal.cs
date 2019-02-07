using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Actions;
using Assets.Scripts.Game.Score;
using Game.Objects.Logics;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.Entity
{
    public class Crystal : GameEntity
    {
        private ParticleSystem _particle;

        [Inject]
        public new void Construct(IScoreManager scoreManager)
        {
            _particle = GetComponentInChildren<ParticleSystem>();

            var createState = new Sequence(
                new CheckCrystal(),
                new CustomAction(c =>
                {
                    _particle?.Play();
                    scoreManager.AddScore(1);
                }),
                new WaitForSecondAction(_particle != null ? _particle.main.duration : 0),
                new DestroyEntity()
            );

            Behaiour.Register(BehaiourState.Create, createState);
        }

        public override void Enable()
        {
            base.Enable();

            var context = Behaiour.Context;
            context.SetValue(ActionConsts.Unit, this);

            Behaiour.SelectState(BehaiourState.Create);

            _particle?.Clear();
        }

        public override void Disable()
        {
            base.Disable();

            _particle?.Clear();
        }

        public class Factory : PlaceholderFactory<Crystal>
        {
        }
    }
}
