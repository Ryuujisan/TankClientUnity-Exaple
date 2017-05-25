using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    public const string INTERNET_CONNECTION_CHANGED_EVENT = "INTERNET_CONNECTION_CHANGED_EVENT";
    public const string WEBSOCKET_OPEN_EVENT = "WEBSOCKET_OPEN_EVENT";
    public const string WEBSOCKET_CLOSED_EVENT = "WEBSOCKET_CLOSED_EVENT";
    public const string WEBSOCKET_ERROR_EVENT = "WEBSOCKET_ERROR_EVENT";

    private Dictionary<string, UnityEvent> eventDictionary = new Dictionary<string, UnityEvent>();
    private Dictionary<string, bool> addOnceDictionary = new Dictionary<string, bool>();

    void Awake()
    {
        if (GameManager.EventManager == null)
        {
            GameManager.EventManager = this;
        }
    }

    public void Add(string eventName, UnityAction listener)
    {
        UnityEvent eventData = null;
        if (eventDictionary.TryGetValue(eventName, out eventData))
        {
            eventData.AddListener(listener);
        }
        else
        {
            eventData = new UnityEvent();
            eventData.AddListener(listener);

            eventDictionary.Add(eventName, eventData);
            addOnceDictionary.Add(eventName, false);
        }
    }

    public void AddOnce(string eventName, UnityAction listener)
    {
        UnityEvent eventData = null;
        if (eventDictionary.TryGetValue(eventName, out eventData))
        {
            eventData.AddListener(listener);
        }
        else
        {
            eventData = new UnityEvent();
            eventData.AddListener(listener);

            eventDictionary.Add(eventName, eventData);
            addOnceDictionary.Add(eventName, true);
        }
    }

    public void Dispatch(string eventName)
    {
        UnityEvent eventData = null;
        if (eventDictionary.TryGetValue(eventName, out eventData))
        {
            eventData.Invoke();

            if (addOnceDictionary.ContainsKey(eventName))
            {
                if (addOnceDictionary[eventName])
                {
                    RemoveAll(eventName);
                }
            }
        }
    }

    public void Remove(string eventName, UnityAction listener)
    {
        UnityEvent eventData = null;
        if (eventDictionary.TryGetValue(eventName, out eventData))
        {
            eventData.RemoveListener(listener);
        }
    }

    public void RemoveAll(string eventName)
    {
        UnityEvent eventData = null;
        if (eventDictionary.TryGetValue(eventName, out eventData))
        {
            eventData.RemoveAllListeners();
        }
    }

    public void Clear()
    {
        foreach (string value in eventDictionary.Keys)
        {
            RemoveAll(value);
        }

        eventDictionary.Clear();
        addOnceDictionary.Clear();
    }
}

