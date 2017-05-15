using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace NoMoreCry
{
    class NoMoreCry : ServiceBase
    {

        public NoMoreCry()
        {
            this.ServiceName = "NoMoreCry";
            this.EventLog.Source = "NoMoreCry";
            this.EventLog.Log = "Application";
            
            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = false;
            this.CanShutdown = false;
            this.CanStop = false;

            if (!EventLog.SourceExists("NoMoreCry"))
                EventLog.CreateEventSource("NoMoreCry", "Application");

            System.Threading.Mutex _MsWinZonesMut = null;

            try
            {
                _MsWinZonesMut = System.Threading.Mutex.OpenExisting("MsWinZonesCacheCounterMutexA0");
                _MsWinZonesMut.WaitOne();
            }
            catch
            {
                _MsWinZonesMut = new System.Threading.Mutex(true, "MsWinZonesCacheCounterMutexA0");
            }

            System.Threading.Mutex _MsWinZonesMut1 = null;

            try
            {
                _MsWinZonesMut1 = System.Threading.Mutex.OpenExisting("MsWinZonesCacheCounterMutexA");
                _MsWinZonesMut1.WaitOne();
            }
            catch
            {
                _MsWinZonesMut1 = new System.Threading.Mutex(true, "MsWinZonesCacheCounterMutexA");
            }
        }

        static void Main()
        {
            ServiceBase.Run(new NoMoreCry());
        }

      
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
        }

        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            return base.OnPowerEvent(powerStatus);
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            base.OnSessionChange(changeDescription);
        }
    }
}
