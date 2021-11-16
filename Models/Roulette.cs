using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Roulette{
        public string Id { get; set; }
        public bool IsOpen { get; set; } = false;
        public DateTime? DateOpen { get; set; }
        public DateTime? DateClosed { get; set; }
        public IDictionary<string, double>[] Doard { get; set; } = new IDictionary<string, double>[39];
        public Roulette()
        {
            this.Init();
        }
        static void Main(string[] args) { }
        private void Init()
        {
            for (int i = 0; i < Doard.Length; i++)
            {
                Doard[i] = new Dictionary<string, double>();
            }
        }
    }
}
