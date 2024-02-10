using System;
using System.Collections.Generic;

namespace BalloonProject.Data
{
    /// <summary>
    /// ������ ����������
    /// </summary>
    [Serializable]
    public class Result
    {
        /// <summary>
        /// ID ����������
        /// </summary>
        public string ID;
        /// <summary>
        /// ��� ������
        /// </summary>
        public string Name;
        /// <summary>
        /// ����� ��������� ������
        /// </summary>
        public float Time;
        /// <summary>
        /// ���� ��������� ����������
        /// </summary>
        public string Date;
        /// <summary>
        /// ���������� ����
        /// </summary>
        public int Score;
    }

    /// <summary>
    /// �����������
    /// </summary>
    [Serializable]
    public class Results
    {
        /// <summary>
        /// ������ ���� �����������
        /// </summary>
        public List<Result> ListAllResults = new List<Result>();
    }
}
