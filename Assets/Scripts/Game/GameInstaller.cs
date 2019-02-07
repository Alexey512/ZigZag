using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Common.UI.Context;
using Assets.Scripts.Game.Common;
using Assets.Scripts.Game.Entity;
using Assets.Scripts.Game.Events;
using Assets.Scripts.Game.EventSystem;
using Assets.Scripts.Game.Factory;
using Assets.Scripts.Game.Model;
using Assets.Scripts.Game.Score;
using Assets.Scripts.Game.UI;
using Assets.Scripts.Game.UI.Controller;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game
{
	public class GameInstaller : MonoInstaller
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

	    [SerializeField]
	    private GameObject _ballPrefab;

	    [SerializeField]
	    private GameObject _crystalPrefab;

	    [SerializeField]
	    private GameObject _showWindowPrefab;

	    [SerializeField]
	    private GameObject _scoreWindowPrefab;

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

		    Container.Bind<IScoreManager>().To<ScoreManager>().AsSingle();

            Container.Bind<IWindowRoot>().To<WindowRoot>().FromInstance(_windowRoot);
		    Container.Bind<IWindowContext>().To<WindowContext>().AsSingle();
            Container.Bind<UIManager>().AsSingle();

		    Container.BindFactory<StartWindow, StartWindow.Factory>()
		        .FromPoolableMemoryPool<StartWindow, StartWindowPool>(poolBinder => poolBinder
		             .FromComponentInNewPrefab(_showWindowPrefab)
		             .UnderTransformGroup("Canvas")
		        );

		    Container.BindFactory<ScoreWindow, ScoreWindow.Factory>()
		        .FromPoolableMemoryPool<ScoreWindow, ScoreWindowPool>(poolBinder => poolBinder
		            .FromComponentInNewPrefab(_scoreWindowPrefab)
		            .UnderTransformGroup("Canvas")
		        );

            Container.Bind<IEntityFactory>().To<EntityFactoryPool>().FromInstance(_entityFactory);

			Container.Bind<IInputManager>().To<InputManager>().FromInstance(_inputManager);


		    Container.BindFactory<Tile, Tile.Factory>()
		        .FromPoolableMemoryPool<Tile, TilePool>(poolBinder => poolBinder
		            .WithInitialSize(4)
		            .FromComponentInNewPrefab(_tilePrefab)
		        );

		    Container.BindFactory<Ball, Ball.Factory>()
		        .FromPoolableMemoryPool<Ball, BallPool>(poolBinder => poolBinder
		                .WithInitialSize(1)
		                .FromComponentInNewPrefab(_ballPrefab)
		        );

		    Container.BindFactory<Crystal, Crystal.Factory>()
		        .FromPoolableMemoryPool<Crystal, CrystalPool>(poolBinder => poolBinder
		                .WithInitialSize(1)
		                .FromComponentInNewPrefab(_crystalPrefab)
		        );

		    Container.BindFactory<FieldCoords, FieldElement, FieldElement.Factory>()
		        .FromPoolableMemoryPool<FieldCoords, FieldElement, FieldElementPool>();

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

		    Container.Bind<StartGameEvent>().AsSingle();
		    Container.Bind<StartGameEvent.IEventHandler>().To<StartGameHandler>().AsSingle();
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

    class StartWindowPool : MonoPoolableMemoryPool<IMemoryPool, StartWindow>
    {
    }

    class ScoreWindowPool: MonoPoolableMemoryPool<IMemoryPool, ScoreWindow>
    {
    }
}
