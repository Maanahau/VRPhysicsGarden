using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class ProfileManager : MonoBehaviour
{

    //fields in serializable objects must be public or they'll get ignored
    [System.Serializable] public struct Profile
    {
        public string name;
        public int[] completedQuests;
        public int[] unlockedConcepts;
        public int[] unlockedTools;
        public int[] unlockedMaps;
        public int[] unlockedDatacards;

        public Profile(string newName)
        {
            name = newName;
            completedQuests = null;
            unlockedConcepts = null;
            unlockedDatacards = null;
            unlockedTools = null;
            unlockedMaps = null;
        }
    }
    //profile currently being used in game
    public static Profile activeProfile;
    private static string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/profiles.json";
    }


    public static bool NewProfile(string name)
    {
        string jsonString;

        if (File.Exists(savePath))
        {
            Profile[] savedProfiles = JsonArrayWrapper.FromJson<Profile>(File.ReadAllText(savePath));

            //check if name is already used, return false if name is already used
            foreach(Profile profile in savedProfiles)
                if (profile.name == name) return false;

            //save new profile and append to old profiles
            activeProfile = new Profile(name);
            Profile[] updatedProfiles = new Profile[savedProfiles.Length + 1];
            savedProfiles.CopyTo(updatedProfiles, 0);
            updatedProfiles[updatedProfiles.Length - 1] = activeProfile;

            jsonString = JsonArrayWrapper.ToJson(updatedProfiles, true);
        }
        else
        {
            //save new profile
            activeProfile = new Profile(name);
            Profile[] newProfile = { activeProfile };

            jsonString = JsonArrayWrapper.ToJson(newProfile, true);
        }

        //create new file
        File.WriteAllText(savePath, jsonString);
        return true;
    }

    public static void SaveProfile()
    {
        //DEBUG
        if (activeProfile.name == "TestingProfile") return;

        //load file
        Profile[] savedProfiles = JsonArrayWrapper.FromJson<Profile>(File.ReadAllText(savePath));

        //put active profile on top of the list
        List<Profile> profilesList = new List<Profile>();
        profilesList.Add(activeProfile);

        foreach(Profile profile in savedProfiles)
        {
            if (profile.name != activeProfile.name)
                profilesList.Add(profile);
        }
        
        string jsonString = JsonArrayWrapper.ToJson(profilesList.ToArray(), true);
        File.WriteAllText(savePath, jsonString);
    }

    public static void LoadProfile(string name)
    {
        if (File.Exists(savePath))
        {
            Profile[] savedProfiles = JsonArrayWrapper.FromJson<Profile>(File.ReadAllText(savePath));
            foreach(Profile profile in savedProfiles)
            {
                if(profile.name == name)
                {
                    activeProfile = profile;
                    break;
                }
            }
        }
        else
        {
            return;
        }
    }

    public static Profile[] GetAllProfiles()
    {
        if (File.Exists(savePath))
            return JsonArrayWrapper.FromJson<Profile>(File.ReadAllText(savePath));
        else
            return null;
    }

    public static void DeleteProfile(string name)
    {
        //load file
        Profile[] savedProfiles = JsonArrayWrapper.FromJson<Profile>(File.ReadAllText(savePath));

        //delete active profile
        Profile[] updatedProfiles = new Profile[savedProfiles.Length - 1];
        bool foundProfile = false;
        for(int i = 0; i < savedProfiles.Length; i++)
        {
            if (!foundProfile)
            {
                if(savedProfiles[i].name == name)
                {
                    foundProfile = true;
                }
                else
                {
                    updatedProfiles[i] = savedProfiles[i];
                }
            }
            else
            {
                updatedProfiles[i - 1] = savedProfiles[i];
            }
        }

        string jsonString = JsonArrayWrapper.ToJson(updatedProfiles, true);
        File.WriteAllText(savePath, jsonString);
    }

    public static void AddCompletedQuest(int id)
    {
        int[] updatedCompletedQuests;
        if(activeProfile.completedQuests != null)
        {
            updatedCompletedQuests = new int[activeProfile.completedQuests.Length + 1];
            activeProfile.completedQuests.CopyTo(updatedCompletedQuests, 0);
            updatedCompletedQuests[updatedCompletedQuests.Length - 1] = id;
        }
        else
        {
            updatedCompletedQuests = new int[] { id };
        }

        activeProfile.completedQuests = updatedCompletedQuests;
        SaveProfile();
    }

    public static void AddUnlockedConcept(int id)
    {
        int[] updatedConcepts;
        if(activeProfile.unlockedConcepts != null)
        {
            updatedConcepts = new int[activeProfile.unlockedConcepts.Length + 1];
            activeProfile.unlockedConcepts.CopyTo(updatedConcepts, 0);
            updatedConcepts[updatedConcepts.Length - 1] = id;
        }
        else
        {
            updatedConcepts = new int[] { id };
        }

        activeProfile.unlockedConcepts = updatedConcepts;
    }

    public static void AddUnlockedTool(int id)
    {
        int[] updatedTools;
        if(activeProfile.unlockedTools != null)
        {
            updatedTools = new int[activeProfile.unlockedTools.Length + 1];
            activeProfile.unlockedTools.CopyTo(updatedTools, 0);
            updatedTools[updatedTools.Length - 1] = id;
        }
        else
        {
            updatedTools = new int[] { id };
        }

        activeProfile.unlockedTools = updatedTools;
    }

    public static void AddUnlockedMap(int id)
    {
        int[] updatedMaps;
        if(activeProfile.unlockedMaps != null)
        {
            updatedMaps = new int[activeProfile.unlockedMaps.Length + 1];
            activeProfile.unlockedMaps.CopyTo(updatedMaps, 0);
            updatedMaps[updatedMaps.Length  - 1] = id;
        }
        else
        {
            updatedMaps = new int[] { id };
        }

        activeProfile.unlockedMaps = updatedMaps;
    }

    public static void AddUnlockedDatacard(int id)
    {
        int[] updatedDatacards;
        if(activeProfile.unlockedDatacards != null)
        {
            updatedDatacards = new int[activeProfile.unlockedDatacards.Length + 1];
            activeProfile.unlockedDatacards.CopyTo(updatedDatacards, 0);
            updatedDatacards[updatedDatacards.Length - 1] = id;
        }
        else
        {
            updatedDatacards = new int[] { id };
        }

        activeProfile.unlockedDatacards = updatedDatacards;
    }
}
