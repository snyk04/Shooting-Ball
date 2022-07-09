namespace ShootingBall.Common
{
    public class SceneLoaderComponent : Component<SceneLoader>
    {
        protected override SceneLoader CreateObject()
        {
            return new SceneLoader();
        }
    }
}