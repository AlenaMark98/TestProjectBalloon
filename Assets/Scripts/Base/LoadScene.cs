using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BalloonProject
{ 
    /// <summary>
    /// Загрузка сцен
    /// </summary>
    public class LoadScene : MonoBehaviour
    {
        //NOTE: Добавить загрузочнцю сцену (лоадинг)

        /// <summary>
        /// Загрузить сцену
        /// </summary>
        /// <param name="_idScene">номер сцены</param>
        public void GoNextScene(int _idScene) => SceneManager.LoadScene(_idScene);
    }

}
