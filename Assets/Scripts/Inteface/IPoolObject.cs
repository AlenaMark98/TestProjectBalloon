namespace BalloonProject.Data
{
    /// <summary>
    /// Пул объект
    /// </summary>
    public interface IPoolObject
    {
        /// <summary>
        /// Вызван пул объект
        /// </summary>
        public void OnSpawnPoolObject();
    }
}