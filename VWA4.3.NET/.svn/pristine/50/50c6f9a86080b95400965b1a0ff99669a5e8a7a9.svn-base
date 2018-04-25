using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace UserControls
{
    [Serializable]
    public class ReportParameter : ISerializable
    {
        string _name, _value, _display, _type;

        public string ParamType
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string ParamValue
        {
            get { return _value; }
            set { this._value = value; }
        }
        public string DisplayValue
        {
            get { return _display; }
            set { _display = value; }
        }
        public override string ToString()
        {
            return _name + " = " + _display;
        }
        public ReportParameter(string name):this(name, "", "", "String")
        {
        }
        public ReportParameter(string name, string value, string display, string type)
        {
            _name = name;
            _value = value;
            _display = display;
            _type = type;
        }
        public ReportParameter(ReportParameter param)
        {
            _name = param._name;
            _value = param._value;
            _display = param._display;
            _type = param._type;
        }
        protected ReportParameter(SerializationInfo info, StreamingContext context)
        {
            _name = info.GetString("ReportParameterName");
            _value = info.GetString(_name + "Value");
            _display = info.GetString(_name + "Display");
            _type = info.GetString(_name + "ParamType");
        }
        [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //base.GetObjectData(info, context);
            info.AddValue("ReportParameterName", _name);
            info.AddValue(_name + "Value", _value);
            info.AddValue(_name + "Display", _display);
            info.AddValue(_name + "ParamType", _type);
        }
    }
}
