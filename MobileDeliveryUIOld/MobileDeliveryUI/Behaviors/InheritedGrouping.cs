using MobileDeliveryMVVM.BaseClasses;
using System.Collections.Generic;

namespace MobileDeliveryUI.Behaviors
{
    public class InheritedGrouping<K, T> : Grouping<K, T>
    {
        public InheritedGrouping(K key, IEnumerable<T> items) :
            base(key, items)
        {

        }
    }
}