using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class GoalUrlResolver : IValueResolver<Goal, GoalToReturnDTO, string>
{
    private readonly IConfiguration _config;
    public GoalUrlResolver(IConfiguration config)
    {
        _config = config;
    }

    public string Resolve(Goal source, GoalToReturnDTO destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
        {
            return _config["ApiUrl"] + source.PictureUrl;
        }

        return null;
    }
}
