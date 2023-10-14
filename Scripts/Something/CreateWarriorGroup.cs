using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateWarriorGroup : AutoMonoBehaviour
{
    private readonly string DEFAULT_GROUP_WARRIOR_NAME = "Group_Warrior";

    private static CreateWarriorGroup instance;
    public static CreateWarriorGroup Instance => instance;

    #region Main methods
    protected override void Awake() => CreateWarriorGroup.instance = this;

    private IFactory GetFactoryByName(
        string name
    ) => WarriorSpawner.Instance.FindFactoryByName(name);

    public virtual void RequestCreateWarriors() =>
        this.SpawnGroupEnemy(GameController.Instance.ButtonStoreWarrior.NameFactory);

    private void SpawnGroupEnemy(
        string name
    ) {
        Transform point = GameController.Instance.TitleChoosing;
        Transform groupSpawn = GroupSpawner.Instance.Spawn(DEFAULT_GROUP_WARRIOR_NAME, point.position, point.rotation);
        var factoy = this.GetFactoryByName(name);

        var listPointWarrior = groupSpawn.Cast<Transform>();
        foreach (Transform pointSpawn in listPointWarrior)
            factoy.SpawnMechanism(pointSpawn.position, pointSpawn.rotation);
    }
    #endregion
}
