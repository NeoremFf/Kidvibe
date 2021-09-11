using System.Collections;
using UnityEngine;
using Zenject;

namespace Kidvibe.App
{
  public class AppModel : MonoBehaviour
  {
    [Inject] public static AppModel instance;

    public void StartTask(IEnumerator task) =>
      StartCoroutine(task);
  }
}