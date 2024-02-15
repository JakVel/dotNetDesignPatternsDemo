using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace DesignPatterns101.Behavioral_Patterns
{
    public class WeatherStation
    {
        private List<DisplayDevice> observers = new List<DisplayDevice>();
        private string currentWeather;
        private bool shouldRun = false; 

        public void AddObserver(DisplayDevice observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(string observerDisplayLocation)
        {
            DisplayDevice observer = observers.Where(o => o.HasDisplayLocationEqualTo(observerDisplayLocation)).FirstOrDefault();
            if(observer != null)
                observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(currentWeather);
            }
        }

        public void SetWeather(string newWeather)
        {
            currentWeather = newWeather;
            NotifyObservers();
        }

        public void ToggleRunFlag()
        {
            shouldRun = !shouldRun;
        }

        public bool ShouldKeepRunning()
        {
            return shouldRun;
        }

        //public DisplayDevice? GetDisplayDevice(string observerName)
        //{
        //    List<DisplayDevice> displayDevices = observers.Where(o => o.GetType() == DisplayDevice)
        //}
    }

    // Observer Interface
    public interface IObserver
    {
        void Update(string weather);
    }

    // Concrete Observer (DisplayDevice)
    public class DisplayDevice : IObserver
    {
        private string displayLocation;
        private readonly ILogger _log;

        public DisplayDevice(string location, ILogger log)
        {
            _log = log;
            displayLocation = location;
        }

        public void Update(string weather)
        {
            _log.LogWarning($"Display at {displayLocation} updated. Current weather: {weather}");
        }

        public bool HasDisplayLocationEqualTo(string givenDisplayLocation)
        {
            return displayLocation.Equals(givenDisplayLocation, StringComparison.OrdinalIgnoreCase);
        }
    }
}
