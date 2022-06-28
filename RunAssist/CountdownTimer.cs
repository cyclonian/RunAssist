using System.Diagnostics;

namespace PositiveChaos.RunAssist
{
    public class CountdownTimer : IDisposable
    {
        public Stopwatch _stopWatch = new Stopwatch();

        public Action TimeChanged;
        public Action CountdownFinished;
        public Action CountdownWarning;
        public Action CountdownWarning2;

        public bool IsRunning => timer.Enabled;

        public int StepMs
        {
            get => timer.Interval;
            set => timer.Interval = value;
        }

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private TimeSpan _max = TimeSpan.FromMilliseconds(30000);
        private TimeSpan _warning = TimeSpan.FromMilliseconds(10000);
        private TimeSpan _warning2 = TimeSpan.FromMilliseconds(10000);

        public TimeSpan TimeLeft => (_max.TotalMilliseconds - _stopWatch.ElapsedMilliseconds) > 0 ? TimeSpan.FromMilliseconds(_max.TotalMilliseconds - _stopWatch.ElapsedMilliseconds) : TimeSpan.FromMilliseconds(0);

        private bool _targetStop => (_max.TotalMilliseconds - _stopWatch.ElapsedMilliseconds) < 0;
        private bool _targetStopPerformed = false;
        private bool _targetWarning => (_max.TotalMilliseconds - _stopWatch.ElapsedMilliseconds) < _warning.TotalMilliseconds;
        private bool _warningPerformed = false;
        private bool _targetWarning2 => (_max.TotalMilliseconds - _stopWatch.ElapsedMilliseconds) < _warning2.TotalMilliseconds;
        private bool _warning2Performed = false;

        public string TimeLeftStr => TimeLeft.ToString(@"\mm\:ss");

        public string TimeLeftMsStr => TimeLeft.ToString(@"mm\:ss\.fff");

        private void TimerTick(object sender, EventArgs e)
        {
            TimeChanged?.Invoke();

            if (_targetWarning && !_warningPerformed)
            {
                _warningPerformed = true;
                CountdownWarning?.Invoke();
            }
            if (_targetWarning2 && !_warning2Performed)
            {
                _warning2Performed = true;
                CountdownWarning2?.Invoke();
            }
            if (_targetStop && !_targetStopPerformed)
            {
                _targetStopPerformed = true;
                CountdownFinished?.Invoke();
                _stopWatch.Stop();
                timer.Enabled = false;
            }
        }

        public CountdownTimer(int min, int sec)
        {
            SetTime(min, sec);
            Init();
        }

        public CountdownTimer(TimeSpan ts)
        {
            SetTime(ts);
            Init();
        }

        public CountdownTimer()
        {
            Init();
        }

        private void Init()
        {
            StepMs = 1000;
            timer.Tick += new EventHandler(TimerTick);
        }

        public void SetTime(TimeSpan ts)
        {
            _max = ts;
            TimeChanged?.Invoke();
        }

        public void SetTime(int min, int sec = 0) => SetTime(TimeSpan.FromSeconds(min * 60 + sec));

        public void SetWarning(TimeSpan ts)
        {
            _warning = ts;
            TimeChanged?.Invoke();
        }
        public void SetWarning(int min, int sec = 0) => SetWarning(TimeSpan.FromSeconds(min * 60 + sec));

        public void SetWarning2(TimeSpan ts)
        {
            _warning2 = ts;
            TimeChanged?.Invoke();
        }
        public void SetWarning2(int min, int sec = 0) => SetWarning2(TimeSpan.FromSeconds(min * 60 + sec));

        public void Start()
        {
            timer.Start();
            _stopWatch.Start();
        }

        public void Pause()
        {
            timer.Stop();
            _stopWatch.Stop();
        }

        public void Stop()
        {
            Reset();
            Pause();
        }

        public void Reset()
        {
            _targetStopPerformed = false;
            _warningPerformed = false;
            _warning2Performed = false;
            _stopWatch.Reset();
        }

        public void Restart()
        {
            _stopWatch.Reset();
            timer.Start();
        }

        public void Dispose() => timer.Dispose();
    }
}