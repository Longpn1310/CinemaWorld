using AutoMapper;

namespace CinemaWorld.Services.Services.Data.Mapping
{
    public interface IHaveCustomMappings
    {
        //IProfileExpression là một interface để cấu hình và quản lý các quy tắc ánh xạ
        //CreateMappings: Cấu hình ánh xạ tự quản lý, tuỳ chỉnh
        void CreateMappings(IProfileExpression configuration);
    }
}
