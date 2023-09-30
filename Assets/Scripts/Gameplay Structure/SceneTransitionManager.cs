using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class SceneTransitionManager : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField]
    private Animator transition;
    private bool forceInventoryTransition = false;

    [SerializeField]
    private bool sceneHasCombat;

    [SerializeField]
    private int nextLevel;

    private AbilityHolder abilityHolder;

    private AbilityInventoryManager abilityInventoryManager;

    private PlayerInput playerInput;
    public void LoadNextLevel(int sceneToLoad) {
        if (!loadingScene) {
            StartCoroutine(AsyncLoadNextLevel(sceneToLoad));
            loadingScene = true;
        }
    }

    private bool loadingScene;

    IEnumerator AsyncLoadNextLevel(int sceneToLoad) {
        if (!playerInput) Debug.Log("[SceneTransitionManager] PlayerInput not found. Is the player not loaded?");
        else playerInput.DeactivateInput();

        transition.SetTrigger("RunEnd");

        yield return new WaitForSeconds(1f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    void Awake() {
        transition.SetBool("InterludeRoom", !sceneHasCombat);
    }
    void Start() {
        abilityHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityHolder>();
        if (!abilityHolder) {
           Debug.Log("[SceneTransitionManager] Couldn't fetch ability inventory. Is the player not loaded?");
        }

        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        if (!playerInput) {
            Debug.Log("[SceneTransitionManager] Couldn't fetch player input component. Is the player not loaded?");
        }

        abilityInventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityInventoryManager>();
        if (!abilityInventoryManager) {
            Debug.Log("[SceneTransitionManager] Couldn't fetch player input component. Is the player not loaded?");
        }

        if (sceneHasCombat || forceInventoryTransition) {
            playerInput.DeactivateInput();
            abilityHolder.OnAbilityInventory();
        }

        loadingScene = false;
    }

    public void OnRunStart() {
        Debug.Log("Run Start");
        playerInput.ActivateInput();
        transition.SetTrigger("RunStart");
        abilityHolder.OnAbilityInventory();
        abilityInventoryManager.RefreshHotBar();
        abilityInventoryManager.RefreshEnabledAugments();
    }

    public void OnRunEnd() {
        playerInput.DeactivateInput();
        transition.ResetTrigger("RunStart");
        LoadNextLevel(nextLevel);
    }
}
