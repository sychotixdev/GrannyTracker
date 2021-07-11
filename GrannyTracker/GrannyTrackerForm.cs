using GrannyTracker.BusinessLogic;
using GrannyTracker.MemoryStuff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrannyTracker
{
    public partial class GrannyTrackerForm : System.Windows.Forms.Form
    {

        private readonly System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        public GrannyTrackerForm()
        {
            InitializeComponent();

            // Start the update timer
            MemoryTracker.Instance.StartTimer();

            ActivateTimer();

        }

        private void grannyMap_Paint(object sender, PaintEventArgs e)
        {
            MapManager.Instance.UpdatePictureMap(grannyMap, e.Graphics, debugTextBox);
        }

        void ActivateTimer()
        {
            // Start the Timer
            _timer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 5 seconds.
            _timer.Interval = 100;
            _timer.Start();
            // Stop with _timer.Stop();
        }

        // This function is giogin to be called every 2 seconds
        void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            grannyMap.Refresh();
        }
    }
}
