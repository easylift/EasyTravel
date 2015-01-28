using AutoMapper;

namespace Core.Infrastructure.Mapping
{
	public interface ICustomMapping
	{
		void CreateMappings(IConfiguration configuration);
	}
}