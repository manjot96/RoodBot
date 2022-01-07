using System;
namespace RoodBot.Common;

public interface IResourceService<T>
{
    Task<List<T>> GetAsync();

    Task<T?> GetAsync(string id);

    Task CreateAsync(T newEntity);

    Task UpdateAsync(string id, T updatedEntity);

    Task RemoveAsync(string id);

}

