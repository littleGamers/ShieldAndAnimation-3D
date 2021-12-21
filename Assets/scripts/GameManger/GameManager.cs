using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


namespace Com.MyCompany.MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        [Tooltip("The prefab to use for representing the player")]
        public GameObject playerPrefab;

        [Tooltip("The prefab to use for representing the shield")]
        public GameObject shieldPrefab;

        // CHANGE:
        // Shield will be instantiated on a random position on the floor in shieldHeight.
        private GameObject floor;
        [Tooltip("The height of the floating shield")]
        [SerializeField] private float shieldHeight;

        public static GameManager Instance;


        void Start()
        {
            if (PlayerManager.LocalPlayerInstance == null)
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            }
            else
            {
                Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
            }

            // CHANGE:
            // The first player that enters the server triggers the one-time instantiation of the shield in the world.
            if (PhotonNetwork.IsMasterClient)
            {
                floor = GameObject.FindGameObjectWithTag("Floor");
                if (floor)
                {
                    Bounds floorBounds = floor.GetComponent<MeshRenderer>().bounds;

                    // Generate a random location on the floor:
                    Vector3 shieldPosition = new Vector3(Random.Range(floorBounds.min.x, floorBounds.max.x),
                                                     shieldHeight,
                                                     Random.Range(floorBounds.min.z, floorBounds.max.z));

                    PhotonNetwork.Instantiate(this.shieldPrefab.name, shieldPosition, Quaternion.identity, 0);
                }
            }
            
            Instance = this;
        }

        #region Photon Callbacks

        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        #endregion


        #region Public Methods

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        #endregion
    }
}