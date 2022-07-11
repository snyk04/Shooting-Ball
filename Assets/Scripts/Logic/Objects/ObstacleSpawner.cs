using UnityEngine;

namespace ShootingBall.Objects
{
    public class ObstacleSpawner
    {
        public ObstacleSpawner(GameObject obstaclePrefab, Transform obstacleContainer,
            float minX, float maxX, float y, float minZ, float maxZ, int amountOfObstacles)
        {
            SpawnObstacles(obstaclePrefab, obstacleContainer, minX, maxX, y, minZ, maxZ, amountOfObstacles);
        }

        private void SpawnObstacles(GameObject obstaclePrefab, Transform obstacleContainer, 
            float minX, float maxX, float y, float minZ, float maxZ, int amountOfObstacles)
        {
            for (int i = 0; i < amountOfObstacles; i++)
            {
                float x = Random.Range(minX, maxX);
                float z = Random.Range(minZ, maxZ);
                Object.Instantiate(obstaclePrefab, new Vector3(x, y, z), Quaternion.identity, obstacleContainer);
            }
        }
    }
}