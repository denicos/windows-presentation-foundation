using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace wpfStopClock
{
    /// <summary>
    /// This class is a simple time ticker class.
    /// </summary>
  public class Ticker : FrameworkElement

    {
      private TimeSpan currentInterval;
      private DispatcherTimer tmr;
      private DateTime startTime;

      public static readonly DependencyProperty DisplayIntervalProperty =
          DependencyProperty.Register("DisplayInterval", typeof(string), typeof(Ticker), null);


      public string DisplayInterval
      {
          get { return (string)GetValue(DisplayIntervalProperty); }
          set { SetValue(DisplayIntervalProperty, value); }
      }
     

      public Ticker()
      {
          tmr = new DispatcherTimer();
          tmr.Interval = new TimeSpan(0, 0, 0, 0, 100);
          tmr.Tick += new EventHandler(tmr_Tick);
          UpdateValues(true);
      }
      public void Start()
      {
          if (!tmr.IsEnabled)
          {
              startTime = DateTime.Now - currentInterval;
              tmr.Start();
          }
      }
      public void Stop()
      {
          if (tmr.IsEnabled)
          {
              tmr.Stop();
          }
      }
      public void Clear()
      {
          startTime = DateTime.Now;
          UpdateValues(true);
      }
      private void tmr_Tick(object sender, EventArgs e)
      {
          UpdateValues(false);
      }

      private void UpdateValues(bool reset)
      {
          if (reset)
              currentInterval = new TimeSpan();
          else
              currentInterval = DateTime.Now - startTime;
          DisplayInterval = string.Format("{0:D2} : {1:D2}", currentInterval.Minutes, currentInterval.Seconds);
      }

    }
}
