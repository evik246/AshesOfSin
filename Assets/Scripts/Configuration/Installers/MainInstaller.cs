using Assets.Scripts.Contracts.Managers;
using Assets.Scripts.Contracts.Services;
using Assets.Scripts.Managers;
using Assets.Scripts.Repositories;
using Zenject;

/// <summary>
/// Главный DI-контейнер игры,
/// который регистрирует глобальные зависимости для всей игры.
/// 
/// Используется в паре с GlobalContext, который сохраняет объекты
/// между сценами.
/// </summary>

#region Объяснение методов DI
/// FromNew()
/// - Создает объект с помощью конструктора
/// - По умолчанию
/// 
/// FromInstance(instance)
/// - Использует уже существующий объект, вместо создания нового
/// - Полезно для объектов, созданных вручную в Unity
/// 
/// -------------------------------------------------------------
/// AsSingle()
/// - Создает один объект для всех классов, использующих этот тип
/// - Подходит для глобальных сервисов, менеджеров
/// 
/// AsTransient()
/// - Создает новый объект каждый раз при запросе от других классов
/// - Подходит для временных объектов
/// -------------------------------------------------------------
/// 
/// NonLazy()
/// - Создает объект сразу при старте сцены
/// - Если не указано, то объект создается только при первом обращении
#endregion
public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Регистрация менеджеров
        Container.Bind<IPlayerActionsManager>().To<PlayerActionsManager>().AsSingle();
        Container.Bind<IAnimationManager>().To<AnimationManager>().AsTransient();

        // Регистрация репозиториев
        Container.Bind<IPLayerControlsRepository>().To<PlayerControlsRepository>().AsSingle();
    }
}
