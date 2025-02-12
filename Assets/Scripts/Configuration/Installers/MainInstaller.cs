using Assets.Scripts.Contracts.Managers;
using Assets.Scripts.Contracts.Services;
using Assets.Scripts.Managers;
using Assets.Scripts.Repositories;
using Zenject;

/// <summary>
/// ������� DI-��������� ����,
/// ������� ������������ ���������� ����������� ��� ���� ����.
/// 
/// ������������ � ���� � GlobalContext, ������� ��������� �������
/// ����� �������.
/// </summary>

#region ���������� ������� DI
/// FromNew()
/// - ������� ������ � ������� ������������
/// - �� ���������
/// 
/// FromInstance(instance)
/// - ���������� ��� ������������ ������, ������ �������� ������
/// - ������� ��� ��������, ��������� ������� � Unity
/// 
/// -------------------------------------------------------------
/// AsSingle()
/// - ������� ���� ������ ��� ���� �������, ������������ ���� ���
/// - �������� ��� ���������� ��������, ����������
/// 
/// AsTransient()
/// - ������� ����� ������ ������ ��� ��� ������� �� ������ �������
/// - �������� ��� ��������� ��������
/// -------------------------------------------------------------
/// 
/// NonLazy()
/// - ������� ������ ����� ��� ������ �����
/// - ���� �� �������, �� ������ ��������� ������ ��� ������ ���������
#endregion
public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // ����������� ����������
        Container.Bind<IPlayerActionsManager>().To<PlayerActionsManager>().AsSingle();
        Container.Bind<IAnimationManager>().To<AnimationManager>().AsTransient();

        // ����������� ������������
        Container.Bind<IPLayerControlsRepository>().To<PlayerControlsRepository>().AsSingle();
    }
}
