using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Core.Abstract
{
    public interface IMetrics
    {
        List<Metrics> GetAll();
        void Insert(Metrics metrics);
    }

    public class MetricsService : IMetrics
    {
        private List<Metrics> _metrics;

        public MetricsService()
        {
            _metrics = new List<Metrics>();
        }

        public List<Metrics> GetAll()
        {
            return _metrics;
        }

        public void Insert(Metrics metric)
        {
            _metrics.Add(metric);
        }
    }
}
