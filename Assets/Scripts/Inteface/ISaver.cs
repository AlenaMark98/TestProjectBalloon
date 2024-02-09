using System.Collections;
using System.Collections.Generic;

namespace BalloonProject
{
    /// <summary>
    /// ��������� ����������
    /// </summary>
    /// <typeparam name="T">��� �������</typeparam>
    public interface ISaver<T>
    {
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="_value">��� �������</param>
        public void Save(T _value);
        /// <summary>
        /// ��������
        /// </summary>
        public void Load();
        /// <summary>
        /// ��������
        /// </summary>
        public void Removed();
    }
}
