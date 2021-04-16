using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patnashki_serialization
{
    [Serializable]
    class Results : IComparable
    {
        private string name;
        private ulong period;
        private DateTime startTime;
        private ulong steps;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public ulong Period
        {
            get
            {
                return period;
            }
        }
        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
        }
        public ulong Steps
        { get
            {
                return steps;
            }
        }
        public Results()
        { }
        public Results(string Name_, ulong PERIOD, DateTime start,ulong Steps_)
        {
            if (Name == "")
                throw new Exception("Неверный формат ввода: имя не должно быть пустым!");
            name = Name_;
            period = PERIOD;
            startTime = start;
            steps = Steps_;
        }
        public int CompareTo(object obj)
        {
            if (period < (obj as Results).Period)
                return 1;
            if (period == (obj as Results).Period)
                return 0;
            return -1;
        }
        
    }
    class ComparerResults:IComparer<Results>
    {
        public int Compare(Results a, Results b)
        {
            if (a.Steps < b.Steps)
                return 1;
            if (a.Steps == b.Steps)
                return 0;
            return -1;
        }
    }
}
