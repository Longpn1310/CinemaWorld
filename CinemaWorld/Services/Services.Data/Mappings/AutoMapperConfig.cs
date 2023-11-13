
namespace CinemaWorld.Services.Services.Data.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;
    using AutoMapper.Configuration;
    public static class AutoMapperConfig
    {
        private static bool initialized;

        public static IMapper MapperInstance { get; set; }

        // Đăng ký quy tắc ánh xạ
        public static void RegisterMappings(params Assembly[] assemblies)
        {
            //đảm bảo initialized được gọi 1 lần
            if (initialized)
            {
                return;
            }
            initialized = true;

            // Chứa dánh sách các loại(types) được xuất(exported)
            // Các loại được sử dụng để quy tắc ánh xạ, bao gồm cả IMapForm<>, IMapTo<>, IHaveCustomMappings
            var types = assemblies.SelectMany(a => a.GetExportedTypes()).ToList();
            // tạo một instance từ MapperConfigurationExpression để cấu hình auto mapper
            var config = new MapperConfigurationExpression();
            // Tạo một profile tên RèlectionProfile để đặt theo quy tắc ánh xạ
            config.CreateProfile(
                "ReflectionProfile",
                configuration =>
                {
                    // IMapFrom<>
                    foreach (var map in GetFromMaps(types))
                    {
                        configuration.CreateMap(map.Source, map.Destination);
                    }

                    // IMapTo<>
                    foreach (var map in GetToMaps(types))
                    {
                        configuration.CreateMap(map.Source, map.Destination);
                    }

                    // IHaveCustomMappings
                    foreach (var map in GetCustomMappings(types))
                    {
                        map.CreateMappings(configuration);
                    }
                });
            MapperInstance = new Mapper(new MapperConfiguration(config));
        }
        //Lấy ra ánh xạ từ lớp DTO đến IMapFrom<>
        //IMapFrom<> và IMapTo<> Được đánh dấu bằng một lớp TSource
        //TSource chính là lớp nguồn dữ liệu để ánh xạ
        private static IEnumerable<TypesMap> GetFromMaps(IEnumerable<Type> types)
        {
            //Lấy ra các loại(types) và interfaces của chúng
            var fromMaps = from t in types
                           from i in t.GetTypeInfo().GetInterfaces()
                           where i.GetTypeInfo().IsGenericType &&
                           i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                           !t.GetTypeInfo().IsAbstract &&
                           !t.GetTypeInfo().IsInterface
                           select new TypesMap
                           {
                               Source = i.GetTypeInfo().GetGenericArguments()[0],
                               Destination = t,
                           };
            return fromMaps;
        }
        private static IEnumerable<TypesMap> GetToMaps(IEnumerable<Type> types)
        {
            var toMaps = from t in types
                         from i in t.GetTypeInfo().GetInterfaces()
                         where i.GetTypeInfo().IsGenericType &&
                               i.GetTypeInfo().GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                               !t.GetTypeInfo().IsAbstract &&
                               !t.GetTypeInfo().IsInterface
                         select new TypesMap
                         {
                             Source = t,
                             Destination = i.GetTypeInfo().GetGenericArguments()[0],
                         };

            return toMaps;
        }
        private static IEnumerable<IHaveCustomMappings> GetCustomMappings(IEnumerable<Type> types)
        {
            var customMaps = from t in types
                             from i in t.GetTypeInfo().GetInterfaces()
                             where typeof(IHaveCustomMappings).GetTypeInfo().IsAssignableFrom(t) &&
                                   !t.GetTypeInfo().IsAbstract &&
                                   !t.GetTypeInfo().IsInterface
                             select (IHaveCustomMappings)Activator.CreateInstance(t);

            return customMaps;
        }

        public class TypesMap
        {
            public Type Source { get; set; }
            public Type Destination { get; set; }
        }
    }
}
