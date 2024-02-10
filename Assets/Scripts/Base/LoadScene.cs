using UnityEngine;
using UnityEngine.SceneManagement;

namespace BalloonProject
{ 
    /// <summary>
    /// Загрузка сцен
    /// </summary>
    public class LoadScene : MonoBehaviour
    {
        //TODO: Добавить загрузочнцю сцену (лоадинг)

        /// <summary>
        /// Загрузить сцену
        /// </summary>
        /// <param name="_idScene">номер сцены</param>
        public void GoNextScene(int _idScene)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(_idScene);
        }
    }

}
