using AutoMapper;

namespace CinemaWorld.ViewModels.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
