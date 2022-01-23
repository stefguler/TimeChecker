﻿using System;
using System.Diagnostics;
using System.Windows.Threading;

namespace TimeCheckerWPF5._0.Utilities
{
    public class TimeWatch
    {
        //Declare a handler for when the watchtick is triggered to run of type of own arguments (timeSpan)
        internal EventHandler<TickEventArgs> TickEvent;
        internal DispatcherTimer dispatcherTimer = new();
        private readonly Stopwatch stopwatch = new();
        private const string TimeReset ="00:00:00";

        public TimeWatch()
        {
            //Subscribing the dispatcherTimer on tick to call the OnDispatchTimerTick event and define the Time interval of the TimeSpan to tick.
            dispatcherTimer.Tick += new EventHandler(OnDispatchTimerTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
        }

        //Stopwatch Start, Stop and Reset functions
        public void StopwatchStart()
        {
            stopwatch.Start();
            dispatcherTimer.Start();
        }

        public void StopwatchStop()
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }
        }

        public string StopwatchReset()
        {
            stopwatch.Reset();
            return TimeReset;
        }

        //Triggering the EventHandler
        protected virtual void OnWatchTickEvent(TickEventArgs e)
        {
            TickEvent?.Invoke(this, e);
        }

        //Behavior if StopwatchTick Event was triggered
        void OnDispatchTimerTick(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                TickEventArgs tickEvent = new()
                {
                    TimeSpan = stopwatch.Elapsed
                };
                OnWatchTickEvent(tickEvent);
            }
        }

    }
}