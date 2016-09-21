using UnityEngine;
using Mini2.Utils;

namespace Mini2.Sample
{
    public class SampleData
    {
        public float gameSpeed;
        public float playerSpeed;
    }

    public class SampleScript : Singleton<SampleScript>
    {

        #region fields

        // public fields
        [Header("Game speed")]
        [Tooltip("The initial game speed")]
        [Range(1, 10f)]
        public float initGameSpeed = 2f;
        [Tooltip("The initial player speed")]
        [Range(1, 10f)]
        public float initPlayerSpeed = 2f;
        [Header("Other")]
        [Tooltip("When checked you cannot die")]
        public bool invinsible = true;

        // private fields
        private SampleData data;

        #endregion fields

        #region awake start update

        // Awake and start
        void Awake()
        {

        }

        // Use this for initialization
        void Start()
        {
            data = new SampleData()
            {
                gameSpeed = initGameSpeed,
                playerSpeed = initPlayerSpeed
            };

        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion

        #region public methods

        public void IncreaseSpeed()
        {
            data.gameSpeed += 0.1f;
        }

        #region getters & setters

        public float GetPlayerSpeed()
        {
            return data.playerSpeed;
        }

        public float GetGameSpeed()
        {
            return data.gameSpeed;
        }

        #endregion

        #endregion

        #region private methods

        private void UpdatePlayerSpeed()
        {
            data.playerSpeed += 0.05f;
        }

        #endregion
    }
}
