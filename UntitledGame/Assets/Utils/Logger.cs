using System;
using UnityEngine;
  
namespace Kidvibe.Assets.Utils
{
  public interface ILogger
  {
    void Log(string message);
    void LogError(Exception exception);
    void LogErrorWithMessage(Exception exception, string message);
  }

  public class Logger : ILogger
  {
    public void Log(string message)
    {
#if UNITY_EDITOR
      Debug.Log(message);
#else
#endif
    }

    public void LogError(Exception exception)
    {
#if UNITY_EDITOR
      Debug.Log($"Message: {exception.Message}\n" +
                $"StackTrace: {exception.StackTrace}");
#else
#endif
    }

    public void LogErrorWithMessage(Exception exception, string message)
    {
      Log(message);
      LogError(exception);
    }
  }
}


