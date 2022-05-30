using System.Collections.Generic;
using UnityEngine;

public class PageSwitcher : MonoBehaviour
{
    private Dictionary<string, Page> _pages;

    private void Start()
    {
        _pages = new Dictionary<string, Page>();
        Page[] pages = GetComponentsInChildren<Page>();

        foreach (Page page in pages)
        {
            if (page is Aducation aducation)
            {
                _pages.Add(nameof(aducation), aducation);
            }
            else if (page is Dossier dossier)
            {
                _pages.Add(nameof(dossier), dossier);
            }
            else if (page is Entertaiment entertaiment)
            {
                _pages.Add(nameof(entertaiment), entertaiment);
            }
            else if (page is PC pc)
            {
                _pages.Add(nameof(pc), pc);
            }
            else if (page is Soft soft)
            {
                _pages.Add(nameof(soft), soft);
            }
            else if (page is WorkPage work)
            {
                _pages.Add(nameof(work), work);
            }
        }
    }

    public void OpenTab(string header)
    {
        header = header.ToLower();
        if (_pages.ContainsKey(header) == false)
        {
            throw new System.Exception($"Pages Doesn't contain {header}");
        }

        foreach (var pair in _pages)
        {
            pair.Value.gameObject.SetActive(pair.Key == header);
        }
    }
}
