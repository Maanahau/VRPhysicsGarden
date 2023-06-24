using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Components;
using TMPro;

public class StartGame : MonoBehaviour
{
    //new profile stuff
    [SerializeField] GameObject nameTextBox;
    [SerializeField] GameObject tooltipTextBox;

    //load profile stuff
    [SerializeField] GameObject toggleGroup;
    [SerializeField] GameObject profileBoxPrefab;

    public void New()
    {
        //make new profile
        string name = nameTextBox.GetComponent<TMP_InputField>().text;
        if (name.Length > 0)
        {
            if (ProfileManager.NewProfile(name))
            {
                //load garden scene
                SceneManager.LoadSceneAsync(1);
            }
            else
            {
                tooltipTextBox.GetComponent<LocalizeStringEvent>().SetEntry("NameUsed");
            }
        }
        else
        {
            tooltipTextBox.GetComponent<LocalizeStringEvent>().SetEntry("EmptyName");
            return;
        }
    }

    public void ClearProfileList()
    {
        for(int i = 0; i < toggleGroup.transform.childCount; i++)
        {
            Destroy(toggleGroup.transform.GetChild(i).gameObject);
        }
    }

    public void LoadProfileList()
    {
        //load profiles from json
        ProfileManager.Profile[] profiles = ProfileManager.GetAllProfiles();
        if (profiles == null) return;

        //make profile toggle group tall enough
        toggleGroup.GetComponent<RectTransform>().sizeDelta = new Vector2(25f, 3.5f * profiles.Length);

        //make a button for every profile
        foreach(ProfileManager.Profile profile in profiles)
        {
            GameObject newProfileBox =  Instantiate(profileBoxPrefab, toggleGroup.transform);
            newProfileBox.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = profile.name;
        } 
    }

    public void LoadProfile()
    {
        if (ProfileToggleSelector.selectedName == null)
            return;
        ProfileManager.LoadProfile(ProfileToggleSelector.selectedName);
        SceneManager.LoadSceneAsync("Garden");
    }

    public void DeleteSelectedProfile()
    {
        ProfileManager.DeleteProfile(ProfileToggleSelector.selectedName);
    }
}
