using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.UI.Scripts
{
  public class MainMenuUIScript : MonoBehaviour
  {
    public void CreateLobby() =>
      UIManager.Show(UIKey.Lobby);

    public void JoinRandomLobby()
    {
      UIManager.Show(UIKey.Lobby);

      SceneManager.LoadScene("Loading");
    }

    public void Exit() =>
      Application.Quit();
  }
}