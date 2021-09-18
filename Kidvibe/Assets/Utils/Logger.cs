using System;
using UnityEngine;

namespace Kidvibe.Utils
{
  public enum LogColor
  {
    Green,
    Red,
    Orange,
    Blue,
  }
  
  public interface ILogger
  {
    void Log(string message);
    void LogWithTag(string tag, LogColor color, string message);
    void Warning(string message);
    void Error(Exception exception);
    void ErrorWithMessage(Exception exception, string message);

    void TemporaryDebug(string message);
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

    public void LogWithTag(string tag, LogColor color, string message)
    {
#if UNITY_EDITOR
      Debug.Log($"{ColoredText(color, tag)} {message}");
#else
#endif
    }

    public void Warning(string message)
    {
#if UNITY_EDITOR
      Debug.LogWarning(message);
#else
#endif
    }

    public void Error(Exception exception)
    {
#if UNITY_EDITOR
      Debug.Log($"Message: {exception.Message}\n" +
                $"StackTrace: {exception.StackTrace}");
#else
#endif
    }

    public void ErrorWithMessage(Exception exception, string message)
    {
      Log(message);
      Error(exception);
    }

    public void TemporaryDebug(string message)
    {
#if UNITY_EDITOR
      Debug.LogWarning($"------------------------ {message}");
#else
#endif
    }

    private string ColoredText(LogColor color, string text) =>
      $"<color={color.ToString().ToLower()}>{text}</color>";
  }
}


