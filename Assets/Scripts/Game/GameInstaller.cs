using System;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Common.Commands;
using Assets.Scripts.Common.EventAggregator;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Game.Commands;
using Assets.Scripts.Game.Common;
using Assets.Scripts.Game.Entity;
using Assets.Scripts.Game.Events;
using Assets.Scripts.Game.EventSystem;
using Assets.Scripts.Game.Factory;
using Assets.Scripts.Game.Model;
using Assets.Scripts.Game.Navigation;
using Assets.Scripts.Game.UI;
using UnityEngine;
using Zenject;
using UnitsFactory = Assets.Scripts.Game.Units.UnitsFactory;

namespace Assets.Scripts.Game
{
	public class GameInstaller : MonoInstaller
	{
	    /*[Serializable]
	    public class Settings
	    {
	        [SerializeField]
	        private WindowFactory _windowFactory;

	        [SerializeField]
	        private EntityFactoryPool _entityFactory;

	        [SerializeField]
	        private WindowRoot _windowRoot;

	        [SerializeField]
	        private InputManager _inputManager;

	        [SerializeField]
	        private GameObject _tilePrefab;
	    }*/

	    [SerializeField]
	    private WindowFactory _windowFactory;

	    [SerializeField]
	    private EntityFactoryPool _entityFactory;

	    [SerializeField]
	    private WindowRoot _windowRoot;

	    [SerializeField]
	    private InputManager _inputManager;

	    [SerializeField]
	    private GameObject _tilePrefab;

	    [SerializeField]
	    private GameObject _ballPrefab;

	    [SerializeField]
	    private GameObject _crystalPrefab;

        public override void InstallBindings()
		{
			InstallEvents();

		    Container.Bind<IGameSettings>().To<GameSettings>().FromInstance(new GameSettings
		    {
		        StartSize = 3,
		        TileSize = 1,
                CrystalChance = 0.3f
		    });

            Container.Bind<EntityBehaiour>().AsTransient();

		    Container.Bind<EntityStorage>().AsSingle();
            Container.Bind<GameField>().AsSingle();

            Container.Bind<IGameScene>().To<GameScene>().AsSingle();

            Container.Bind<IWindowRoot>().To<WindowRoot>().FromInstance(_windowRoot);
			Container.Bind<IWindowFactory>().To<WindowFactory>().FromInstance(_windowFactory);
			Container.Bind<IUIManager>().To<UIManager>().AsSingle();

			Container.Bind<IEntityFactory>().To<EntityFactoryPool>().FromInstance(_entityFactory);

			Container.Bind<IInputManager>().To<InputManager>().FromInstance(_inputManager);

            //Container.Bind<ICommandsManager>().To<CommandsManager>().AsSingle();
            //Container.Bind<IUnitCommandsStorage>().To<UnitCommandsStorage>().AsSingle();

            //Container.Bind<IPathfinder>().To<Pathfinder>().AsSingle();

		    Container.BindFactory<Tile, Tile.Factory>()
		        .FromPoolableMemoryPool<Tile, TilePool>(poolBinder => poolBinder
		            .WithInitialSize(4)
		            .FromComponentInNewPrefab(_tilePrefab)
		            //.UnderTransformGroup("Explosions")
		        );

		    Container.BindFactory<Ball, Ball.Factory>()
		        .FromPoolableMemoryPool<Ball, BallPool>(poolBinder => poolBinder
		                .WithInitialSize(1)
		                .FromComponentInNewPrefab(_ballPrefab)
		            //.UnderTransformGroup("Explosions")
		        );

		    Container.BindFactory<Crystal, Crystal.Factory>()
		        .FromPoolableMemoryPool<Crystal, CrystalPool>(poolBinder => poolBinder
		                .WithInitialSize(1)
		                .FromComponentInNewPrefab(_crystalPrefab)
		            //.UnderTransformGroup("Explosions")
		        );

		    Container.BindFactory<FieldCoords, FieldElement, FieldElement.Factory>()
		        .FromPoolableMemoryPool<FieldCoords, FieldElement, FieldElementPool>();
		        //.FromPoolableMemoryPool<FieldCoords, float, FieldElement, FieldElementPool>(poolBinder => poolBinder
		        //        .WithInitialSize(1)
		        //        .AsTransient()
		            //.UnderTransformGroup("Explosions")
		        //);

            Container.Bind<IGameBootstart>().To<GameBootstart>().AsSingle();
			Container.Resolve<IGameBootstart>().Startup();
		}

		private void InstallEvents()
		{
		    Container.Bind<IEventsManager>().To<EventsManager>().AsSingle();

		    Container.Bind<SceneClickEvent>().AsSingle();
		    Container.Bind<SceneClickEvent.IEventHandler>().To<SceneClickHandler>().AsSingle();

		    Container.Bind<CreateGameEvent>().AsSingle();
		    Container.Bind<CreateGameEvent.IEventHandler>().To<CreateGameHandler>().AsSingle();
            

            /*Container.Bind<IPublisher>().To<Publisher>().AsSingle();
			Container.Bind<ISubscriber>().To<EventAggregator>().AsSingle();

			Container.Bind<SetInputStateEvent>().AsSingle();
			Container.Bind<SetInputStateEvent.ISubscribed>().To<SetInputStateAction>().AsSingle();

			Container.Bind<CreateUnitsEvent>().AsSingle();
			Container.Bind<CreateUnitsEvent.ISubscribed>().To<CreateUnitsAction>().AsSingle();

			Container.Bind<SceneClickEvent>().AsSingle();
			Container.Bind<SceneClickEvent.ISubscribed>().To<SceneClickAction>().AsSingle();

			Container.Bind<ClickUnitEvent>().AsSingle();
			Container.Bind<ClickUnitEvent.ISubscribed>().To<ClickUnitAction>().AsSingle();
		    Container.Bind<ClickUnitEvent.ISubscribed>().To<ClickUnitActionFake>().AsSingle();

            Container.Bind<MoveUnitByPathEvent>().AsSingle();
			//Container.Bind<MoveUnitByPathEvent.ISubscribed>().To<MoveUnitByPathAction>().AsSingle();
			Container.Bind<MoveUnitByPathEvent.ISubscribed>().To<MoveUnitByLoopAction>().AsSingle();

			Container.Bind<AttackUnitEvent>().AsSingle();
			Container.Bind<AttackUnitEvent.ISubscribed>().To<AttackUnitAction>().AsSingle();*/
        }
    }

    class TilePool : MonoPoolableMemoryPool<IMemoryPool, Tile>
    {
    }

    class BallPool : MonoPoolableMemoryPool<IMemoryPool, Ball>
    {
    }

    class CrystalPool : MonoPoolableMemoryPool<IMemoryPool, Crystal>
    {
    }

    class FieldElementPool : PoolableMemoryPool<FieldCoords, IMemoryPool, FieldElement>
    {
    }
}
