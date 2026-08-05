using UnityEngine;

public class DogManager : MonoBehaviour
{
    public GameObject dogHappyPrefab;
    public GameObject dogLaughPrefab;

    private GameObject currentDog;

    public void ShowDogWithDuck()
    {
        if (currentDog != null) Destroy(currentDog);

        currentDog = Instantiate(dogHappyPrefab, transform.position, Quaternion.identity);
        currentDog.SetActive(true); // make visible
        Animator anim = currentDog.GetComponent<Animator>();
        anim.SetTrigger("SlideUpTrigger");

        // After 2s, slide down and hide
        Invoke("HideDog", 2f);
        FindObjectOfType<UIManager>().ShowRoundResult(true);
    }

    public void ShowDogLaugh()
    {
        if (currentDog != null) Destroy(currentDog);

        currentDog = Instantiate(dogLaughPrefab, transform.position, Quaternion.identity);
        currentDog.SetActive(true); // make visible
        Animator anim = currentDog.GetComponent<Animator>();
        anim.SetTrigger("SlideUpTrigger");

        // After 2s, slide down and hide
        Invoke("HideDog", 2f);
        FindObjectOfType<UIManager>().ShowBirdEscaped();
    }

    private void HideDog()
    {
        if (currentDog != null)
        {
            Animator anim = currentDog.GetComponent<Animator>();
            anim.SetTrigger("SlideDownTrigger");
            Destroy(currentDog, 1f); // remove after slide down
        }
    }
}
