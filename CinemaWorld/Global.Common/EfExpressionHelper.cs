using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Reflection;

namespace CinemaWorld.Global.Common
{
    public static class EfExpressionHelper
    {
        private static readonly Type StringType = typeof(string);
        //lấy giá trị của valueBuffer trong EF
        //GetRunTimeProperties() truy xuất thuộc tính của ValueBuffer
        private static readonly MethodInfo ValueBufferGetValueMethod =
            typeof(ValueBuffer).GetRuntimeProperties().Single(p => p.GetIndexParameters().Any()).GetMethod;

        private static readonly MethodInfo EfPropertyMethod =
            typeof(EF).GetTypeInfo().GetDeclaredMethod(nameof(Property));

        //Xây dựng một biết thức Expression để tìm một đối tượng dựa trên id
        public static Expression<Func<TEntity, bool>> BuildByIdPredicate<TEntity>(
            DbContext dbcontext,
            object[] id)
            where TEntity : class
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var entityType = typeof(TEntity);
            //trong biết thức lamda thì e biết thị cho tên tham số
            var entityParameter = Expression.Parameter(entityType, "e");
            var keyProperties = dbcontext.Model.FindEntityType(entityType).FindPrimaryKey().Properties;
            var predicate = BuildPredicate(keyProperties, new ValueBuffer(id), entityParameter);
            //Lamda miêu tả đối tượng
            return Expression.Lambda<Func<TEntity, bool>>(predicate, entityParameter);
        }
        //tạo một BinaryExpression so sánh properties của đối tượng với giá trị id
        private static BinaryExpression BuildPredicate(
            IReadOnlyList<IProperty> keyProperties,
            ValueBuffer keyValues,
            ParameterExpression entityParameter
            )
        {
            var keyValuesConstant = Expression.Constant(keyValues);

            BinaryExpression predicate = null;
            for( var i = 0;i< keyProperties.Count; i++)
            {
                var property = keyProperties[i];
                var equalsExpression = Expression.Equal(
                    Expression.Call(
                        EfPropertyMethod.MakeGenericMethod(property.ClrType),
                        entityParameter,
                        Expression.Constant(property.Name, StringType)),
                    Expression.Convert(
                        Expression.Call(keyValuesConstant, ValueBufferGetValueMethod, Expression.Constant(i))
                        , property.ClrType));

                predicate = predicate == null ? equalsExpression : Expression.AndAlso(predicate, equalsExpression);
            }
            return predicate;
        }

    }
}
