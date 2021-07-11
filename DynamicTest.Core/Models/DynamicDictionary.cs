using System.Collections.Generic;
using System.Dynamic;

namespace DynamicTest.Core.Models
{
    public class DynamicDictionary : DynamicObject
    {
        private readonly Dictionary<string, object> _dictionary = new();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var name = binder.Name;
            return _dictionary.TryGetValue(name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name] = value;
            return true;
        }
        //The GetDynamicMemberNames method of DynamicObject class must be overridden and return the property names to perform data operation and editing while using DynamicObject.
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _dictionary?.Keys;
        }
        
        public override bool TrySetIndex(
            SetIndexBinder binder, object[] indexes, object value)
        {
            string index = (string)indexes[0];

            // If a corresponding property already exists, set the value.
            if (_dictionary.ContainsKey("Property" + index))
                _dictionary["Property" + index] = value;
            else
                // If a corresponding property does not exist, create it.
                _dictionary.Add("Property" + index, value);
            return true;
        }
    }
}