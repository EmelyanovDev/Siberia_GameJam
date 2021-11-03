using System.Collections.Generic;
using System.Linq;

namespace Game_Asset.Scripts.BackgroundSystem
{
    public class ObjectsPull <TSource>
    {
        private List<TSource> _pull = new List<TSource>();
        
        public ObjectsPull()
        {
           
        }
        
        public ObjectsPull(List<TSource> pull)
        {
            _pull = pull;
        }
        
        public ObjectsPull(IEnumerable<TSource> pull)
        {
            _pull = pull.ToList();
        }

        public TSource this[int index] => _pull[index];

        public void AddObject(TSource element)
        {
            _pull.Add(element);
        }

        public void RemoveObject(TSource element)
        {
            _pull.Remove(element);
        }
    }
}