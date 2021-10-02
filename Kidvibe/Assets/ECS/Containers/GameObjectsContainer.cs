using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using Zenject;
using ILogger = Kidvibe.Utils.ILogger;

namespace Kidvibe.ECS.Containers
{
  public class GameObjectsContainer
  {
    [Inject] private readonly ILogger _logger; 
    
    public struct EntityAndGameObject
    {
      public int id;
      
      public Entity entity;
      public GameObject gameObject;

      public EntityAndGameObject(int id, Entity entity, GameObject gameObject)
      {
        this.id = id;
        this.entity = entity;
        this.gameObject = gameObject;
      }
    }

    private int _nextId;
    
    private readonly List<EntityAndGameObject> _objectPairs;

    public GameObjectsContainer()
    {
      _objectPairs = new List<EntityAndGameObject>();
    }
    
    public void Add(Entity entity, GameObject gameObject, string pairName)
    {
      _logger.Log($"Add new entity and game object pair: {pairName}");
      
      _objectPairs.Add(new EntityAndGameObject(++_nextId, entity, gameObject));
    }

    public Entity EntityBy(GameObject gameObject) =>
      _objectPairs.FirstOrDefault(x => x.gameObject == gameObject).entity;
    
    public GameObject GameObjectBy(Entity entity)=>
      _objectPairs.FirstOrDefault(x => x.entity == entity).gameObject;
    
    public (Entity entity1, Entity entity2) EntitiesBy(GameObject gameObject1, GameObject gameObject2) =>
      (_objectPairs.FirstOrDefault(x => x.gameObject == gameObject1).entity, 
       _objectPairs.FirstOrDefault(x => x.gameObject == gameObject2).entity);
  }
}