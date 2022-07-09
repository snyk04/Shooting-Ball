namespace ShootingBall.Common
{
    public interface ISceneLoader
    {
        void LoadScene(int sceneId);
        void ReloadCurrentScene();
    }
}