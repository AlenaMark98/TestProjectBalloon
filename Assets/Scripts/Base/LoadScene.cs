using UnityEngine;
using UnityEngine.SceneManagement;

namespace BalloonProject
{ 
    /// <summary>
    /// �������� ����
    /// </summary>
    public class LoadScene : MonoBehaviour
    {
        //TODO: �������� ����������� ����� (�������)

        /// <summary>
        /// ��������� �����
        /// </summary>
        /// <param name="_idScene">����� �����</param>
        public void GoNextScene(int _idScene) => SceneManager.LoadScene(_idScene);
    }

}
