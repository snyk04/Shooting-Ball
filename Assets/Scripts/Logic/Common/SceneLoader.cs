using UnityEngine.SceneManagement;

namespace ShootingBall.Common
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }

        public void ReloadCurrentScene()
        {
            int currentSceneId = SceneManager.GetActiveScene().buildIndex;
            LoadScene(currentSceneId);
        }
    }
}