using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Catalog.Application.Common.Resolvers;

public class PrivateSetterContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, 
        MemberSerialization memberSerialization)
    {
        var jsonProperty = base.CreateProperty(member, memberSerialization);

        if(jsonProperty.Writable)
            return jsonProperty;

        if(member is PropertyInfo propertyInfo)
        {
            var setter = propertyInfo.GetSetMethod(true);
            jsonProperty.Writable = setter != null;
        }

        return jsonProperty;
    }
    //EnvironmentVariableTarget jsonProperty = base.CreateProperty();
}