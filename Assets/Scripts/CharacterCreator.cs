using UnityEngine;
using UnityEngine.UI;

public class CharacterCreator : MonoBehaviour
{
    [SerializeField] private GameObject [] characterPrefab;
    //[SerializeField] Button buttonLeft, buttonRight;
    private int currentIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = 0;
        ChangeCharacter(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextCharacter(){
        if (currentIndex == characterPrefab.Length - 1)
        {
            currentIndex = 0;
        }
        else{
            currentIndex++;
        }
        ChangeCharacter(currentIndex);
    }

    public void PreviousCharacter(){
        if (currentIndex == 0)
        {
            currentIndex = characterPrefab.Length - 1;
        }
        else{
            currentIndex--;
        }
        ChangeCharacter(currentIndex);
    }

    public void ChangeCharacter(int index)
    {
        for (int i = 0; i < characterPrefab.Length; i++)
        {
            if (i == index)
            {
                characterPrefab[i].SetActive(true);
            }
            else
            {
                characterPrefab[i].SetActive(false);
            }
        }
    }
}
