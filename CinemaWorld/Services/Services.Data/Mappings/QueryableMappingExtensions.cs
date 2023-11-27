
namespace CinemaWorld.Services.Services.Data.Mapping
{
    using System.Linq;
    using System.Linq.Expressions;
    using AutoMapper.QueryableExtensions;
    public static class QueryableMappingExtensions
    {
        //Phương thức mở rộng cho IQueryable<TDestination>
        //TDestination là một tham số kiểu type param, kiểu để tạo một lớp hoặc phương thức chấp nhận nhiều kiểu dữ liệu khác nhau

        //Expression<Func<... là một mảng của các biểu thức lambda, mỗi biểu thức đại diện cho một thành viên đối tượng
        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            params Expression<Func<TDestination, object>>[] membersToExPand)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            //source.ProjectTo: Sử dụng AutoMapper để thực hiện ánh xạ từ source
            //null: chế độ mở rọng(expand mode) có nghĩa là mọi thành viên đều được mở rộng (bố sung thêm t.t vào kết quả ánh xạ)
            return source.ProjectTo(AutoMapperConfig.MapperInstance.ConfigurationProvider, null, membersToExPand);
        }

        public static IQueryable<TDestination> To<TDestination>(
        this IQueryable source,
        object parameters)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo<TDestination>(AutoMapperConfig.MapperInstance.ConfigurationProvider, parameters);
        }
    }
}
