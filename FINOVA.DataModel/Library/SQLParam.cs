using FINOVA.DataModel.Common;


namespace FINOVA.DataModel.Library
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class SQLParam : Attribute
    {
        public SQLParamPlaces Usage { get; set; } = SQLParamPlaces.Default;
        public string ReaderName { get; set; }
        public string InputParamName { get; set; }
    }
}
