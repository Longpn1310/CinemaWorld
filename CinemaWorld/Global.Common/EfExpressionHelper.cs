using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Reflection;

namespace CinemaWorld.Global.Common
{
    public static class EfExpressionHelper
    {
        private static readonly Type StringType = typeof(string);
        private static readonly MethodInfo ValueBufferGetValueMethod =
            typeof(ValueBuffer).GetRuntimeProperties().Single(p => p.GetIndexParameters().Any()).GetMethod;

        private static readonly MethodInfo EfPropertyMethod =
            typeof(EF).GetTypeInfo().GetDeclaredMethod(nameof(Property));

    }
}
